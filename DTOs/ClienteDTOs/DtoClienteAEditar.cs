using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClienteDTOs
{
    public class DtoClienteAEditar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string constrasenia { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
