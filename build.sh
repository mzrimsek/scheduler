#!/bin/bash

build() {
    dotnet restore
    dotnet build
}

run() {
    build
    dotnet run
}

publish() {
    dotnet restore
    dotnet publish
    gcloud beta app deploy ./bin/Debug/netcoreapp1.0/publish/app.yaml
}

OPTION=$1
if [ "$OPTION" = "" ] || [ "$OPTION" = "build" ]; then
	echo "Building..."
	build
elif [ "$OPTION" = "run" ]; then
    echo "Building and running..."
    run
elif [ "$OPTION" = "publish" ]; then
	echo "Publishing..."
	publish
else
	echo "Invalid option"
    echo "Valid options are 'build' (default), 'run', and 'publish'"
fi
