using AutoMapper;
using WSAgro.DAO.Entidades;
using WSAgro.DTO.DTO;

namespace WSAgro.SERVICE.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AnalisisRecurso, AnalisisRecursoDTO>().ReverseMap();
        CreateMap<AsistenciaCapacitacion, AsistenciaCapacitacionDTO>().ReverseMap();
        CreateMap<CapacitacionSst, CapacitacionSstDTO>().ReverseMap();
        CreateMap<CatalogoInsumoIca, CatalogoInsumoIcaDTO>().ReverseMap();
        CreateMap<CatalogoPlagaEnfermedad, CatalogoPlagaEnfermedadDTO>().ReverseMap();
        CreateMap<DetalleMonitoreoMip, DetalleMonitoreoMipDTO>().ReverseMap();
        CreateMap<DetalleRemision, DetalleRemisionDTO>().ReverseMap();
        CreateMap<EntregaEpp, EntregaEppDTO>().ReverseMap();
        CreateMap<EquipoHerramienta, EquipoHerramientaDTO>().ReverseMap();
        CreateMap<InventarioBodega, InventarioBodegaDTO>().ReverseMap();
        CreateMap<LaborTransaccional, LaborTransaccionalDTO>().ReverseMap();
        CreateMap<Lote, LoteDTO>().ReverseMap();
        CreateMap<MantenimientoCalibracion, MantenimientoCalibracionDTO>().ReverseMap();
        CreateMap<MaterialPropagacion, MaterialPropagacionDTO>().ReverseMap();
        CreateMap<MonitoreoMip, MonitoreoMipDTO>().ReverseMap();
        CreateMap<Predio, PredioDTO>().ReverseMap();
        CreateMap<RegistroCosecha, RegistroCosechaDTO>().ReverseMap();
        CreateMap<RemisionDespacho, RemisionDespachoDTO>().ReverseMap();
        CreateMap<UmbralAccionFinca, UmbralAccionFincaDTO>().ReverseMap();
    }
}
