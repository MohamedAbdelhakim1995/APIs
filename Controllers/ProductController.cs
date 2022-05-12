using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EcommerceApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository product)
        {
            productRepository = product;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            List<Product> products = productRepository.GetAll();

            if (products == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(products);

        }

        [HttpGet("{id:int}", Name = "getOneRout")]
        public IActionResult GetById(int id)
        {
            Product p = productRepository.GetById(id);

            return Ok(p);

        }

        [HttpGet("{Name:int}")]
        public IActionResult GetByName(string Name)
        {
            Product p = productRepository.GetByName(Name);

            return Ok(p);

        }


        [HttpPost]
        public IActionResult Insert(Product p)
        {

            try
            {
                productRepository.Insert(p);

                string url = Url.Link("getOneRout", new { id = p.Id });
                return Created(url, p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product p)
        {
            try
            {
                productRepository.Update(id, p);
                return StatusCode(204, "Data Saved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productRepository.Delete(id);
                return StatusCode(204, "Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

