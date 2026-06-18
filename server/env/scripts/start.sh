#!/bin/bash

set -e

# Resolve script directory
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ENV_FILE="$SCRIPT_DIR/../.env.local"

# Load env variables manually
if [[ -f "$ENV_FILE" ]]; then
  export $(grep -v '^#' "$ENV_FILE" | xargs)
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
cd "$SCRIPT_DIR/../docker"

# Start services
docker compose --env-file ../.env.local up -d

echo "✅ Docker services started for project: ${PROJECT_NAME}"
