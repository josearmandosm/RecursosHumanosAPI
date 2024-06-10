namespace RecursosHumanosAPI.DTOs
{
    public class VacacionUpdateDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int VacacionId { get; internal set; }
    }
}
