using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oracon.Models
{
    public class Clases
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdModulo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Video { get; set; }
        public string Descripcion { get; set; }
        public List<Recursos> Recursos { get; set; }
    }
}
