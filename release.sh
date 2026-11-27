#!/usr/bin/env bash

# Bumps the version in ScipDotnet.csproj for the next release.
# Merging the bump to main tags and publishes the release
# (see .github/workflows/tag-release.yml).
#
# Usage: ./release.sh [NEW_VERSION]
# NEW_VERSION should be a string M.N.P. Defaults to the next patch version
# after the latest release tag.

set -euo pipefail

cd "$(dirname "${BASH_SOURCE[0]}")"

LAST_TAG="$(git describe --tags --abbrev=0 --match 'v[0-9]*')"
IFS=. read -r MAJOR MINOR PATCH <<<"${LAST_TAG#v}"
NEW_VERSION="${1:-$MAJOR.$MINOR.$((PATCH + 1))}"

if ! [[ "$NEW_VERSION" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
  echo "error: $NEW_VERSION is not of the form M.N.P"
  exit 1
fi
if [ "$(printf '%s\n%s\n' "${LAST_TAG#v}" "$NEW_VERSION" | sort -V | tail -n 1)" != "$NEW_VERSION" ] ||
  [ "$NEW_VERSION" = "${LAST_TAG#v}" ]; then
  echo "error: $NEW_VERSION must be newer than the latest release $LAST_TAG"
  exit 1
fi

CSPROJ=ScipDotnet/ScipDotnet.csproj
sed -E "s|<Version>[^<]*</Version>|<Version>$NEW_VERSION</Version>|" "$CSPROJ" >"$CSPROJ.new"
mv "$CSPROJ.new" "$CSPROJ"
echo "Prepared release v$NEW_VERSION"
