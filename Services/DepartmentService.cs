using EmployeeClass.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeClass.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDBContext context;

        public DepartmentService(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await context.Departments.ToListAsync();
        }


        public Department DeleteDepartment(Department department)
        {
            context.Departments.Remove(department);

            context.SaveChanges();

            return department;
        }

        

        public async Task<Department> GetDepartmentById(byte Id)
        {
            return await context.Departments.SingleOrDefaultAsync(c =>c.Id == Id);
        }

        public async Task<Department> PostDepartment(Department department)
        {
            await context.Departments.AddAsync(department);

            context.SaveChanges();

            return department;
        }

        public Department UpdateDepartment(Department department)
        {
            context.Departments.Update(department);

            context.SaveChanges();

            return department;
        }

        public Task<bool> isValid(byte depId)
        {
            return context.Departments.AnyAsync(x => x.Id == depId);
        }
    }
}
