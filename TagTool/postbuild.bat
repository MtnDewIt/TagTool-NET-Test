cd $(ProjectDir)$(OutDir)
xcopy "$(ProjectDir)..\Physics" "Physics" /e /i /h /Y /d
xcopy "$(ProjectDir)..\Tools" "Tools" /e /i /h /Y /d
xcopy "$(ProjectDir)..\ShaderGenerator\HaloShaderGenerator\bin\x64\$(ConfigurationName)" "Tools" /e /i /h /Y /d

IF "$(PlatformName)" == "x64" (
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

cd $(ProjectDir)
if ERRORLEVEL == 0 (
xcopy "$(ProjectDir)..\Tools\HaloShaderGenerator.dll" "$(ProjectDir)$(OutDir)" /e /i /h /Y /d 2&gt;nul 1&gt;nul
SET ERRORLEVEL=0
)
EXIT %25ERRORLEVEL%25
