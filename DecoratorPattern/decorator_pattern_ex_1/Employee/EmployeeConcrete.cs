using System.Text;

namespace Decorator.Pattern.Employee
{
    public class EmployeeConcrete : Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public override string Display()
        {
            StringBuilder data = new();
            data.Append("First name: " + FirstName);
            data.Append("\nLast name: " + LastName);
            data.Append("\nAddress: " + Address);
            return data.ToString();
        }
    }
}
