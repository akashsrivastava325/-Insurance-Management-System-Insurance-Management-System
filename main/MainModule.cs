using InsuranceAssignment.dao;
using InsuranceAssignment.entity;
using InsuranceAssignment.MyExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.MainMod
{
    public class MainModule
    {
        static void Main()
        {
            // Create an instance of InsuranceServiceImpl
            InsuranceServiceImpl insuranceService = new InsuranceServiceImpl();

            // Display menu options to the user
            while (true)
            {
                Console.WriteLine("Insurance Management System");
                Console.WriteLine("1. Get Policy Details");
                Console.WriteLine("2. Create Policy");
                Console.WriteLine("3. Update Policy");
                Console.WriteLine("4. Delete Policy");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetPolicyDetails(insuranceService);
                        break;
                    case "2":
                        CreatePolicy(insuranceService);
                        break;
                    case "3":
                        UpdatePolicy(insuranceService);
                        break;
                    case "4":
                        DeletePolicy(insuranceService);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void GetPolicyDetails(InsuranceServiceImpl insuranceService)
        {
            Console.Write("Enter Policy ID: ");
            if (int.TryParse(Console.ReadLine(), out int policyId))
            {
                try
                {
                    Policy policy = insuranceService.GetPolicy(policyId);
                    if (policy != null)
                    {
                        Console.WriteLine($"Policy details: {policy}");
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine($"PolicyNotFoundException: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
            }
        }

        static void CreatePolicy(InsuranceServiceImpl insuranceService)
        {
            // Collect information to create a new policy
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine()); // Assuming Policy ID is an integer
            Console.Write("Enter Policy Number: ");
            string policyNumber = Console.ReadLine();
            Console.Write("Enter Coverage Details: ");
            string coverageDetails = Console.ReadLine();

            // Create a new Policy object
            Policy newPolicy = new Policy
            {
                PolicyId = policyId,
                PolicyNumber = policyNumber,
                CoverageDetails = coverageDetails
                // Include other properties as needed
            };

            // Call the CreatePolicy method
            bool createResult = insuranceService.CreatePolicy(newPolicy);
            Console.WriteLine($"CreatePolicy result: {createResult}");
        }

        static void UpdatePolicy(InsuranceServiceImpl insuranceService)
        {
            // Collect information to update an existing policy
            Console.Write("Enter Policy ID to Update: ");
            int policyIdToUpdate = int.Parse(Console.ReadLine()); // Assuming Policy ID is an integer

            // Assume you have an updated Policy object for testing purposes
            Policy updatedPolicy = new Policy
            {
                PolicyId = policyIdToUpdate,
                PolicyNumber = "UpdatedPolicyNumber",
                CoverageDetails = "UpdatedCoverageDetails"
                // Include other properties as needed
            };

            // Call the UpdatePolicy method
            bool updateResult = insuranceService.UpdatePolicy(updatedPolicy);
            Console.WriteLine($"UpdatePolicy result: {updateResult}");
        }

        static void DeletePolicy(InsuranceServiceImpl insuranceService)
        {
            Console.Write("Enter Policy ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int policyIdToDelete))
            {
                // Call the DeletePolicy method
                bool deleteResult = insuranceService.DeletePolicy(policyIdToDelete);
                Console.WriteLine($"DeletePolicy result: {deleteResult}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
            }
        }
    }
}