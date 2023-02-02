#!/bin/bash
set -eux

# Assert that current branch is main
git rev-parse --abbrev-ref HEAD | grep -q main

# Assert that there are no uncommitted changes
git diff-index --quiet HEAD --

# Bump version in ScipDotnet.csproj
NEW_VERSION="$1"
sed -i.bak "s/<Version>.*<\/Version>/<Version>$NEW_VERSION<\/Version>/" ScipDotnet/ScipDotnet.csproj
rm ScipDotnet/ScipDotnet.csproj.bak

# Commit and tag new version
VERSION_TAG="v$NEW_VERSION"
git add .
git commit -m "Bump version to $VERSION_TAG" --allow-empty
git push origin main
git tag -af "$VERSION_TAG" -m "Version $NEW_VERSION"
git push -f origin "$VERSION_TAG"
