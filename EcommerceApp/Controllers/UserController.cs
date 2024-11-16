using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Crear un usuario
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok("Usuario creado exitosamente.");

            return BadRequest(result.Errors);
        }

        // Crear un rol
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
        {
            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
            if (roleExists)
                return BadRequest("El rol ya existe.");

            var result = await _roleManager.CreateAsync(new IdentityRole { Name = model.RoleName });

            if (result.Succeeded)
                return Ok("Rol creado exitosamente.");

            return BadRequest(result.Errors);
        }

        // Asignar un rol a un usuario
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound("Usuario no encontrado.");

            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!roleExists)
                return BadRequest("El rol no existe.");

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
                return Ok("Rol asignado exitosamente.");

            return BadRequest(result.Errors);
        }

        // Obtener todos los usuarios
        //[Authorize]
        [HttpGet("get-users")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }


        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            return Ok();
        }
    }

}
