#!/bin/bash
set -euxo pipefail

docker-compose exec ksql-cli ksql http://ksql-server:8088