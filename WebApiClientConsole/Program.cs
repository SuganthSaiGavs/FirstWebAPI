using ASPWebApi.Models;
using WebApiClientConsole;

Console.WriteLine("API CLIENT");
//EmployeeAPIClient.CallGetAllEmployee().Wait();
/*Console.WriteLine();
EmployeeAPIClient.GetAllEmployeeJson().Wait();
Console.WriteLine();
EmployeeAPIClient.AddnewEmployee().Wait();
Console.WriteLine();*/

/*EmpViewModel employeeToUpdate = new EmpViewModel()
{
    EmpId=20,
    FirstName = "Update",
    LastName = "Update",
    City = "Nyc",
    BirthDate = new DateTime(1980, 01, 01),
    HireDate = new DateTime(2000, 01, 01),
    Title = "Manager"

};

EmployeeAPIClient.UpdateEmployee(20, employeeToUpdate).Wait();*/

EmployeeAPIClient.DeleteEmployee(21).Wait();