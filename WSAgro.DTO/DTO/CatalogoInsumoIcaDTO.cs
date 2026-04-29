namespace WSAgro.DTO.DTO;

public class CatalogoInsumoIcaDTO
{
    public Guid id { get; set; }

    public string? RegistroIca { get; set; }

    public string? NombreComercial { get; set; }

    public string? IngredienteActivo { get; set; }

    public string? CategoriaTox { get; set; }

    public string? TipoInsumo { get; set; }

    public DateTime? CreatedAt { get; set; }

}
