#addin Cake.Coveralls

#tool "nuget:?package=xunit.runner.console"
#tool "nuget:?package=ReportGenerator&version=4.0.4"
#tool coveralls.io

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var skipCoverage = Argument("skipCoverage", false);

var rootAbsoluteDir = MakeAbsolute(Directory("./"));
var artifactsDir  = rootAbsoluteDir.Combine("artifacts");
var coverageDir = artifactsDir.Combine("coverage");

var reportGenerator = rootAbsoluteDir.CombineWithFilePath("tools/ReportGenerator.4.0.4/tools/netcoreapp2.0/ReportGenerator.dll");

var coverallsToken = Context.EnvironmentVariable("COVERALLS_REPO_TOKEN");

if (!DirectoryExists(artifactsDir)) 
{
    CreateDirectory(artifactsDir);
}

FilePath GetFileResult(FilePath file) 
{    
    FilePath resultFile;

    if (IsRunningOnWindows()) {
        resultFile = rootAbsoluteDir.GetRelativePath(coverageDir.CombineWithFilePath(file));
    } else {
        resultFile = coverageDir.CombineWithFilePath(file);
    }

    return resultFile;
}

Task("Clean")
    .Does(() => {
        CleanDirectory(artifactsDir);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => { 
        
        DotNetCoreBuild(".", new DotNetCoreBuildSettings()
        {
            Configuration = configuration,
            ArgumentCustomization = args => args.Append($"--no-restore"),
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
    {
        var projects = GetFiles("./test/**/*.csproj").ToList();

        var totalProjects = projects.Count();

        for (var i = 0; i < totalProjects; i++)
        {
            var dotnetcoreSettings = new DotNetCoreTestSettings
            {
                Configuration = configuration,
                NoBuild = true,
                ArgumentCustomization = args => args.Append($"--no-restore")
            };
            
            var project = projects[i];

            Information("Testing project: " + project);

            if (!skipCoverage) 
            {
                List<string> coverletArgs = new List<string> 
                {
                    "/p:CollectCoverage=true",
                    "/p:Exclude=\"[*.Tests]\""
                };

                if (i == totalProjects - 1)
                {
                    coverletArgs.Add($"/p:CoverletOutput='{GetFileResult("opencover.xml")}'");
                    coverletArgs.Add("/p:CoverletOutputFormat=opencover");

                    if (totalProjects > 1) 
                    {
                        coverletArgs.Add($"/p:MergeWith='{GetFileResult("coverage.json")}'");
                    }
                } 
                else 
                {
                    coverletArgs.Add($"/p:CoverletOutput='{GetFileResult("coverage.json")}'");
                    coverletArgs.Add("/p:CoverletOutputFormat=json");
                }

                dotnetcoreSettings.ArgumentCustomization = args => args.Append(string.Join(" ", coverletArgs));
            }

            DotNetCoreTest(project.FullPath, dotnetcoreSettings);
        }
    });

Task("CoverageReport")
    .IsDependentOn("Test")
    .Does(() => {

        if (IsRunningOnWindows()) 
        {
            ReportGenerator(coverageDir.CombineWithFilePath("opencover.xml"), artifactsDir.Combine("results"));
        }
        else 
        {
            DotNetCoreExecute(reportGenerator, $"-reports:{coverageDir.CombineWithFilePath("opencover.xml")} -targetdir:{artifactsDir.Combine("results")}");
        }
    });

Task("PublishCodeCoverage")
    .IsDependentOn("Test")
    .WithCriteria(() => !string.IsNullOrEmpty(coverallsToken))
    .Does(() => {

        CoverallsIo(coverageDir.CombineWithFilePath("opencover.xml"), new CoverallsIoSettings()
        {
            RepoToken = coverallsToken
        });
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => { 
        DotNetCoreRestore();
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

Task("BuildTestAndPublishCodeCoverage")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("CoverageReport")
    .IsDependentOn("PublishCodeCoverage");

RunTarget(target);