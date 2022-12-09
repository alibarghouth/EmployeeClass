using Microsoft.EntityFrameworkCore;

namespace EmployeeClass.Model
{


    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {

        }

        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<Department> Departments { get; set; }
    }
}
