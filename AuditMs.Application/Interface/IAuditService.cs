using AuditMs.Application.DTO;
using AuditMs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditMs.Application.Interface
{
    public interface IAuditService
    {
        Task AddAudit(AddAuditDTO e);

        Task <List<FetchAuditDTO>>FetchAuditLogs();

        Task <FetchAuditDTO>DeleteAudit(int id);

        Task<FetchAuditDTO> UpdateAudit(int id,UpdateAuditDTO e);

        Task<FetchAuditDTO> FindById(int id);
    }
}
