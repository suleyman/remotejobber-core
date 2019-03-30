using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemoteJobber.Models;

namespace RemoteJobber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly RemoteJobberContext _context;

        public PostController(RemoteJobberContext context)
        {
            _context = context;
            if(_context.Posts.Count() == 0 )
            {
                _context.Posts.Add(new Post {
                    Id=1,
                    Title="Front-end Developer",
                    CategoryId=2,
                    Company="Company",
                    Description = "Lorem ipsum dolor sit",
                    Type="Remote",
                    Salary="5000",
                    IsFeatured=true,
                    IsActive=true
                });
                _context.SaveChanges();
            }
        }        
        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _context.Posts.ToList();
        }
        // GET: api/Post/5
        [HttpGet("{id}", Name = "GetPostById")]
        public IActionResult Get(int id) {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if(post==null) {
                return NotFound();
            } else {
                return new ObjectResult(post);
            }
        }
    }
}