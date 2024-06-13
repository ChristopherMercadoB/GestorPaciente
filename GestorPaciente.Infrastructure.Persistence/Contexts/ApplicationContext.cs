using GestorPaciente.Core.Domain.Common;
using GestorPaciente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken toke = new())
        {
            foreach (var item in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedBy = "Chris";
                        item.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.CreatedBy = "Chris";
                        break;
                }
            }
            return base.SaveChangesAsync(toke);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LaboratoryTest> LaboratoryTests { get; set; }
        public DbSet<LaboratoryTestResult> LaboratoryTestResults { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            model.Entity<User>().ToTable("Usuario");
            model.Entity<Date>().ToTable("Cita");
            model.Entity<Doctor>().ToTable("Medico");
            model.Entity<LaboratoryTest>().ToTable("Prueba de laboratorio");
            model.Entity<LaboratoryTestResult>().ToTable("Resultado");
            model.Entity<Patient>().ToTable("Paciente");
            model.Entity<Role>().ToTable("Roll");
            #endregion

            #region Primary Keys
            model.Entity<User>().HasKey(x => x.Id);
            model.Entity<Date>().HasKey(x => x.Id);
            model.Entity<Doctor>().HasKey(x => x.Id);
            model.Entity<LaboratoryTest>().HasKey(x => x.Id);
            model.Entity<LaboratoryTestResult>().HasKey(x => x.Id);
            model.Entity<Patient>().HasKey(x => x.Id);
            model.Entity<Role>().HasKey(x => x.Id);
            #endregion

            #region Foreign Keys
            model.Entity<Role>()
                .HasMany<User>(r=>r.Users)
                .WithOne(u=>u.Role)
                .HasForeignKey(u=>u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Patient>()
                .HasMany<LaboratoryTestResult>(p => p.LaboratoryTestResults)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade);



            model.Entity<Doctor>()
                .HasMany<Date>(p => p.Dates)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);


            model.Entity<LaboratoryTest>()
                .HasMany<LaboratoryTestResult>(p => p.LaboratoryTestResults)
                .WithOne(d => d.LaboratoryTest)
                .HasForeignKey(d => d.LaboratoryTestId)
                .OnDelete(DeleteBehavior.Cascade);


            model.Entity<Patient>()
                .HasMany<Date>(p => p.Dates)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.NoAction);


            model.Entity<LaboratoryTestResult>()
                .HasOne<Date>(p => p.Date)
                .WithMany(d => d.LaboratoryTestResults)
                .HasForeignKey(d => d.DateId)
                .OnDelete(DeleteBehavior.Cascade);






            #endregion

            #region Properties
            #region Date
            model.Entity<Date>()
                .Property(d=>d.State)
                .IsRequired();

            model.Entity<Date>()
                .Property(d => d.DateDay)
                .IsRequired();

            model.Entity<Date>()
                .Property(d => d.DateTime)
                .IsRequired();

            model.Entity<Date>()
                .Property(d => d.Reason)
                .IsRequired();
            #endregion

            #region Doctor
            model.Entity<Doctor>()
                .Property(d => d.Identification)
                .IsRequired();

            model.Entity<Doctor>()
                .Property(d => d.Email)
                .IsRequired();

            model.Entity<Doctor>()
                .Property(d => d.Phone)
                .IsRequired();

            model.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();

            model.Entity<Doctor>()
                .Property(d => d.LastName)
                .IsRequired();

            model.Entity<Doctor>()
                .Property(d => d.ImageUrl)
                .IsRequired(false);
            #endregion

            #region LaboratoryTest
            model.Entity<LaboratoryTest>()
                .Property(d => d.Name)
                .IsRequired();
            #endregion

            #region LaboratoryTestResult
            model.Entity<LaboratoryTestResult>()
                .Property(d => d.State)
                .IsRequired();

            model.Entity<LaboratoryTestResult>()
                .Property(d => d.Result)
                .IsRequired(false);
            #endregion

            #region Patient
            model.Entity<Patient>()
                .Property(d => d.Name)
                .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.LastName)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.Address)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.Alergies)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.Birthdate)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.Smoker)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.Identification)
               .IsRequired();

            model.Entity<Patient>()
               .Property(d => d.ImageUrl)
               .IsRequired(false);
            #endregion

            #region User
            model.Entity<User>()
               .Property(d => d.Name)
               .IsRequired();

            model.Entity<User>()
               .Property(d => d.LastName)
               .IsRequired();

            model.Entity<User>()
               .Property(d => d.Email)
               .IsRequired();

            model.Entity<User>()
               .Property(d => d.Password)
               .IsRequired();

            model.Entity<User>()
               .Property(d => d.Username)
               .IsRequired();
            #endregion
            #endregion
        }
    }
}
