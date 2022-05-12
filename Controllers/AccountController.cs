using EcommerceApis.Dto;
using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config, ICartRepository cartRepository)
        {
            this.userManager = userManager;
            this.config = config;
            this.cartRepository = cartRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser newUser = new ApplicationUser();
            newUser.UserName = registerDTO.UserName;
            newUser.Email = registerDTO.Email;
            Cart cart = new Cart();
            cartRepository.Insert(cart);
            newUser.CartId = cart.Id;

            IdentityResult result = await userManager.CreateAsync(newUser, registerDTO.Password);

            if (result.Succeeded)
            {
                cart.CustomerId = newUser.Id;
                cartRepository.Update(cart.Id, cart);
                return Ok(cart);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);



                }
                cartRepository.Delete(cart.Id);

                return BadRequest(ModelState);

            }




        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await userManager.FindByNameAsync(loginDTO.UserName);

            if (user != null)

            {
                if (await userManager.CheckPasswordAsync(user, loginDTO.Password))
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                    var roles = await userManager.GetRolesAsync(user);

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));

                    }

                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                    var token = new JwtSecurityToken(

                        audience: config["JWT:ValidAudience"],
                        issuer: config["JWT:ValidIssuer"],
                        expires: DateTime.Now.AddHours(5),
                        claims: claims,
                        signingCredentials:
                        new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }

            else
            {

                return Unauthorized();
            }
        }

        [HttpPost("RegisterAdmin")]

        public async Task<IActionResult> RegisterAdmin(RegisterDTO registerDTO)//Customize property - validation atrbiute
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser newUser = new ApplicationUser();
            newUser.UserName = registerDTO.UserName;
            newUser.Email = registerDTO.Email;
            
            Cart cart = new Cart();
            cartRepository.Insert(cart);
            newUser.CartId = cart.Id;

            IdentityResult result = await userManager.CreateAsync(newUser, registerDTO.Password);
            IdentityResult roleResult = await userManager.AddToRoleAsync(newUser, "Admin");


            if (result.Succeeded)
            {
                cart.CustomerId = newUser.Id;
                cartRepository.Update(cart.Id, cart);
                return Ok(cart);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);



                }
                cartRepository.Delete(cart.Id);

                return BadRequest(ModelState);

            }
        }
    }
}