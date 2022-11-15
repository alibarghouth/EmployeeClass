using EmployeeClass.Dto.BaseDatabase;

namespace EmployeeClass.Dto
{

    public class AllDetails : BaseDataBaseCreate
    {
        public int Id { get; set; }
        public byte[] MyImg { get; set; }

        public byte[] MyVideo { get; set; }

        public byte DepartmentId { get; set; }


        public string DeparmentName { get; set; }



        public string DeparmentDescreption { get; set; }

    }
}
