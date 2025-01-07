// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class Program
    {
        public class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;  
            public int Age { get; set; }
            public string Gender { get; set; } = string.Empty;  
            public string Diagnosis { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Diagnosis: {Diagnosis}";
            }
        }


        static List<Patient> patients = new List<Patient>();
        static int nextPatientId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital Management System");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine()?.Trim() ?? "Unknown";

                switch (choice)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        ViewAllPatients();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting Hospital Management System...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }


        static void AddPatient()
        {
            Console.WriteLine("\nEnter Patient Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine()?.Trim() ?? "Unknown";

            Console.Write("Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine()?.Trim(), out age) || age <= 0)
            {
                Console.Write("Invalid input. Enter a valid positive age: ");
            }

            Console.Write("Gender: ");
            string gender = Console.ReadLine()?.Trim() ?? "Not Specified";

            Console.Write("Diagnosis: ");
            string diagnosis = Console.ReadLine()?.Trim() ?? "Not Specified";

            Patient newPatient = new Patient
            {
                Id = nextPatientId++,
                Name = name,
                Age = age,
                Gender = gender,
                Diagnosis = diagnosis
            };

            patients.Add(newPatient);
            Console.WriteLine("\nPatient added successfully!");
        }



        static void ViewAllPatients()
        {
            Console.WriteLine("\nAll Patients:");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient);
                }
            }
        }
    }
}
