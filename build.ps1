function build {
    $env:ASPNETCORE_ENVIRONMENT="Development"
    dotnet restore
    dotnet build
    dotnet bundle
    dotnet ef database update
}

function run {
    build
    dotnet run
}

$OPTION = $null
if ($args.Length -eq 0){
   $OPTION = "build"
}
else {
    $OPTION = $args[0]
}

if ($OPTION -eq "build") {
    Write-Host "Building..."
    build
}
ElseIf ($OPTION -eq "run") {
    Write-Host "Building and running..."
    run
}
Else {
    Write-Host "Invalid option"
    Write-Host "Valid options are 'build' (default) and 'run'"
}