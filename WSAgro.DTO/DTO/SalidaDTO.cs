namespace WSAgro.DTO.DTO;

public class SalidaDTO<T>
{
    public int Codigo { get; set; }
    public string? Mensaje { get; set; }
    public T? Data { get; set; }
}
