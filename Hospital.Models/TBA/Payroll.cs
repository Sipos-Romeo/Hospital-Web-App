namespace Hospital.Models.TBA
{
    public class Payroll
    {
        public int Id { get; set; }
        public ApplicationUser EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal BonusSalary { get; set; }
        public decimal Compensation { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}