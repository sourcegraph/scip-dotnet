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

## Logging

By default, only logs of warning level or higher are shown. To show debug logs set the following environment variable before running scip-dotnet

```
export Logging__LogLevel__Default=Debug
```

## Releasing a new version

A [scheduled workflow](.github/workflows/scheduled-release.yml) opens a patch
release PR every 4 weeks on Monday, even without code changes, so the Docker
image picks up base image and package updates. It can also be run on demand
from the
[GitHub Actions UI](https://github.com/sourcegraph/scip-dotnet/actions/workflows/scheduled-release.yml).

To prepare a release by hand, run `./release.sh NEW_VERSION` on a branch off the
latest `main`, for example `./release.sh 1.2.0` (without `NEW_VERSION`, it bumps
the patch version). The script updates the version in
[ScipDotnet.csproj](ScipDotnet/ScipDotnet.csproj); open a PR with the change.

Once the version bump is merged to `main`, the
[tag workflow](.github/workflows/tag-release.yml) pushes the `vM.N.P` tag and
starts the [publish workflow](.github/workflows/publish.yml), which publishes
the tool to NuGet and the Docker image to Docker Hub. Don't push release tags
by hand.

## Editor support

We recommend using [JetBrains Rider](https://www.jetbrains.com/rider/) to work
on this codebase.

The snapshot testing project is independent from the main solution and should be
opened as a separate Rider window.
