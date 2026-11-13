using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Helper;
using server.Repository;
using server.Interface.Repository;
using System.IdentityModel.Tokens.Jwt;

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
            this.userRepository = userRepository;
            this.helper = helper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginUserReqDto req)
        {
            User? user = await this.userRepository.GetUserByEmail(req.Email);
            ResponseDto res = new ResponseDto();

            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            {
                res.IsSuccessed = false;
                res.Message = "Invalid Credentials";
                return BadRequest(res);
            }

            // 1. Generar Access Token
            var accessToken = this.helper.GenerateJwtToken(user);

            // 2. Generar Refresh Token
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                Expires = DateTime.Now.AddDays(7),
                UserId = user.UserId
            };

            // 3. Guardar en base de datos
            await this.userRepository.SaveRefreshToken(refreshToken);

            // 4. Devolver ambos tokens
            LoginUserResDto userDetail = new LoginUserResDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
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
                res.Message = "Internal Server error";
                return BadRequest(res);
            }

            res.Message = "User registered successfully";
            return Ok(res);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<ResponseDto>> RefreshToken([FromBody] RefreshTokenReqDto req)
        {
            ResponseDto res = new ResponseDto();

            var principal = this.helper.GetPrincipalFromExpiredToken(req.AccessToken);
            var userId = int.Parse(principal.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "0");

            var storedRefreshToken = await this.userRepository.GetRefreshToken(req.RefreshToken);

            if (storedRefreshToken == null || storedRefreshToken.IsRevoked ||
                storedRefreshToken.Expires < DateTime.Now || storedRefreshToken.UserId != userId)
            {
                res.IsSuccessed = false;
                res.Message = "Invalid refresh token";
                return BadRequest(res);
            }

            var user = await this.userRepository.GetUserById(userId);
            var newAccessToken = this.helper.GenerateJwtToken(user!);

            res.Data = new RefreshTokenResDto
            {
                AccessToken = newAccessToken,
                RefreshToken = storedRefreshToken.Token
            };

            return Ok(res);
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> Logout([FromBody] RefreshTokenReqDto req)
        {
            ResponseDto res = new ResponseDto();
            var storedRefreshToken = await this.userRepository.GetRefreshToken(req.RefreshToken);

            if (storedRefreshToken != null)
            {
                storedRefreshToken.IsRevoked = true;
                await this.userRepository.UpdateRefreshToken(storedRefreshToken);
            }

            res.Message = "Logged out successfully";
            return Ok(res);
        }
    }
}
