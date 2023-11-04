:: $(ProjectDir) in %1
:: $(OutDir) in %2
:: $(PlatformName) in %3
:: $(ConfigurationName) in %4

cd %1%2
xcopy "%1..\Physics" "Physics" /e /i /h /Y /d
xcopy "%1..\Tools" "Tools" /e /i /h /Y /d
xcopy "%1..\ShaderGenerator\HaloShaderGenerator\bin\x64\%4" "Tools" /e /i /h /Y /d

IF "%3" == "x64" (
del "Tools\meshoptimizer32.dll"
ren "Tools\meshoptimizer64.dll" meshoptimizer.dll
del "Tools\fmod.dll"
ren "Tools\fmod64.dll" fmod.dll
) ELSE (
del "Tools\meshoptimizer64.dll"
ren "Tools\meshoptimizer32.dll" meshoptimizer.dll
del "Tools\fmod64.dll"
)

:: md  "Tools\scripting"
:: for /f "eol=: delims=" %25%25F in ('dir /b^|find "System"') do move /Y "%25%25F" "Tools\scripting"
:: for /f "eol=: delims=" %25%25F in ('dir /b^|find "Microsoft.CodeAnalysis"') do move /Y "%25%25F" "Tools\scripting"

cd %1
if ERRORLEVEL == 0 (
xcopy "%1..\Tools\HaloShaderGenerator.dll" "%1%2" /e /i /h /Y /d 2>nul 1>nul
SET ERRORLEVEL=0
)
EXIT %25ERRORLEVEL%25
