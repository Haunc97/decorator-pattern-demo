namespace Decorator.Pattern.Employee
{
    public class PermanentEmployeeDecorator : EmployeeDecorator
    {
        //Add properties relevant to a permanent employee  
        private double PF { get; set; }
        public PermanentEmployeeDecorator(Employee employee) : base(employee) { }
        public override string Display()
        {
            return base.Display() + "\nEmployee type: Permanent";
        }
    }
}