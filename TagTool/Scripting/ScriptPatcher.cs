using System;
using System.Collections.Generic;
using System.Text;

namespace TagTool.Scripting
{
    public class ScriptPatcher
    {
        private readonly List<(int flags, string pattern, string replacement)> _rules = new();

        public void AddRule(int flags, string pattern, string replacement)
        {
            _rules.Add((flags, pattern, replacement));
        }

        public string Apply(string source, int activeFlags)
        {
            foreach (var (flags, pattern, replacement) in _rules)
            {
                if (flags != 0 && (activeFlags & flags) == 0)
                    continue;
                source = ApplyRule(source, pattern, replacement);
            }
            return source;
        }

        private static string ApplyRule(string source, string pattern, string replacement)
        {
            // Parse pattern: extract function name and argument patterns
            if (pattern.Length < 2 || pattern[0] != '(' || pattern[^1] != ')')
                return source;

            var patternParts = ParseTopLevelList(pattern);
            if (patternParts.Count == 0)
                return source;

            var funcName = patternParts[0];
            var argPatterns = new List<string>();
            for (int i = 1; i < patternParts.Count; i++)
                argPatterns.Add(patternParts[i]);

            // Scan source for matches
            var sb = new StringBuilder();
            int pos = 0;
            while (pos < source.Length)
            {
                // Find next '('
                int openParen = source.IndexOf('(', pos);
                if (openParen < 0)
                {
                    sb.Append(source, pos, source.Length - pos);
                    break;
                }

                // Try to match at this position
                var (matched, endPos, captures) = TryMatch(source, openParen, funcName, argPatterns);
                if (matched)
                {
                    // Copy text before the match
                    sb.Append(source, pos, openParen - pos);
                    // Append replacement with captures substituted
                    sb.Append(Substitute(replacement, captures));
                    pos = endPos;
                }
                else
                {
                    // Copy up to and including this '('
                    sb.Append(source, pos, openParen - pos + 1);
                    pos = openParen + 1;
                }
            }

            return sb.ToString();
        }

        private static (bool matched, int endPos, List<string> captures) TryMatch(
            string source, int openParen, string funcName, List<string> argPatterns)
        {
            // Extract all arguments from the source starting at openParen
            var args = new List<string>();
            int pos = openParen + 1; // skip '('
            int depth = 1;

            while (pos < source.Length && depth > 0)
            {
                // Skip whitespace
                while (pos < source.Length && char.IsWhiteSpace(source[pos]))
                    pos++;
                if (pos >= source.Length) break;

                if (source[pos] == ')')
                {
                    depth--;
                    if (depth == 0)
                    {
                        pos++; // skip ')'
                        break;
                    }
                    // ')' inside a nested expression - should not happen in valid script
                    pos++;
                    continue;
                }

                // Extract one argument (may be an atom or a nested list)
                int argStart = pos;
                if (source[pos] == '(')
                {
                    // Nested list - find matching ')'
                    int nestedDepth = 1;
                    pos++;
                    while (pos < source.Length && nestedDepth > 0)
                    {
                        if (source[pos] == '(') nestedDepth++;
                        else if (source[pos] == ')') nestedDepth--;
                        pos++;
                    }
                    args.Add(source[argStart..pos]);
                }
                else if (source[pos] == '"')
                {
                    // Quoted string
                    pos++;
                    while (pos < source.Length && source[pos] != '"')
                    {
                        if (source[pos] == '\\') pos++; // skip escaped char
                        pos++;
                    }
                    if (pos < source.Length) pos++; // skip closing '"'
                    args.Add(source[argStart..pos]);
                }
                else if (source[pos] == ';')
                {
                    // Comment - skip to end of line
                    while (pos < source.Length && source[pos] != '\n')
                        pos++;
                }
                else
                {
                    // Atom - read until whitespace, ')', or '('
                    while (pos < source.Length && !char.IsWhiteSpace(source[pos]) &&
                           source[pos] != ')' && source[pos] != '(')
                        pos++;
                    args.Add(source[argStart..pos]);
                }
            }

            if (depth != 0)
                return (false, 0, null); // unclosed paren

            // Check function name matches
            if (args.Count == 0 || args[0] != funcName)
                return (false, 0, null);

            // Match arguments against pattern
            var captures = new List<string>();
            int argIdx = 1; // skip function name
            int patIdx = 0;
            bool hasStar = false;

            while (patIdx < argPatterns.Count && argIdx < args.Count)
            {
                var pat = argPatterns[patIdx];
                if (pat == "$*")
                {
                    // Capture all remaining args as a single space-separated string
                    var remaining = new StringBuilder();
                    for (int i = argIdx; i < args.Count; i++)
                    {
                        if (i > argIdx) remaining.Append(' ');
                        remaining.Append(args[i]);
                    }
                    captures.Add(remaining.ToString());
                    hasStar = true;
                    patIdx++;
                    argIdx = args.Count;
                    break;
                }
                else if (pat.StartsWith("$"))
                {
                    // Capture this argument
                    captures.Add(args[argIdx]);
                    patIdx++;
                    argIdx++;
                }
                else if (pat.StartsWith("("))
                {
                    // Nested pattern list - recursively match
                    if (!args[argIdx].StartsWith("("))
                        return (false, 0, null);

                    var subParts = ParseTopLevelList(pat);
                    if (subParts.Count == 0)
                        return (false, 0, null);

                    var (subMatched, _, subCaptures) = TryMatch(
                        args[argIdx], 0, subParts[0],
                        subParts.GetRange(1, subParts.Count - 1));

                    if (!subMatched)
                        return (false, 0, null);

                    captures.AddRange(subCaptures);
                    patIdx++;
                    argIdx++;
                }
                else
                {
                    // Must match exactly
                    if (args[argIdx] != pat)
                        return (false, 0, null);
                    patIdx++;
                    argIdx++;
                }
            }

            // Handle $* at end with no remaining args
            if (patIdx < argPatterns.Count && argPatterns[patIdx] == "$*")
            {
                captures.Add("");
                patIdx++;
                hasStar = true;
            }

            // All pattern parts must be consumed, and all args consumed (unless $* handled them)
            if (patIdx != argPatterns.Count || (!hasStar && argIdx != args.Count))
                return (false, 0, null);

            return (true, pos, captures);
        }

