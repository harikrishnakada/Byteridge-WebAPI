using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using System.Security.Claims;
using WebApi.Entities.CodeList;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuditController : ControllerBase
    {
        private ICRUD<Audit> _crudService;
        private ISecurityService _securityService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuditController(
            ICRUD<Audit> crudService,
            ISecurityService securityService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _crudService = crudService;
            _securityService = securityService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("upsert")]
        public IActionResult UpsertAudit([FromBody]AuditDto auditDto)
        {
            // map dto to entity
            var audit = _mapper.Map<Audit>(auditDto);
            try
            {
                // save 
                _crudService.Create(audit);
                return Ok(audit);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            // map dto to entity and set id
            var audit = new Audit() { Id = id };
            audit.OnChanged();

            try
            {
                // Update 
                _crudService.Update(audit);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var role = this._securityService.ValidateToken(HttpContext.Request)?.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

            if (role != RoleCode.Values.Auditor)
                return Unauthorized();

            var audits = await _crudService.GetAllAsync();
            var auditsDtos1 = _mapper.Map<IList<AuditDto>>(audits);

            return Ok(auditsDtos1);
        }
    }
}
