using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UIFramework.Database
{
  public static class DatabaseMethods
  {
    private const string connectionString = @"Server=.\SQLEXPRESS;Database=Bank;Trusted_Connection=True;";

    public static DbResponse AddRowToDatabase(string tableName, List<KeyValuePair<string, string>> keyValuePairs = null)
    {
      var errors = new List<string>();
      var valueLength = keyValuePairs.Count;

      //add row to database
      using (var connection = new SqlConnection(connectionString))
      {
        var stringBuilder = new StringBuilder("INSERT INTO @tableName (");
        for (int i = 0; i < valueLength; i++)
        {
          var columnName = keyValuePairs[i].Key;
          stringBuilder.Append($"@{columnName}");
          if (i < valueLength - 1)
            stringBuilder.Append(", ");
        }

        stringBuilder.Append(") VALUES(");

        for (int i = 0; i < valueLength; i++)
        {
          stringBuilder.Append($"@{keyValuePairs[i].Value}");
          if (i < valueLength - 1)
            stringBuilder.Append(", ");
        }

        stringBuilder.Append(");");

        var command = new SqlCommand(stringBuilder.ToString(), connection);

        //add parameters to query
        for (int i = 0; i < valueLength; i++)
          command.Parameters.AddWithValue($"@{keyValuePairs[i].Key}", keyValuePairs[i].Value);

        try
        {
          connection.Open();
          command.ExecuteNonQuery();
        }
        catch (SqlException sqe)
        {
          foreach (SqlError error in sqe.Errors)
            errors.Add(error.Message);
        }
        catch (Exception ex)
        {
          errors.Add(ex.Message);
        }
        finally
        {
          connection.Close();
        }
      }
      return new DbResponse(errors.Count == 0, errors.ToArray());
    }
  }

  public class DbResponse
  {
    public bool Successful { get; set; }
    public string[] Errors { get; set; }

    public DbResponse() { }

    public DbResponse(bool successful, string[] errors)
    {
      Successful = successful;
      Errors = errors;
    }
  }
}
