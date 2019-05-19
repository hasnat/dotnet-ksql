#!/bin/bash
set -euxo pipefail

if [ -e /opt/local/ksql-queries/run-once.lock ]
then
    echo "Skip run-once.ksql"
else
    echo "Delete this file if you want to run run-once.ksql" > /opt/local/ksql-queries/run-once.lock
    echo "Running run-once.ksql"
    cat /opt/local/ksql-queries/run-once.ksql | ksql http://ksql-server:8088
fi

echo "Running run-always.ksql"
cat /opt/local/ksql-queries/run-always.ksql | ksql http://ksql-server:8088
exit 0
