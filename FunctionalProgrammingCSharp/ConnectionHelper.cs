using System.Data;
using System.Data.SqlClient;

namespace FunctionalProgrammingCSharp;

public  class ConnectionHelper
{
    // public static R Connect<R>(string connString, Func<IDbConnection, R> f)
    // {
    //     using (var connection= new SqlConnection(connString))
    //     {
    //         connection.Open();
    //         return f(connection);
    //     }
    // }
}