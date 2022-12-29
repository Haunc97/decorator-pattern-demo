namespace Decorator.Pattern.Employee
{
    public class ContractEmployeeDecorator : EmployeeDecorator 
    {
        //Add properties relevant to a contract employee  
        private double RatePerHour { get; set; }
        public ContractEmployeeDecorator(Employee employee) : base(employee) { }
        public override string Display()
        {
            return base.Display() + "\nEmployee type: Contractual";
        }
    }
}