using System.Data;
using System.Data.SqlClient;

namespace ado.net1;

public class SQLHelper
{
    const string CONNECTION_STRING = "Server=DESKTOP-N5N9E4H\\SQLEXPRESS;Database=AdoNetTask;Trusted_Connection=True;TrustServerCertificate=True";
    static SqlConnection _sqlconnection = null;

    public static SqlConnection SqlConnection
    {
        get
        {
            if (_sqlconnection == null)
            {
                _sqlconnection = new SqlConnection(CONNECTION_STRING);
            }
            return _sqlconnection;
        }
    }

    public static DataTable ReadAll(string command)
    {
        SqlConnection.Open();
        DataTable dataTable = new DataTable();
        using (SqlDataAdapter adapter = new SqlDataAdapter(command, SqlConnection))
        {
            adapter.Fill(dataTable);
        }
        SqlConnection.Close();
        return dataTable;
    }
}

