using System;
using System.Configuration;

namespace InsuranceAssignment.Util
{
    public class PropertyUtil
    {
        public static string GetConnectionString()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["InsuranceManagementSystemConnectionString"].ConnectionString;
                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading connection string from configuration: {ex.Message}");
                return null;
            }
        }
    }
}
