#!/usr/bin/env bash
set -euo pipefail

readonly script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
readonly server_root="$(cd "$script_dir/../.." && pwd)"

readonly env_file="$server_root/env/.env.local"
readonly docker_dir="$server_root/docker"

# Move to the docker directory
cd "$docker_dir"

# Stop all running containers defined in docker-compose
docker compose --env-file "$env_file" down

echo "🛑 Docker services stopped."
