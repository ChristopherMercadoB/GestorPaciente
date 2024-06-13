using AutoMapper;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.Doctor;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTest;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.Core.Application.ViewModels.Role;
using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap()
                 .ForMember(dest=>dest.CreatedBy, obj=>obj.Ignore())
                 .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                 .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                 .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<User, UserSaveViewModel>()
                .ForMember(dest=>dest.ConfirmPassword, obj=>obj.Ignore())
               .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Role, RoleViewModel>();
            CreateMap<Role, RoleSaveViewModel>();

            CreateMap<Patient, PatientViewModel>()
               .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Patient, PatientSaveViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Doctor, DoctorSaveViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Doctor, DoctorViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<LaboratoryTest, LaboratoryTestViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<LaboratoryTest, LaboratoryTestSaveViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<LaboratoryTestResult, LaboratoryTestResultSaveViewModel>()
               .ForMember(dest => dest.Dates, obj => obj.Ignore())
               .ForMember(dest => dest.LaboratoriesId, obj => obj.Ignore())
               .ForMember(dest => dest.Patients, obj => obj.Ignore())
               .ForMember(dest => dest.LaboratoryTests, obj => obj.Ignore())
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<LaboratoryTestResult, LaboratoryTestResultViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Date, DateViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());
            
            CreateMap<Date, DateSaveViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
               .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());




        }
    }
}
