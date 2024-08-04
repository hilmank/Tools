# Tools
This console application was built with .Net and C# language
## 1. Migration CSV to PostgreSQL
This tool is an example to migrate data from a csv file into a postgreSQL database. I use the PostgreSQLCopyHelper library for the data bulk insert process.
- read cvs file (sample data can use from https://www.datablist.com/learn/csv/download-sample-csv-files). In this sample I user data customer
- convert linestring to class
- bulk insert use PostgreSQLCopyHelper
note: for data with date type there is still a problem 