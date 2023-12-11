using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthManual.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Gender { get; set; }
        
        public string city { get; set; }
        
        public bool IsActive { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee {Id = 1, FirstName = "Vivek", LastName = "Shah", city = "Kitchener", Gender="Male", IsActive=true},
                new Employee {Id = 2, FirstName = "Meet", LastName = "Patel", city = "Brmapton", Gender="Male", IsActive = true},
                new Employee {Id = 3, FirstName = "Ishita", LastName = "Patel", city = "Kitchener", Gender="Female", IsActive=true},
                new Employee {Id = 2, FirstName = "Krishna", LastName = "Satani", city = "Waterloo", Gender="Female", IsActive = true},
                new Employee {Id = 1, FirstName = "Harsh", LastName = "Patel", city = "Kitchener", Gender="Male", IsActive=true},
            };
            return employees;
        }
    }
}