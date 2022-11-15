using EmployeeClass.Model;

namespace EmployeeClass.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartment();

        Task<Department> GetDepartmentById(byte Id);

        Task<Department> PostDepartment(Department department);

        Department UpdateDepartment(Department department);

        Department DeleteDepartment(Department department);

        Task<bool> isValid(byte depId);
    }
}
