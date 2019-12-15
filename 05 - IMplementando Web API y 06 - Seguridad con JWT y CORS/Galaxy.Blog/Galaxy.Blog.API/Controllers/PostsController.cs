using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Blog.API.Application;
using Galaxy.Blog.API.Data.Context;
using Galaxy.Blog.API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostApplication _postApplication { get; }

        public PostsController(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            List<Post> posts = new List<Post>();
            /*
            for (int i = 0; i < 10; i++)
            {
                posts.Add(new Post
                {
                    Titulo = "Titutlo" + i.ToString()
                });
            }
            */
            return _postApplication.ListPosts();
        }
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {

            return _postApplication.GetPost(id);
        }

        [HttpPost]
        public ActionResult<Post> AddPost([FromBody]Post post)
        {
            return _postApplication.InsertPost(post);
        }
        [HttpPut("{id}")]
        public ActionResult<Post> UpdatePost([FromBody]Post post,int id)
        {
            post.PostId = id;
            return _postApplication.UpdatePost(post);
        }
        [HttpDelete("{id}")]
        public ActionResult<Post> DeletePost(int id)
        {
            return _postApplication.DeletePost(id);
        }
    }
}