namespace RecursosHumanosAPI.DTOs
{
    public class CapacitacionUpdateDTO
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CapacitacionId { get; internal set; }
    }
}
