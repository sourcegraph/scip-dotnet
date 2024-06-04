# scip-dotnet

SCIP indexer for the C# and Visual basic programming languages.

## Getting started

The easiest way to run `scip-dotnet` is to use the `sourcegraph/scip-dotnet`
Docker image. You can alternatively install `scip-dotnet` as a local
command-line tool by following the [local install](#local-install) instructions.

### Docker image

Execute `docker run` to index a codebase with `scip-dotnet`.

```sh
docker run -v $(pwd):/app sourcegraph/scip-dotnet:latest scip-dotnet index
```

Once this command finishes then you should have an `index.scip` file that you
can upload to Sourcegraph with `src code-intel upload`.

```sh
npm install -g @sourcegraph/src
export SRC_ACCESS_TOKEN=PASTE_YOUR_ACCESS_TOKEN
export SRC_ENDPOINT=https://sourcegraph.com
src code-intel upload
```

### Local install

The following steps show you how to install a `scip-dotnet` command-line tool to
your local computer.

First, install .NET 8.0
https://dotnet.microsoft.com/en-us/download.

Next, run `dotnet tool install`.

```sh
dotnet tool install --global scip-dotnet
scip-dotnet --version
```

Finally, run `scip-dotnet index` at the root of your project to index the
codebase.

```sh
cd PATH_TO_CSHARP_PROJECT
scip-dotnet index
```

If you already have `scip-dotnet` installed you will get an error message saying
"Tool 'scip-dotnet' is already installed.". To fix this problem, run the command
`dotnet tool update --global scip-dotnet` to update to the latest version.

## Contributing

The section below is only relevant for contributors to this repository.

## Building from source

First, install .NET
https://dotnet.microsoft.com/en-us/download/dotnet-framework.

Next, clone this repo locally:

```shell
git clone https://github.com/sourcegraph/scip-dotnet
cd scip-dotnet
```

Finally, use `dotnet run` to run the indexer locally.

```shell
dotnet run --project ScipDotnet -- index --working-directory PATH_TO_DIRECTORY_YOU_WANT_TO_INDEX
```

Once scip-dotnet has finished indexing the project, there should be an
`index.scip` at the root of the directory you've indexed. Use
`src code-intel upload` to upload the SCIP index to Sourcegraph.

```shell
npm install -g @sourcegraph/src
export SRC_ACCESS_TOKEN=PASTE_YOUR_TOKEN_HERE
export SRC_ENDPOINT=https://sourcegraph.com
src code-intel upload
```

## Testing

This project heavily uses "snapshot" or "expect" tests. See
[Verify](https://github.com/VerifyTests/Verify),
["Testing with expectations"](https://blog.janestreet.com/testing-with-expectations/)
or ["Snapshot Testing"](https://jestjs.io/docs/snapshot-testing) to learn more
about this style of testing.

Run `dotnet test` to run all tests. The tests fail with a unified diff output
when the generated SCIP index does not format according to the generated
snapshot output in the directory `snapshots/output/` .

````diff
❯ dotnet test
...
A total of 1 test files matched the specified pattern.
  Failed Snapshot("/Users/olafurpg/dev/sourcegraph/scip-dotnet/snapshots/input/syntax") [3 s]
  Error Message:
   (+ expected, - obtained). To update the expected output to match the obtained behavior, run: SCIP_UPDATE_SNAPSHOTS=true dotnet test

  //               ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TargetType#`.ctor`().
+ //                          documentation ```cs\npublic Main.Expressions.TargetType.TargetType(System.String name)\n```

...
````

If you're happy with the new behavior, run
`SCIP_UPDATE_SNAPSHOTS=true dotnet test` to update the snapshot tests.

## Releasing a new version

First, make sure that you are on the latest `main` branch and have no dirty
changes.

Next, figure out the correct version number by finding the current in
[ScipDotnet.cspro](ScipDotnet/ScipDotnet.csproj).

Next, run the `./release.sh NEW_VERSION`. For example, run `./release.sh 1.2.0`
to release the version 1.2.0. The script commits the necessary changes and
pushes a git tag, which triggers a CI job that publishes assemblies to NuGet and
the Docker image to Docker Hub.

## Editor support

We recommend using [JetBrains Rider](https://www.jetbrains.com/rider/) to work
on this codebase.

The snapshot testing project is independent from the main solution and should be
opened as a separate Rider window.
