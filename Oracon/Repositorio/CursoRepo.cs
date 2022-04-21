using Microsoft.EntityFrameworkCore;
using Oracon.Maps;
using Oracon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Oracon.Repositorio
{
    public interface ICursoRepo
    {
        List<Curso> GetCursos();
        Curso GetCurso(int idCurso);
        Clases GetClases(int idClase);
        void SaveComentario(int idUsuario, int idCurso, string Comentario);
        Favoritos GetFavorito(int idUser, int idCurso);
        bool Favorito(int idUser, int idCurso);
        Cesta GetCompra(int idUser, int idCurso);
        string Pagado(int idUser, int idCurso);
        void SaveFavorito(int idCurso, int idUser);
        void DeleteFavorito(Favoritos favoritos);
        void SaveCesta(int idCurso, int idUser);
        void SaveGratuito(int idCurso, int idUser);
        void DeleteCesta(Cesta cursoUsuario);
    }
    public class CursoRepo : ICursoRepo
    {
        private readonly Oracon_Context context;
        public CursoRepo(Oracon_Context context)
        {
            this.context = context;
        }

        public List<Curso> GetCursos()
        {
            return context.Cursos.
                Include(o => o.Docente).
                Include(o => o.Categoria).
                ToList();
        }

        public Curso GetCurso(int idCurso)
        {
            context.Modulos.Include(o => o.Clases).ToList();
            context.Usuarios.ToList();
            return context.Cursos.
                Where(o => o.Id == idCurso).
                Include(o => o.Docente).
                Include(o => o.Aprendizajes).
                Include(o => o.Categoria).
                Include(o => o.Modulos).
                Include(o => o.Comentarios).
                Include(o => o.Requisitos).
                FirstOrDefault();
        }

        public void SaveComentario(int idUsuario, int idCurso, string Comentario)
        {
            ComentarioCurso comentario = new ComentarioCurso();
            comentario.IdCurso = idCurso;
            comentario.IdUsuario = idUsuario;
            comentario.Comentario = Comentario;
            context.Add(comentario);
            context.SaveChanges();
        }

        public Clases GetClases(int idClase)
        {
            return context.Clases.Where(o => o.Id == idClase).
                Include(o => o.Recursos).
                FirstOrDefault();
        }

        public void SaveFavorito(int idCurso, int idUser)
        {
            Favoritos favoritos = new Favoritos
            {
                IdCurso = idCurso,
                IdUser = idUser
            };
            context.Add(favoritos);
            context.SaveChanges();
        }

        public void DeleteFavorito(Favoritos favoritos)
        {
            context.Remove(favoritos);
            context.SaveChanges();
        }

        public void SaveCesta(int idCurso, int idUser)
        {
            Cesta compra = new Cesta
            {
                IdCurso = idCurso,
                IdUser = idUser,
                Pagado = false
            };
            context.Add(compra);
            context.SaveChanges();
        }


        public void DeleteCesta(Cesta cursoUsuario)
        {
            context.Remove(cursoUsuario);
            context.SaveChanges();
        }

        public void SaveGratuito(int idCurso, int idUser)
        {
            Cesta compra = new Cesta
            {
                IdCurso = idCurso,
                IdUser = idUser,
                Pagado = true
            };
            context.Add(compra);
            context.SaveChanges();
        }
        public Favoritos GetFavorito(int idUser, int idCurso)
        {
            return context.Favoritos.Where(o => o.IdUser == idUser && o.IdCurso == idCurso).FirstOrDefault();
        }
        public Cesta GetCompra(int idUser, int idCurso)
        {
            return context.Cestas.Where(o => o.IdUser == idUser && o.IdCurso == idCurso).FirstOrDefault();
        }

        public bool Favorito(int idUser, int idCurso)
        {
            var favorite = GetFavorito(idUser, idCurso);
            if (favorite != null)
                return true;
            else
                return false;
        }

        public string Pagado(int idUser, int idCurso)
        {
            var compra = GetCompra(idUser, idCurso);
            if (compra != null)
            {
                if (!compra.Pagado)
                    return "Cesta";
                else
                    return "Pagado";
            }
            else
                return "Nada";
        }
    }
}
