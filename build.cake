var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  Information("Hello World!");
  var nugetRestoreSettings = new NuGetRestoreSettings {
        ConfigFile = new FilePath("./nuget.config")
   };

    
     NuGetRestore("SalaryMgr.sln",nugetRestoreSettings);
    
      MSBuild("SalaryMgr.sln");
});

RunTarget(target);