@echo off

REM Define the base directory (the directory where the script is located)
set BASE_DIR=%~dp0

REM List of project directories relative to the base directory
setlocal EnableDelayedExpansion
set PROJECTS=src\Microservices\Student\University.Manager.Project.Student.Api src\Microservices\Order\University.Manager.Project.Order.Api src\Microservices\IdentityServer\University.Manager.Project.IdentityServer src\Microservices\Financial\University.Manager.Project.Financial.Api src\Microservices\Course\University.Manager.Project.Course.Api

pause

REM Loop through each project directory and run the update command
for %%p in (%PROJECTS%) do (
    echo Updating database for project: %%p
    cd "%BASE_DIR%%%p"
    
    REM Try to execute the command
    dotnet ef database update
    if errorlevel 1 (
        echo Error updating database for project: %%p
        echo.
    )
    
    REM Return to the base directory
    cd %BASE_DIR%
)

echo All projects updated!
pause
