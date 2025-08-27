#!/bin/bash

set -e

# Move to the docker directory
cd "$(dirname "$0")/../docker"

# Follow logs for all services
docker compose --env-file ../.env.local logs -f
