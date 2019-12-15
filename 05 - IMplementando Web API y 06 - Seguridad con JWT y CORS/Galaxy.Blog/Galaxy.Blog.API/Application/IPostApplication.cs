using Galaxy.Blog.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Blog.API.Application
{
    public interface IPostApplication
    {
        List<Post> ListPosts();
        Post GetPost(int postId);
        Post InsertPost(Post post);
        Post UpdatePost(Post post);
        Post DeletePost(int postId);
    }
}
