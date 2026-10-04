using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Helper;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository userRepository;
        private readonly IJwtHelper helper;
        public AuthController(IUserRepository userRepository, IJwtHelper helper)
        {
            this.userRepository=userRepository;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginUserReqDto req)
        {
            User? user=await this.userRepository.GetUserByEmail(req.Email);
            ResponseDto res = new ResponseDto();

            if (user == null) {
                res.IsSuccessed = false;
                res.Message = "Invalid Credentials";
                return BadRequest(res);
            }

            if (!BCrypt.Net.BCrypt.Verify(req.Password,user.Password))
            {
                res.IsSuccessed = false;
                res.Message = "Invalid Credentials";
                return BadRequest(res);
            }

            LoginUserResDto userDetail = new LoginUserResDto()
            {
                AccessToken = this.helper.GenerateJwtToken(user)
            };

            res.Data = userDetail;

            return Ok(res);
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseDto>> Register([FromBody] RegisterUserReqDto req)
        {
            User? user = await this.userRepository.GetUserByEmail(req.Email);
            ResponseDto res = new ResponseDto();

            if (user != null)
            {
                res.IsSuccessed = false;
                res.Message = $"User with email {req.Email} already exist";
                return BadRequest(res);
            }



            User newUser = new User()
            {
                UserName = req.UserName,
                Email = req.Email,
                Address = req.Address,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };

            bool result = await this.userRepository.AddUser(newUser);

            if (!result)
            {
                res.IsSuccessed = false;
                res.Message = $"Internal Server error";
                return BadRequest(res);
            }

            res.Message = "User registered successfully";

            return Ok(res);
        }

    }
}