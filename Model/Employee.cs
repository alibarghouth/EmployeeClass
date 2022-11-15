namespace EmployeeClass.Model
{
    public class Employee
    {
        public  int Id { get; set; }

        public  string Name { get; set; }

        public  string Email { get; set; }

        public  string gender { get; set; }

        public  string Number { get; set; }

        public  byte[] MyImg { get; set; }

        public  byte[] MyVideo { get; set; }


        public  byte DepartmentId { get; set; }

        public  Department Department { get; set; }
    }
}
