using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Model;
using WebApi.Data;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoleController: ControllerBase
    {
        private ICRUD<Role> _crudService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RoleController(
            ICRUD<Role> crudService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _crudService = crudService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("upsert")]
        public IActionResult UpsertRole([FromBody]RoleDto roleDto)
        {
            // map dto to entity
            var role = _mapper.Map<Role>(roleDto);
            try
            {
                // save 
                _crudService.Create(role);
                return Ok(role);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _crudService.GetAllAsync();
            var roleDtos = _mapper.Map<IList<RoleDto>>(roles);
            return Ok(roleDtos);
        }
    }
}
