#!/bin/sh

# need to test
DATABASE_FILE="$DATABASE_FILE_PATH"

if [ -z "$DB_FILE_PATH"]; then
    echo "DB_FILE_PATH is null"
    exit 1
fi

PIDS=$(lsof -t "$DB_FILE_PATH")

if [ -z "$PIDS" ]; then
    echo "not procces $DB_FILE_PATH"
    exit 0
fi

for PID in $PIDS; do
    kill $PID
done

echo "closed procces $DB_FILE_PATH"