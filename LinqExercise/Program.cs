using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine($"The average of numbers is {numbers.Average()}");
            Console.WriteLine($"The sum of numbers is {numbers.Sum()}");

            //Order numbers in ascending order and decsending order. Print each to console.

            Console.WriteLine("\nAscending:");
            var asc = numbers.OrderBy(x => x);
            foreach(int i in asc)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nDescending:");
            var desc = numbers.OrderByDescending(x => x);
            foreach (int x in desc)
            {
                Console.WriteLine(x);
            }

            //Print to the console only the numbers greater than 6

            Console.WriteLine("\nFiltered over 6:");
            var filtered = numbers.Where(x => x > 6);
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("\nFirst four:");
            var aFew = numbers.Take(4);
            foreach (int x in aFew)
            {
                Console.WriteLine(x);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("\nDescending with age added:");
            numbers[4] = 33;
            var aged = numbers.OrderByDescending(x => x);
            foreach (int x in aged)
            {
                Console.WriteLine(x);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            Console.WriteLine("\nAll C or S employees ordered by first name:");
            var csEmployees = employees.Where(x => x.FirstName[0] == 'C'|| x.FirstName[0] == 'S').OrderByDescending(x => x.FirstName);
            foreach (var person in csEmployees)
            {
                Console.WriteLine(person.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("\nAll employees over 26 ordered by age and then name");
            var fullGrown = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var person in fullGrown)
            {
                Console.WriteLine(person.FullName);
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("\nSum and average of late comers:");
            var oldNewbies = from x in employees where x.YearsOfExperience < 10 where x.Age > 35 select x.YearsOfExperience;
            Console.WriteLine($"Sum is {oldNewbies.Sum()}");
            Console.WriteLine($"Average is {oldNewbies.Average()}");

            //Add an employee to the end of the list without using employees.Add()
            employees.Append(new Employee("Marcus", "Fenix", 52, 17));

            Console.WriteLine();

            Console.ReadKey();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
