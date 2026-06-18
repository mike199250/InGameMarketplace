#!/bin/bash

set -e

# Move to the docker directory
cd "$(dirname "$0")/../docker"

# Stop all running containers defined in docker-compose
docker compose --env-file ../.env.local down

echo "🛑 Docker services stopped."
