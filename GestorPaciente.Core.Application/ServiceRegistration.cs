using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace GestorPaciente.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddCoreApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDateService, DateService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ILaboratoryTestService, LaboratoryTestService>();
            services.AddTransient<ILaboratoryTestResultService, LaboratoryTestResultService>();
            #endregion
        }
    }
}
