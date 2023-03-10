using BlogClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Infrastructure.Interfaces
{
    public interface IBlogPostService
    {
        Task<AllPostsPagedModel> GetAllPostsPaged();
        Task<PostDetailsModel> GetSinglePost();
    }
}
