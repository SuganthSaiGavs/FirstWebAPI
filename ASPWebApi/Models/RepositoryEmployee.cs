using Microsoft.EntityFrameworkCore;

namespace ASPWebApi.Models
{
    public class RepositoryEmployee
    {
        private readonly NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)  //Constructor based dependency injection.
        {
            _context = context;
        }

        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee FindEmployeeById(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            // Find the employee by their EmployeeId.
            var employeeToDelete = _context.Employees.Find(employeeId);
            if (employeeToDelete != null)
            {
                // Remove the employee from the context and delete it from the database.
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges(); // Save changes to the database.
            }
            else
            {
                Console.WriteLine("Employee not Found to delete");
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            Console.WriteLine(_context.Entry(employee).State);
            _context.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee updateEmployee)
        {

            _context.Employees.Update(updateEmployee);
            Console.WriteLine(_context.Entry(updateEmployee).State);
            _context.SaveChanges();
            return updateEmployee;
        }


    }
}
