using System.ComponentModel.DataAnnotations.Schema;

namespace EMPRESA.Models
{
    public class Empleado: BaseEntity
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        //Tipo de Empleado
        [ForeignKey("tipos_empleados")]
        public int EmpTipoID { get; set; }
        public EmpleadosTipos tipos_empleados { get; set; }
    }
}
