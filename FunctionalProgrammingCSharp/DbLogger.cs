using System.Data;

namespace FunctionalProgrammingCSharp;
using Dapper;
public class DbLogger
{
    private string connectionString;
    // public void Log(LogMessage msg)
    // {
    //     using (var connection= new Dapp)
    //     {
    //         
    //     }
    // }
    // public void Log(LogMessage message) => Connect(connectionString, c => c.Execute("sp_create_log", message, CommandType: CommandType.StoredProcedure));
    //
    // private string sql = @"Select * from [Logs] where [timestamp] > @since";
    //
    // public IEnumerable<LogMessage> GetLogs(DateTime since) => Connect(connectionString, c => c.Query<LogMessage>(sql, new { since= since }));
}

