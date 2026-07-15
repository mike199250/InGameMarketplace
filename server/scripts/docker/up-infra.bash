#!/usr/bin/env bash
set -euo pipefail

readonly script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
readonly server_root="$(cd "$script_dir/../.." && pwd)"

readonly env_file="$server_root/env/.env.local"
readonly docker_dir="$server_root/docker"

# Load env variables manually
if [[ -f "$env_file" ]]; then
  export $(grep -v '^#' "$env_file" | xargs)
else
  echo "❌ .env.local not found!"
  exit 1
fi

# Create external network if it doesn't exist
if ! docker network inspect "${PROJECT_NAME}-network" > /dev/null 2>&1; then
  echo "🔧 Creating network: ${PROJECT_NAME}-network"
  docker network create "${PROJECT_NAME}-network"
else
  echo "🚀 Network already exists: ${PROJECT_NAME}-network"
fi

# Move to docker directory
cd "$docker_dir"

# Start services
docker compose --env-file "$env_file" up -d

echo "✅ Docker services started for project: ${PROJECT_NAME}"
