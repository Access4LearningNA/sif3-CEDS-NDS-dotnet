

using SIF.NDSDataModel;
using System.Data.SqlClient;
using System.Data;
namespace Sif.NdsProvider.Services.Commons
{
    public static class CommonMethods
    {
         public static string GetCodesetCode(string tableName,string idColumn,string codeSet)
        {
            string result = null;
            using (var _context = new CEDSContext())
            {

                using (var connection = new SqlConnection(_context.Database.Connection.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SIF.USP_GetIdValueByCode";
                        cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50).Value = tableName;
                        cmd.Parameters.Add("@CodeColumn", SqlDbType.VarChar, 50).Value = "Description";
                        cmd.Parameters.Add("@IdColumn", SqlDbType.VarChar, 50).Value = idColumn;
                        cmd.Parameters.Add("@CodeValue", SqlDbType.VarChar, 50).Value = codeSet;
                        SqlParameter p1 = new SqlParameter("retValue", SqlDbType.Int);
                        p1.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(p1);
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {

                                string value = rdr.GetString(rdr.GetOrdinal(idColumn));

                            }
                            rdr.Close();
                        }


                        result = (cmd.Parameters["retValue"].Value).ToString();
                        return result;
                    }
                }
            }
                
        }
    }
}
