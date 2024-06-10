namespace RecursosHumanosAPI.DTOs
{
    public class DepartamentoUpdateDTO
    {
        public required string Nombre { get; set; }
        public int DepartamentoId { get; internal set; }
    }
}
