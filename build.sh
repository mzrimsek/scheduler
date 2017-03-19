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

publish() {
    dotnet restore
    dotnet publish
    dotnet ef database update
    gcloud config set project $PROJECT
    gcloud app deploy ./bin/Debug/netcoreapp1.0/publish/app.yaml --quiet
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
