using EmployeeClass.Model;

namespace EmployeeClass.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployee(byte DepartmentId = 0);

        Task<Employee> GetEmployeeById(int id);

        Task<bool> isValid(byte id);

        Task<IEnumerable<Employee>> GetEmployeeByName(string name);

        Task<Employee> AddEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        Employee DeleteEmployee(Employee employee);

    }
}
