#!/bin/bash
# entrypoint.sh

# Start SQL Server
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start
sleep 30

# Run the SQL script
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "${SA_PASSWORD}" -C -i /docker-entrypoint-initdb.d/init.sql


# Wait for the SQL Server process to exit
wait