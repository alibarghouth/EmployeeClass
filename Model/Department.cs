using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeClass.Model
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public   byte Id { get; set; }

        public  string Name { get; set; }
        
        public  string Descreption { get; set; }


        public  List<Employee> Employees { get; set; }

    }
}
