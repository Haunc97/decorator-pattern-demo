namespace Decorator.Pattern.Employee
{
    public class EmployeeDecorator : Employee
    {
        Employee _employee = null;
        public EmployeeDecorator(Employee employee)
        {
            _employee = employee;
        }
        public override string Display()
        {
            return _employee.Display();
        }
    }
}