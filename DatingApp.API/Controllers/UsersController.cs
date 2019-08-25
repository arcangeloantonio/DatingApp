using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data.Interfaces;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _datingRepository;
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository datingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _datingRepository = datingRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserForListDTO>>(await _datingRepository.GetUsers()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            return Ok(_mapper.Map<UserForDetailedDTO>(await _datingRepository.GetUser(id)));
        }
    }
}