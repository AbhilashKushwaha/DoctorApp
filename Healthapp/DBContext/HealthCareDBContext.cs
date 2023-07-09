using Healthapp.Model;
using Microsoft.EntityFrameworkCore;

namespace Healthapp.DBContext
{
    public class HealthCareDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<HospitalType> HospitalType { get; set; }

        public HealthCareDBContext(DbContextOptions<HealthCareDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            modelBuilder.Entity<HospitalType>().ToTable("HospitalTypes");
            modelBuilder.Entity<Department>().ToTable("Departments");

            // Configure Primary Keys  
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");
            modelBuilder.Entity<Patient>().HasKey(u => u.Id).HasName("PK_Patients");
            modelBuilder.Entity<Hospital>().HasKey(u => u.Id).HasName("PK_Hospitals");
            modelBuilder.Entity<HospitalType>().HasKey(u => u.Id).HasName("PK_HospitalTypes");
            modelBuilder.Entity<Department>().HasKey(u => u.Id).HasName("PK_Departments");

            // Configure indexes  
            //modelBuilder.Entity<User>().HasIndex(u => u.firstName).HasDatabaseName("Idx_FirstName");
            //modelBuilder.Entity<User>().HasIndex(u => u.lastName).HasDatabaseName("Idx_LastName");

            // Configure columns  
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            modelBuilder.Entity<User>().Property(u => u.firstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.middleName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.lastName).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.userName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.password).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.emailId).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.phoneNumber).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.address).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.profilePicture).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.isDoctor).HasColumnType("tinyint").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.isActive).HasColumnType("tinyint").IsRequired();


            //----------Patients-----------//
            modelBuilder.Entity<Patient>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.firstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.nsid).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.middleName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.lastName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.dateOfBirth).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.gender).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.emailId).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.phoneNumber).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.address).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.profilePicture).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.updatedBy).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.createdBy).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.aadharNumber).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.zipcode).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.isActive).HasColumnType("tinyint").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.creationDateTime).HasColumnType("datetime(15)").IsRequired();
            modelBuilder.Entity<Patient>().Property(u => u.lastUpdateDateTime).HasColumnType("datetime(15)").IsRequired();

            //----------department-----------//
            modelBuilder.Entity<Department>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Department>().Property(u => u.code).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Department>().Property(u => u.deptartmentName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Department>().Property(u => u.isActive).HasColumnType("tinyint").IsRequired();

            //----------HospitalType-----------//
            modelBuilder.Entity<HospitalType>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<HospitalType>().Property(u => u.name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<HospitalType>().Property(u => u.code).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<HospitalType>().Property(u => u.isActive).HasColumnType("tinyint").IsRequired();

            // Configure relationships  
            //modelBuilder.Entity<User>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }
    }
}
