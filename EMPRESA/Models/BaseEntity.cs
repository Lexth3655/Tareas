namespace EMPRESA.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaModifica { get; set; }
        public bool Activo { get; set; }
    }
}
