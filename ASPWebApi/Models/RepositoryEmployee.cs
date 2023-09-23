using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

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

/*        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            Console.WriteLine(_context.Entry(employee).State);
            _context.SaveChanges();
            return employee;
        }*/

        public int AddEmployee(Employee newEmployee)
        {
            Employee? foundEmp = _context.Employees.Find(newEmployee.EmployeeId);

            if (foundEmp != null)
            {
                throw new Exception("Failed to add employee. duplicate Id");
            }
            EntityState es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState Before Add:{ es.GetDisplayName()}");

            _context.Employees.Add(newEmployee);
            es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");

            int result=_context.SaveChanges();
            es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState After SaveChanges:{es.GetDisplayName()}");
            return result;
        }

        public Employee UpdateEmployee(Employee updateEmployee)
        {

            _context.Employees.Update(updateEmployee);
            Console.WriteLine(_context.Entry(updateEmployee).State);
            _context.SaveChanges();
            return updateEmployee;
        }

        public int UpdateEmployee1(Employee updatedEmployee)
        {
            EntityState es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState before Update:{es.GetDisplayName()}");
            _context.Employees.Update(updatedEmployee);
            // Console.WriteLine(_context.Entry(updatedEmployee).State); //
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After Update:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After Save Changes:{es.GetDisplayName()}");
            return result;
        }

        public int DeleteEmployee1(int id)
        {
            Employee empdelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empdelete != null)
            {
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState before Delete:{es.GetDisplayName()}");
                _context.Employees.Remove(empdelete);//dbcontext.entity."add" used to attach
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Delete:{es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Save changes:{es.GetDisplayName()}");
            }
            return result;
        }




    }
}
