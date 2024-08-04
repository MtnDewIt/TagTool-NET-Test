﻿using System.Collections.Generic;

namespace TagTool.MtnDewIt.JSON
{
    public class TagObject 
    {
        public string TagName { get; set; }
        public string TagType { get; set; }

        public List<AddStringFunction> AddStrings { get; set; }
        public List<AddBitmapFunction> AddBitmaps { get; set; }
        public List<AddAnimationFunction> AddAnimations { get; set; }
        public CompileScriptFunction CompileScript { get; set; }
        public SortModesFunction SortModes {get; set;}

        public object TagData { get; set; }
    }

    public class AddStringFunction 
    {
        public string StringIdName { get; set; }
        public string StringIdContent { get; set; }

        public AddStringFunction(string stringIdName, string stringIdContent) 
        {
            StringIdName = stringIdName;
            StringIdContent = stringIdContent;
        }
    }

    public class AddBitmapFunction
    {
        public int BitmapIndex { get; set; }
        public string DDSFile { get; set; }

        public AddBitmapFunction(int bitmapIndex, string ddsFile) 
        {
            BitmapIndex = bitmapIndex;
            DDSFile = ddsFile;
        }
    }

    public class AddAnimationFunction
    {
        public string AnimationFile { get; set; }

        public AddAnimationFunction(string animationFile) 
        {
            AnimationFile = animationFile;
        }
    }

    public class CompileScriptFunction
    {
        public string ScriptFile { get; set; }

        public CompileScriptFunction(string scriptFile) 
        {
            ScriptFile = scriptFile;
        }
    }
    public class SortModesFunction
    {
        public bool SortModes { get; set; }

        public SortModesFunction(bool sortModes) 
        {
            SortModes = sortModes;
        }
    }
}