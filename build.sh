#!/bin/bash

PROJECT="scheduler-2017"

build() {
    dotnet restore
    dotnet build
    dotnet ef database update
}

run() {
    build
    dotnet run
}

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
