using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EcommerceApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryController(ICategoryRepository category)
        {
            this.CategoryRepository = category;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            List<Category> category = CategoryRepository.GetAll();



            if (category == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(category);

        }

        [HttpGet("{id:int}", Name = "getRoute")]
        public IActionResult GetById(int id)
        {

            Category c = CategoryRepository.GetById(id);

            //CategoryWithProductsDTO dto = new CategoryWithProductsDTO();

            //dto.DeptId = id;
            //dto.DeptName = c.Name;

            //foreach (var item in c.Products)
            //{
            //    dto.productsNames.Add(item.Name);
            //}



            return Ok(c);

        }

        [HttpGet("{Name:alpha}")]
        public IActionResult GetByName(string Name)
        {
            Category c = CategoryRepository.GetByName(Name);

            return Ok(c);

        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        public IActionResult Insert(Category c)
        {

            try
            {
                CategoryRepository.Insert(c);

                string url = Url.Link("getRoute", new { id = c.Id });
                return Created(url, c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id:int")]
        public IActionResult Update(int id, Category c)
        {
            try
            {
                CategoryRepository.Update(id, c);
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
                CategoryRepository.Delete(id);
                return StatusCode(204, "Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

