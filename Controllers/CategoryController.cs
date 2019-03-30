using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemoteJobber.Models;

namespace RemoteJobber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RemoteJobberContext _context;

        public CategoryController(RemoteJobberContext context)
        {
            _context = context;
            if(_context.Categories.Count() == 0 )
            {
                _context.Categories.Add(new Category{Id=1,Name="Design",Slug="design",IsActive=true});
                _context.Categories.Add(new Category{Id=2,Name="Development",Slug="development",IsActive=true});
                _context.Categories.Add(new Category{Id=3,Name="Marketing",Slug="marketing",IsActive=true});
                _context.Categories.Add(new Category{Id=4,Name="Account",Slug="account",IsActive=true});
                 
                _context.SaveChanges();
            }
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category==null)
            {
                return NotFound();
            }
            return new ObjectResult(category);
        }
    }
}
