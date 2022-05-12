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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        public OrderController(IOrderRepository order)
        {
            orderRepository = order;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            List<Order> orders = orderRepository.GetAll();

            if (orders == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(orders);

        }

        [HttpGet("{id:int}", Name = "getOneRoute")]
        public IActionResult GetById(int id)
        {
            Order p = orderRepository.GetById(id);

            return Ok(p);

        }

      


        [HttpPost]
        public IActionResult Insert(Order p)
        {

            try
            {
                orderRepository.Insert(p);

                string url = Url.Link("getOneRoute", new { id = p.Id });
                return Created(url, p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id:int")]
        public IActionResult Update(int id, Order p)
        {
            try
            {
                orderRepository.Update(id, p);
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
                orderRepository.Delete(id);
                return StatusCode(204, "Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