        private static string Substitute(string template, List<string> captures)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < template.Length)
            {
                if (template[i] == '$' && i + 1 < template.Length)
                {
                    if (template[i + 1] == '*')
                    {
                        // $* - substitute with captured variadic args
                        int starIndex = captures.Count - 1; // $* is always last capture
                        if (starIndex >= 0)
                            sb.Append(captures[starIndex]);
                        i += 2;
                        continue;
                    }
                    else if (char.IsDigit(template[i + 1]))
                    {
                        // $N - substitute with captured argument
                        int numStart = i + 1;
                        while (numStart < template.Length && char.IsDigit(template[numStart]))
                            numStart++;
                        var numStr = template[(i + 1)..numStart];
                        if (int.TryParse(numStr, out int n) && n >= 1 && n <= captures.Count - (captures.Count > 0 && template.Contains("$*") ? 1 : 0))
                            sb.Append(captures[n - 1]);
                        else
                            sb.Append(template[i..numStart]); // keep as-is if invalid
                        i = numStart;
                        continue;
                    }
                }
                sb.Append(template[i]);
                i++;
            }
            return sb.ToString();
        }

        // Parse a top-level list like (a b (c d) e) into parts: ["a", "b", "(c d)", "e"]
        private static List<string> ParseTopLevelList(string expr)
        {
            var parts = new List<string>();
            if (expr.Length < 2 || expr[0] != '(' || expr[^1] != ')')
                return parts;

            int i = 1;
            while (i < expr.Length - 1)
            {
                while (i < expr.Length - 1 && char.IsWhiteSpace(expr[i]))
                    i++;
                if (i >= expr.Length - 1) break;

                if (expr[i] == '(')
                {
                    int depth = 1;
                    int start = i;
                    i++;
                    while (i < expr.Length && depth > 0)
                    {
                        if (expr[i] == '(') depth++;
                        else if (expr[i] == ')') depth--;
                        i++;
                    }
                    parts.Add(expr[start..i]);
                }
                else if (expr[i] == '"')
                {
                    int start = i;
                    i++;
                    while (i < expr.Length && expr[i] != '"')
                    {
                        if (expr[i] == '\\') i++;
                        i++;
                    }
                    if (i < expr.Length) i++;
                    parts.Add(expr[start..i]);
                }
                else
                {
                    int start = i;
                    while (i < expr.Length - 1 && !char.IsWhiteSpace(expr[i]) && expr[i] != '(' && expr[i] != ')')
                        i++;
                    parts.Add(expr[start..i]);
                }
            }
            return parts;
        }
    }
}
