namespace WSAgro.DTO.DTO;

public class CatalogoPlagaEnfermedadDTO
{
    public Guid id { get; set; }

    public string? NombreComun { get; set; }

    public string? NombreCientifico { get; set; }

    public string? TipoAgente { get; set; }

    public DateTime? CreatedAt { get; set; }

}
