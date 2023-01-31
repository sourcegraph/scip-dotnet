# scip-dotnet

SCIP indexer for the C# programming language.

## Getting started

This project is not yet published so the only way to run the indexer is by building it from [source locally](#running-locally).
This section will be updated in the future when it's possible to run pre-built binaries.

## Running locally

First, install .NET https://dotnet.microsoft.com/en-us/download/dotnet-framework.

Next, clone this repo locally:

```shell
git clone https://github.com/sourcegraph/scip-dotnet
cd scip-dotnet
```

Finally, use `dotnet run` to run the indexer locally.
```shell
dotnet run --project ScipDotnet -- index --working-directory PATH_TO_DIRECTORY_YOU_WANT_TO_INDEX
```

Once scip-dotnet has finished indexing the project, there should be an `index.scip` at the root of the
directory you've indexed. Use `src code-intel upload` to upload the SCIP index to Sourcegraph.
```shell
npm install -g @sourcegraph/src
export SRC_ACCESS_TOKEN=PASTE_YOUR_TOKEN_HERE
export SRC_ENDPOINT=https://sourcegraph.com
src code-intel upload
```

## Testing

This project heavily uses "snapshot" or "expect" tests.
See [Verify](https://github.com/VerifyTests/Verify), ["Testing with expectations"](https://blog.janestreet.com/testing-with-expectations/)
or ["Snapshot Testing"](https://jestjs.io/docs/snapshot-testing) to learn more about this style of testing.

Run `dotnet test` to run all tests.
The tests fail with a unified diff output when the generated SCIP index does not format according to the generated snapshot output in the directory `snapshots/output/` .
```diff
❯ dotnet test
...
A total of 1 test files matched the specified pattern.
  Failed Snapshot("/Users/olafurpg/dev/sourcegraph/scip-dotnet/snapshots/input/syntax") [3 s]
  Error Message:
   (+ expected, - obtained). To update the expected output to match the obtained behavior, run: SCIP_UPDATE_SNAPSHOTS=true dotnet test

  //               ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TargetType#`.ctor`().
+ //                          documentation ```cs\npublic Main.Expressions.TargetType.TargetType(System.String name)\n```

...
```

If you're happy with the new behavior, run `SCIP_UPDATE_SNAPSHOTS=true dotnet test` to update the snapshot tests.

## Editor support

We recommend using [JetBrains Rider](https://www.jetbrains.com/rider/) to work on this codebase.

The snapshot testing project is independent from the main solution and should be opened as a separate Rider window.