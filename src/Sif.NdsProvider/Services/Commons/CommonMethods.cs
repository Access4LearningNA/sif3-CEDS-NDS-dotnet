

using SIF.NDSDataModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Sif.NdsProvider.Services.Commons
{
    public static class CommonMethods
    {
         public static string GetCodesetCode(string tableName,string idColumn, string CodeColumn,string codeSet)
        {
            string result = null;
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();

            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (var _context = new CEDSContext(optionsBuilder.Options))
            {
                
                using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SIF.USP_GetIdValueByCode";
                        cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50).Value = tableName;
                        cmd.Parameters.Add("@CodeColumn", SqlDbType.VarChar, 50).Value = CodeColumn;
                        cmd.Parameters.Add("@IdColumn", SqlDbType.VarChar, 50).Value = idColumn;
                        cmd.Parameters.Add("@CodeValue", SqlDbType.VarChar, 50).Value = codeSet;
                        SqlParameter p1 = new SqlParameter("retValue", SqlDbType.Int);
                        p1.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(p1);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                 result = rdr[idColumn].ToString();

                            }
                            rdr.Close();
                        }

                        
                        return result;
                    }
                }
            }
                
        }
        public static DbContextOptions<CEDSContext> GetConncetionString()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CEDSContext>();
            optionsBuilder.UseSqlServer("Server=10.10.1.219;Database=CEDS_NDS;User Id=SIFNDSAdmin;password=admin#123;MultipleActiveResultSets=true;App=EntityFramework");
            return optionsBuilder.Options;
        }
       
    }
}
