using AuditMs.Application.DTO;
using AuditMs.Application.Interface;
using AuditMs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditMs.Controllers
{
    [Route("Audit")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        IAuditService service;
        public AuditController(IAuditService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddAudit(AddAuditDTO e)
        {
            await service.AddAudit(e);
            return Ok(new { message = "Audited" });
        }

        [HttpGet]
        public async Task<IActionResult> FetchAudit()
        {
            var data = await service.FetchAuditLogs();
            return Ok(data);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAudit(int id)
        {
            var data = await service.DeleteAudit(id);
            return Ok(new { message = "Log Deleted" });
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAudit(int id, UpdateAuditDTO e)
        {
            await service.UpdateAudit(id, e);
            return Ok(new { message = "Updated " });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> FindById(int id)
        {
            var data = await service.FindById(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound(new { message = "Log Id Not found" });
            }
        }
    }
}
