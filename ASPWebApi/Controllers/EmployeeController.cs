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

        [HttpGet]
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

        [HttpDelete("id")]
        public int DeleteEmployee(int id)
        {
            // Call the repository to delete the employee.
            _repositoryEmployee.DeleteEmployee(id);

            // Return a success response or an appropriate status code.
            return id; // HTTP 204 No Content is a common response for successful deletions.
        }

        [HttpPost]
        public Employee PostEmployee([FromBody] Employee newEmployee)
        {
            return _repositoryEmployee.AddEmployee(newEmployee);
        }

        [HttpPut("id")]
        public Employee UpdateEmployee(int id, [FromBody] Employee updateEmployee)
        {
            updateEmployee.EmployeeId = id;
            Employee saveEmployee = _repositoryEmployee.UpdateEmployee(updateEmployee);
            return saveEmployee;
        }

    }
}
