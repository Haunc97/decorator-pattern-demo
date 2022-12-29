using Decorator.Pattern.Employee;

var permanentemployeeConcrete = new EmployeeConcrete
{
    FirstName = "Prasad",
    LastName = "Raveendran",
    Address = "Isline, US"
};
var employeeDecorator = new PermanentEmployeeDecorator(permanentemployeeConcrete);
Console.WriteLine(employeeDecorator.Display());

var contractemployeeConcrete = new EmployeeConcrete
{
    FirstName = "Praveen",
    LastName = "Raveendran",
    Address = "Houston, US"
};
var conemployeeDecorator = new ContractEmployeeDecorator(contractemployeeConcrete);
Console.WriteLine(conemployeeDecorator.Display());
Console.Read();