param(
  [Parameter(Position=0,Mandatory=0)]
  [string]$buildFile = 'psakefile.ps1',
  [Parameter(Position=1,Mandatory=0)]
  [string[]]$taskList = @(),
  [Parameter(Position=2,Mandatory=0)]
  [string]$framework = '3.5',
  [Parameter(Position=3,Mandatory=0)]
  [switch]$docs = $false,
  [Parameter(Position=4,Mandatory=0)]
  [System.Collections.Hashtable]$parameters = @{},
  [Parameter(Position=5, Mandatory=0)]
  [System.Collections.Hashtable]$properties = @{}
)

$scriptPath = Split-Path $script:MyInvocation.MyCommand.Path

# setting $scriptPath here, not as default argument, to support calling as "powershell -File psake.ps1"
if (-not $scriptPath) {
    $scriptPath = $(Split-Path -Path $MyInvocation.MyCommand.path -Parent)
}

$script:psrepoConfigFile = 'psrepo-config.ps1'

function GenRepoInfo()
{
    [string]$repoName = $args[0]
    [System.IO.Path]$repoPath = $args[1];
    [string]$repoType = $args[2]
    [array]$repoBranchs = $args[3]
    [uri]$repoUrl = $args[4]

    $repoStructure = @{
        "name" = $repoName
        "path" = $repoPath
        "type" = $repoType
        "branch" = $repoBranch
        "url" = $repoUrl
    }

    return $repoStructure
}

function GenRepoStructure()
{

    $repoStructures = "$repoStructure";
    $repoStructures.Add(GenRepoInfo("dev.Autom8","C:\pss\dev.Autom8","public",@("master","develop"),[uri]"
    https://github.com/Azure-Samples/dev.Autom8.git"))

    
    $top_repository_folders=@()
    $toplevelfolders = @(".github", ".vscode", "build", "docs", "tools", "examples", "images", "src","specs","tests")
    $top_repository_folders.Add($toplevelfolders)


    $top_repository_files=@()
    $toplevelfiles = @(".gitattributes",".gitignore",".travis.yml","appveyor.yml","azure-pipelines.y","build.ps1","CHANGELOG.md","LICENSE","mkdocs.yml","README.md","requirements.psd1","CHANGELOG.md")
    $top_repository_files.Add($toplevelfiles)

    $dotgithub=".github"
    $docs="docs"
    $src="src"
    $tests="tests"
    $dotvscode='.vscode'

    $mid_repository_folders=@("$dotgithub\workflows\","$docs\reference\functions\","$src\private\"
    "$src\public\","$tests\integration\")
    $mid_repository_folders.Add($mid_repository_folders)

    $mid_repository_files=@("$dotgithub\workflows\push.yml","$dotgithub\CONTRIBUTING.md","$dotgithub\FUNDING.yml","$dotgithub\FUNDING.yml","$dotgithub\ISSUE_TEMPLATE.md", "$dotgithub\PULL_REQUEST_TEMPLATE.md","$dotgithub\stale.yml","$dotvscode\extensions.json","$dotvscode\launch.json","$dotvscode\settings.json","$dotvscode\tasks.json")
    $mid_repository_files.Add($mid_repository_files)
}
