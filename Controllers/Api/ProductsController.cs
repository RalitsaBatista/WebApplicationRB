using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRB.Data;
using WebApplicationRB.Models;

namespace WebApplicationRB.Controllers.Api
{
    /// <summary>
    /// JSON Api ProductsController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor. Initalization of the database context
        /// </summary>
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
       /// <summary>
       /// Get a list of all the products
       /// Example url: /api/products
       /// </summary>       
       /// <returns>List<Product></returns>
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }


        /// <summary>
        /// Get a single product by id
        /// Example url: /api/products/3
        /// </summary>
        /// <returns>Product</returns>        
        //[HttpGet("{id}", Name = "GetProduct")]
        [HttpGet("{Id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var item = _context.Products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }



        /// <summary>
        /// Get a  list of filtered products by using a comma separated querystring var ids
        /// Example url: /api/products/1,3
        /// </summary>
        /// <param name="ids">{id},{id},{id}...</param>
        /// <returns>List<Product></returns>
        [HttpGet]
        [Route("{ids}")]
        public IEnumerable<Product> GetFiltered(string ids)
        {
            if (ids != null && ids.Length > 1)
            {
                System.Diagnostics.Debug.WriteLine("IDS: " + ids);
                int[] nIds = ids.Split(',').Select(Int32.Parse).ToArray();

                return _context.Products.Where(p => nIds.Contains(p.ID)).ToList();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("NOOO IDS !!! ");
                return _context.Products.ToList();
            }
        }
    }
}
