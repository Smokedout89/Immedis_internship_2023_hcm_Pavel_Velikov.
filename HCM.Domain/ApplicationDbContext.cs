namespace HCM.Domain;

using PostgresModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddUserSecrets<ApplicationDbContext>();

        IConfiguration configuration = configurationBuilder.Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(connectionString!);
        }
    }

    public virtual DbSet<AddressDb> Addresses { get; set; } = null!;
    public virtual DbSet<CourseDb> Courses { get; set; } = null!;
    public virtual DbSet<DepartmentDb> Departments { get; set; } = null!;
    public virtual DbSet<EmployeeDb> Employees { get; set; } = null!;
    public virtual DbSet<EmployeeCourseDb> EmployeeCourses { get; set; } = null!;
    public virtual DbSet<LeaveRequestDb> LeaveRequests { get; set; } = null!;
    public virtual DbSet<RoleDb> Roles { get; set; } = null!;
    public virtual DbSet<SalaryDb> Salaries { get; set; } = null!;
    public virtual DbSet<TownDb> Towns { get; set; } = null!;
    public virtual DbSet<UserDb> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeCourseDb>(e =>
        {
            e.HasKey(ec => new { ec.EmployeeId, ec.CourseId });
        });
    }
}