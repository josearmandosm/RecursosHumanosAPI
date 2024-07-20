using AutoMapper;
using RecursosHumanosAPI.Models;
using RecursosHumanosAPI.DTOs;
using RecursosHumanosAPI.Models.DTOs.Empleado;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Beneficio mappings
        // Mapeo de Beneficio a BeneficioGetDTO y viceversa
        CreateMap<Beneficio, BeneficioGetDTO>().ReverseMap();

        // Mapeo de BeneficioInsertDTO a Beneficio para creación
        CreateMap<BeneficioInsertDTO, Beneficio>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

        // Mapeo de BeneficioUpdateDTO a Beneficio para actualización
        CreateMap<BeneficioUpdateDTO, Beneficio>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

        // Beneficio mappings
        // Mapeo inverso si es necesario para las actualizaciones
        CreateMap<Beneficio, BeneficioUpdateDTO>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));


        // Capacitacion mappings
        CreateMap<Capacitacion, CapacitacionGetDTO>().ReverseMap();
        CreateMap<Capacitacion, CapacitacionInsertDTO>().ReverseMap();
        CreateMap<Capacitacion, CapacitacionUpdateDTO>().ReverseMap();

        // Departamento mappings
        CreateMap<Departamento, DepartamentoGetDTO>().ReverseMap();
        CreateMap<Departamento, DepartamentoInsertDTO>().ReverseMap();
        CreateMap<Departamento, DepartamentoUpdateDTO>().ReverseMap();

        // Empleado mappings
        CreateMap<Empleado, EmpleadoGetDTO>().ReverseMap();
        CreateMap<Empleado, EmpleadoInsertDTO>().ReverseMap();
        CreateMap<Empleado, EmpleadoUpdateDTO>().ReverseMap();

        // Evaluacion mappings
        CreateMap<Evaluacion, EvaluacionGetDTO>().ReverseMap();
        CreateMap<Evaluacion, EvaluacionInsertDTO>().ReverseMap();
        CreateMap<Evaluacion, EvaluacionUpdateDTO>().ReverseMap();

        // Nomina mappings
        CreateMap<Nomina, NominaGetDTO>().ReverseMap();
        CreateMap<Nomina, NominaInsertDTO>().ReverseMap();
        CreateMap<Nomina, NominaUpdateDTO>().ReverseMap();

        // Puesto mappings
        CreateMap<Puesto, PuestoGetDTO>().ReverseMap();
        CreateMap<Puesto, PuestoInsertDTO>().ReverseMap();
        CreateMap<Puesto, PuestoUpdateDTO>().ReverseMap();

        // Vacacion mappings
        CreateMap<Vacacion, VacacionGetDTO>().ReverseMap();
        CreateMap<Vacacion, VacacionInsertDTO>().ReverseMap();
        CreateMap<Vacacion, VacacionUpdateDTO>().ReverseMap();
    }
}
