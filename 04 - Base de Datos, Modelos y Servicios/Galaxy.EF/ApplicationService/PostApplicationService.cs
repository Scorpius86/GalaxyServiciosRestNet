using Galaxy.EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxy.EF.ApplicationService
{
    
    public class PostApplicationService
    {
        private GalaxyDatabaseContext _galaxyContext;
        public PostApplicationService(GalaxyDatabaseContext galaxyContext)
        {
            _galaxyContext = galaxyContext;

        }

        public Post Get(int id)
        {
            var post = _galaxyContext.Posts.Find(id);

            return post;
        }

        public List<Post> List()
        {
            var posts = _galaxyContext.Posts.ToList();

            return posts;
        }

        public List<Post> ListSP()
        {
            var posts = _galaxyContext.Posts.FromSql("[uspListPost]").ToList();

            return posts;
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            // var table = _galaxyContext.Database.ExecuteSqlCommand("[uspListPost]");
            using (var command = _galaxyContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[uspListPost]";
                _galaxyContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Post post = new Post();
                            post.PostId = reader.GetInt32(0);
                            post.Titulo = reader.GetString(1);

                            posts.Add(post);
                        }
                    }
                }
            }

            return posts;
            //return _libraryContext.Authors.FromSql("usp_ListAuthors").ToList();

            //return _libraryContext.Authors.ToList();
        }

        public void Update(Post post)
        {
            Usuario usuario = _galaxyContext.Usuarios.Find(1);
            Post postUpdate = _galaxyContext.Posts.Find(post.PostId);

            postUpdate.UsuarioIdActualizacionNavigation = usuario;
            postUpdate.Titulo = post.Titulo;
            postUpdate.Contenido = post.Contenido;

            _galaxyContext.Posts.Update(postUpdate);
            _galaxyContext.SaveChanges();
        }

        public Post Insert(Post post)
        {
            Usuario usuario = _galaxyContext.Usuarios.Find(1);
            post.UsuarioIdPropietarioNavigation = usuario;
            post.UsuarioIdActualizacionNavigation = usuario;
            post.UsuarioIdCreacionNavigation = usuario;

            _galaxyContext.Posts.Add(post);
            _galaxyContext.SaveChanges();

            return _galaxyContext.Posts.Find(post.PostId);
        }

        public Post Delete(int id)
        {
            Post post = _galaxyContext.Posts.Find(id);
            _galaxyContext.Posts.Remove(post);
            _galaxyContext.SaveChanges();

            return post;
        }
    }
}
