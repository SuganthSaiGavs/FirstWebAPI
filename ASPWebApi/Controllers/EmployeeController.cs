using ASPWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  RepositoryEmployee _repositoryEmployee;

        public EmployeeController(RepositoryEmployee employeeRepository)
        {
            _repositoryEmployee = employeeRepository;
        }
/*
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return _repositoryEmployee.AllEmployees();
        }*/

        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> AllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            var emplist = (from emp in employees
                           select new EmpViewModel()
                           {
                               EmpId = emp.EmployeeId,
                               FirstName = emp.FirstName,
                               LastName = emp.LastName,
                               BirthDate = emp.BirthDate,
                               HireDate = emp.HireDate,
                               Title = emp.Title,
                               City = emp.City,
                               ReportsTo = emp.ReportsTo
                           }
                ).ToList();
            return emplist;

        }

        [HttpGet("id")]
        public Employee EmployeeDetails(int id)
        {
            //Customer customer = _repositoryCustomers.FindCustomerById(id);
            //return View(customer);
            Employee employees = _repositoryEmployee.FindEmployeeById(id);
            return employees;
        }

/*        [HttpDelete("id")]
        public int DeleteEmployee(int id)
        {
            // Call the repository to delete the employee.
            _repositoryEmployee.DeleteEmployee(id);

            // Return a success response or an appropriate status code.
            return id; // HTTP 204 No Content is a common response for successful deletions.
        }*/

        [HttpDelete("/DeleteEmployee/{id}")]
        public int DeleteEmployee(int id)
        {
            // Call the repository to delete the employee.
            _repositoryEmployee.DeleteEmployee1(id);

            // Return a success response or an appropriate status code.
            return id; // HTTP 204 No Content is a common response for successful deletions.
        }



        /*        [HttpPost]
                public Employee PostEmployee([FromBody] Employee newEmployee)
                {
                    return _repositoryEmployee.AddEmployee(newEmployee);
                }*/
        [HttpPost("/AddNewEmployee")]
        public int CreateEmployee(EmpViewModel newEmployee)
        {
            /*_repositoryEmployee.AddEmployee(newEmployee); 
            return newEmployee;*/
            Employee emp = new Employee()
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                BirthDate = newEmployee.BirthDate,
                HireDate = newEmployee.HireDate,
                Title = newEmployee.Title,
                City = newEmployee.City,
                ReportsTo = newEmployee.ReportsTo > 0 ? newEmployee.ReportsTo : null
            };
            int result = _repositoryEmployee.AddEmployee(emp);
            return result;
        }

        /*        [HttpPut("id")]
                public Employee UpdateEmployee(int id, [FromBody] Employee updateEmployee)
                {
                    updateEmployee.EmployeeId = id;
                    Employee saveEmployee = _repositoryEmployee.UpdateEmployee(updateEmployee);
                    return saveEmployee;
                }*/

        [HttpPut("/UpdateEmployee")]
        public int UpdateEmployee( [FromBody] EmpViewModel updateEmployee)
        {
            //updateEmployee.EmployeeId = id;
            Employee employee = new Employee() 
            {
                EmployeeId=updateEmployee.EmpId, FirstName = updateEmployee.FirstName, LastName = updateEmployee.LastName,
                BirthDate = updateEmployee.BirthDate,HireDate = updateEmployee.HireDate,City = updateEmployee.City,
                ReportsTo = updateEmployee.ReportsTo,   Title = updateEmployee.Title
            };
            int result = _repositoryEmployee.UpdateEmployee1(employee);
            return result;
        }


    }
}
