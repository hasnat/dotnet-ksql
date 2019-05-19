# Dotnet Kafka + KSQL
Kafka, Ksql, Producers, Consumers .net.


## RUN
To execute, clone this repository and run

```
docker-compose up
```

It will start
- `zookeeper`
- `kafka`
- `ksql-server` with 2 queries
  - First query to read `KSQL_INPUT` topic to ksql stream called `CSV_WITHIN_KSQL`
  - Second query to read `CSV_WITHIN_KSQL` (why any given query/aggregation) and output to kafka topic `KSQL_OUTPUT`
- `ksql-cli` for debugging
- Producers
  - `test-producer` sends 1000 messages to kafka `test` topic
  - `ksql-producer` reads Sample.CSV converts to , and sends to kafka `KSQL_INPUT` topic
- Consumers
  - `test-consumer` listens to `test` topic and outputs messages to console
  - `ksql-consumer` queries messages from kafka topic `KSQL_OUTPUT` to console





Clean and start again
```
./dev-scripts/clean-and-start-again.sh
```


Change queries in ksql-queries and run
```
./dev-scripts/run-queries.sh
```


Change queries in interactive manner
```
./dev-scripts/ksql-cli.sh
```

Keeping docker status on screen
```
./dev-scripts/docker-stats.sh
```