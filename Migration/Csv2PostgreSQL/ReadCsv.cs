using System;
using System.Globalization;
using Npgsql;
using PostgreSQLCopyHelper;

namespace Migration.Csv2PostgreSQL;

public class ReadCsv
{
    public static void Read()
    {
        List<Customer> customers = [];
        using var reader = new StreamReader("[path]/[filename]");
        // Skip the header line
        Console.WriteLine(DateTime.Now.ToString());
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            string[] splitLine = line.Split(',');
            int i = 0;
            Customer customer = new();
            customer.Index = int.Parse(splitLine[i].Trim());
            customer.CustomerId = splitLine[++i].Trim();
            customer.FirstName = splitLine[++i].Trim();
            customer.LastName = splitLine[++i].Trim();
            customer.Company = splitLine[++i].Trim();
            customer.City = splitLine[++i].Trim();
            customer.Country = splitLine[++i].Trim();
            customer.Phone1 = splitLine[++i].Trim();
            customer.Phone2 = splitLine[++i].Trim();
            customer.Email = splitLine[++i].Trim();
            if (DateTime.TryParse(splitLine[++i].Trim(), CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime date))
            {
                customer.SubscriptionDate = date;
            }

            customer.Website = splitLine[++i].Trim();
            customers.Add(customer);
        }
        Console.WriteLine(DateTime.Now.ToString());
        Console.WriteLine(customers.Count);
        Insert(customers);
    }
    private static void Insert(List<Customer> customers)
    {
        var customer = new PostgreSQLCopyHelper<Customer>("public", "customer")
            .MapInteger("index", x => x.Index)
            .MapText("customer_id   ", x => x.CustomerId)
            .MapText("first_name", x => x.FirstName)
            .MapText("last_name", x => x.LastName)
            .MapText("company", x => x.Company)
            .MapText("city", x => x.City)
            .MapText("country", x => x.Country)
            .MapText("phone_1", x => x.Phone1)
            .MapText("phone_2", x => x.Phone2)
            .MapText("email", x => x.Email)
            //.MapDate("subscription_date", x => x.SubscriptionDate)
            .MapText("website", x => x.Website)
        ;

        using var connection = new NpgsqlConnection("Server=[hostname];Port=[portnumber];Database=[dbname];User Id=[username];Password=[password];CommandTimeout=600;Pooling=false");
        connection.Open();
        Console.WriteLine("insert customers");
        customer.SaveAll(connection, customers);
        Console.WriteLine(DateTime.Now.ToString());
    }
}
