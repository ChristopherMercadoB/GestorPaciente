using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using GestorPaciente.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GestorPaciente.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructurePersistence (this IServiceCollection service, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(op=>op.UseInMemoryDatabase("InMemoryDb"));
            }
            else
            {
                service.AddDbContext<ApplicationContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m=>m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #region Repositories
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IPatientRepository, PatientRepository>();
            service.AddTransient<IDoctorRepository, DoctorRepository>();
            service.AddTransient<ILaboratoryTestRepository, LaboratoryTestRepository>();
            service.AddTransient<ILaboratoryTestResultRepository, LaboratoryTestResultRepository>();
            service.AddTransient<IDateRepository, DateRepository>();
            #endregion


        }
    }
}
