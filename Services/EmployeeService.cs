using EmployeeClass.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeClass.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeeService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee(byte DepartmentId = 0)
        {
            return await _dbContext.Employees
                .Where(e => e.DepartmentId == DepartmentId || DepartmentId == 0) 
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByName(string name)
        {
            return await _dbContext.Employees.Where(c => c.Name == name).ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
             await _dbContext.Employees.AddAsync(employee);

            _dbContext.SaveChanges();
            
            return employee;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _dbContext.Update(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public async Task<bool> isValid(byte id)
        {
            var isvalid =await _dbContext.Employees.AnyAsync(c => c.DepartmentId == id);

            return isvalid;
        }
    }
}
