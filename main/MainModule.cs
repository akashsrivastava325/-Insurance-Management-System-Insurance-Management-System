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
            InsuranceServiceImpl insuranceService = new InsuranceServiceImpl();

            while (true)
            {
                Console.WriteLine("Insurance Management System");
                Console.WriteLine("1. Get Policy Details");
                Console.WriteLine("2. Create Policy");
                Console.WriteLine("3. Update Policy");
                Console.WriteLine("4. Delete Policy");
                Console.WriteLine("5. All Policy List");
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
                    case "5":
                        GetAllPolicies(insuranceService);
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

            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine()); 
            Console.Write("Enter Policy Number: ");
            string policyNumber = Console.ReadLine();
            Console.Write("Enter Coverage Details: ");
            string coverageDetails = Console.ReadLine();


            Policy newPolicy = new Policy
            {
                PolicyId = policyId,
                PolicyNumber = policyNumber,
                CoverageDetails = coverageDetails

            };


            bool createResult = insuranceService.CreatePolicy(newPolicy);
            Console.WriteLine($"CreatePolicy result: {createResult}");
        }

        static void UpdatePolicy(InsuranceServiceImpl insuranceService)
        {
            Console.Write("Enter Policy ID to Update: ");

            if (int.TryParse(Console.ReadLine(), out int policyIdToUpdate))
            {
                Console.Write("Enter Updated Policy Number: ");
                string updatedPolicyNumber = Console.ReadLine();

                Console.Write("Enter Updated Coverage Details: ");
                string updatedCoverageDetails = Console.ReadLine();

                Policy updatedPolicy = new Policy
                {
                    PolicyId = policyIdToUpdate,
                    PolicyNumber = updatedPolicyNumber,
                    CoverageDetails = updatedCoverageDetails
                };


                bool updateResult = insuranceService.UpdatePolicy(updatedPolicy);

                if (updateResult)
                {
                    Console.WriteLine("Policy updated successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to update policy. Please check the inputs and try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
            }
        }


        static void DeletePolicy(InsuranceServiceImpl insuranceService)
        {
            Console.Write("Enter Policy ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int policyIdToDelete))
            {
                bool deleteResult = insuranceService.DeletePolicy(policyIdToDelete);
                Console.WriteLine($"DeletePolicy result: {deleteResult}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
            }
        }
        static void GetAllPolicies(InsuranceServiceImpl insuranceService)
        {
            IEnumerable<Policy> policies = insuranceService.getAllPolicies();

            Console.WriteLine("All Policies:");
            foreach (var policy in policies)
            {
                Console.WriteLine(policy);
            }
        }
    }
}