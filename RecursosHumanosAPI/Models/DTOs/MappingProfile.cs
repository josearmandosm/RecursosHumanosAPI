using AutoMapper;
using RecursosHumanosAPI.Models;
using RecursosHumanosAPI.DTOs;
using RecursosHumanosAPI.Models.DTOs.Empleado;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Beneficio mappings
        CreateMap<Beneficio, BeneficioGetDTO>().ReverseMap();
        CreateMap<Beneficio, BeneficioInsertDTO>().ReverseMap();
        CreateMap<Beneficio, BeneficioUpdateDTO>().ReverseMap();

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
