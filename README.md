# scheduler
Scheduler application built for Kent State University Capstone course using Dotnet Core.

## Getting up and running
1. [Install dotnet core](https://www.microsoft.com/net/core)
2. Clone this repo: `git clone https://github.com/mzrimsek/scheduler.git`

There are build scripts set up for local development.
* On Windows: ```./build.ps1```
* On Linux/Mac: ```./build.sh```

For both scripts there are two optional arguments you can pass in.
* ```build``` - executes the build step to compile, bundle, and minify your code (passing in no arguments defaults to this option)
* ```run``` - does the same as ```build``` except it will also serve the application at ```localhost:5000```