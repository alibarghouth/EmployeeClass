using EmployeeClass.Dto.BaseDatabase;

namespace EmployeeClass.Dto
{
    public class EmployeeUpdateDto : BaseDatabaseUpdate
    {
        public IFormFile? MyImg { get; set; }

        public IFormFile? MyVideo { get; set; }


        public byte DepartmentId { get; set; }
    }
}
