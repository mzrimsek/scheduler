#!/bin/bash

build() {
    export ASPNETCORE_ENVIRONMENT=Development
    dotnet restore
    dotnet bundle
    dotnet ef database update
}

run() {
    build
    dotnet run
}

if [ "$#" -le 1 ]; then
    OPTION=$1
    if [ "$OPTION" = "" ] || [ "$OPTION" = "build" ]; then
        echo "Building..."
        build
    elif [ "$OPTION" = "run" ]; then
        echo "Building and running..."
        run
    else
        echo "Invalid option"
        echo "Valid options are 'build' (default) and 'run'"
    fi
else
    echo "Too many arguments"
fi