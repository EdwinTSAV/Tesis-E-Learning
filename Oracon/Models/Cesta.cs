namespace Oracon.Models
{
    public class Cesta
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdCurso { get; set; }
        public bool Pagado { get; set; }
        public Curso Cursos { get; set; }
        public Usuario Usuarios { get; set; }
    }
}
