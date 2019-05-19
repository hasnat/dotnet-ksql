#!/bin/bash
set -euxo pipefail

docker-compose stop
docker-compose down
docker-compose rm
rm ./ksql-queries/run-once.lock || true

docker volume prune


docker-compose up --build