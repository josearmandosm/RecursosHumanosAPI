namespace RecursosHumanosAPI.DTOs
{
    public class EvaluacionUpdateDTO
    {
        public required string Descripcion { get; set; }
        public int EvaluacionId { get; internal set; }
    }
}
