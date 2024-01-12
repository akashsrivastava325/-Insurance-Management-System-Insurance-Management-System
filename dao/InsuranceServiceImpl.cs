using InsuranceAssignment.entity;
using InsuranceAssignment.MyExceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceAssignment.util;

namespace InsuranceAssignment.dao
{
    public class InsuranceServiceImpl : IPolicyService
    {
        private string connectionString = "Data Source=DESKTOP-G6RG569\\SQLEXPRESS;Initial Catalog=InsuranceManagementSystem;Integrated Security=True;TrustServerCertificate=True"; // Your database connection string
        public SqlConnection connectionValue = DBConnection.GetConnection();

        public InsuranceServiceImpl(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public InsuranceServiceImpl()
        {
        }

        public bool CreatePolicy(Policy Policy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Policy (PolicyId, PolicyNumber, CoverageDetails) VALUES (@PolicyId, @PolicyNumber, @CoverageDetails)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@PolicyId", Policy.PolicyId);
                        command.Parameters.AddWithValue("@PolicyNumber", Policy.PolicyNumber);
                        command.Parameters.AddWithValue("@CoverageDetails", Policy.CoverageDetails);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating policy: {ex.Message}");
                    return false;
                }
            }
        }

    public Policy GetPolicy(int policyId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
                connection.Open();

                string selectQuery = "SELECT * FROM Policy WHERE PolicyId = @PolicyId";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@PolicyId", policyId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Policy policy = new Policy
                            {
                                PolicyId = (int)reader["PolicyId"],
                                PolicyNumber = reader["PolicyNumber"].ToString(),
                                CoverageDetails = reader["CoverageDetails"].ToString()
                            };

                            return policy;
                        }
                        else
                        {
                            // Policy not found, throw PolicyNotFoundException
                            throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
                        }
                    }
                }
        }
    }


        public IEnumerable<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectAllQuery = "SELECT PolicyId, PolicyNumber, CoverageDetails FROM Policy";

                    using (SqlCommand command = new SqlCommand(selectAllQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Retrieve values from the database
                                int retrievedPolicyId = reader.GetInt32(reader.GetOrdinal("PolicyId"));
                                string retrievedPolicyNumber = reader.GetString(reader.GetOrdinal("PolicyNumber"));
                                string retrievedCoverageDetails = reader.GetString(reader.GetOrdinal("CoverageDetails"));

                                // Create Policy objects and add to the list
                                policies.Add(new Policy(retrievedPolicyId, retrievedPolicyNumber, retrievedCoverageDetails));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting all policies: {ex.Message}");
                }
            }

            return policies;
        }


        public bool UpdatePolicy(Policy policy)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE Policy SET PolicyNumber = @PolicyNumber, CoverageDetails = @CoverageDetails WHERE PolicyId = @PolicyId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                        command.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                        command.Parameters.AddWithValue("@CoverageDetails", policy.CoverageDetails);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating policy: {ex.Message}");
                    return false;
                }
            }
        }


        public bool DeletePolicy(int policyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Policy WHERE PolicyId = @PolicyId";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Add parameter to the query
                        command.Parameters.AddWithValue("@PolicyId", policyId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting policy: {ex.Message}");
                    return false;
                }
            }
        }
        public IEnumerable<Policy> getAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectAllQuery = "SELECT PolicyId, PolicyNumber, CoverageDetails FROM Policy";

                    using (SqlCommand command = new SqlCommand(selectAllQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Retrieve values from the database
                                int retrievedPolicyId = reader.GetInt32(reader.GetOrdinal("PolicyId"));
                                string retrievedPolicyNumber = reader.GetString(reader.GetOrdinal("PolicyNumber"));
                                string retrievedCoverageDetails = reader.GetString(reader.GetOrdinal("CoverageDetails"));

                                // Create Policy objects and add to the list
                                policies.Add(new Policy(retrievedPolicyId, retrievedPolicyNumber, retrievedCoverageDetails));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting all policies: {ex.Message}");
                }
            }

            return policies;
        }
    }
}
