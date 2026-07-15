#!/usr/bin/env bash
set -euo pipefail
shopt -s nullglob

readonly script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
readonly server_root="$(cd "$script_dir/../.." && pwd)"

readonly logs_dir="$server_root/logs"
today=$(date +%Y%m%d)
logs=("$logs_dir"/*/"$today".log)

if ((${#logs[@]} == 0)); then
    echo "No log files found for ${today}."
    exit 1
fi

lnav "${logs[@]}"
