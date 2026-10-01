using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ResponseDto>> GetAll()
        {
            ResponseDto responseDto=new ResponseDto();
            responseDto.Data=await this.userRepository.GetAllUsers();
            return Ok(responseDto);
        }

        
    }
}
