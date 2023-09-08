namespace iBOS_Assignment.API.Dtos
{
    public class EmployeeDto
    {
        public long EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeCode { get; set; }

        public int EmployeeSalary { get; set; }

        public long? SupervisorId { get; set; }
    }
}
