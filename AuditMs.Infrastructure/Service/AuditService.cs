using AuditMs.Application.DTO;
using AuditMs.Application.Interface;
using AuditMs.Domain.Models;
using AuditMs.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditMs.Infrastructure.Service
{
    public class AuditService : IAuditService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public AuditService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task AddAudit(AddAuditDTO e)
        {
            
            var res = mapper.Map<AuditLogs>(e);
            await db.Audit.AddAsync(res);   
            await db.SaveChangesAsync();
        }

        public async Task<FetchAuditDTO> DeleteAudit(int id)
        {
            var data = await db.Audit.FirstOrDefaultAsync(x=>x.LogId == id && x.IsDeleted==false); // for soft delete
            if(data == null)
            {
                return null;
            }
            else
            {
                data.IsDeleted = true;
                data.modifiedAt = DateTime.Now;
                data.modifiedBy = "admin";

                await db.SaveChangesAsync();
                return mapper.Map<FetchAuditDTO>(data);
            }
        }

        public async Task<List<FetchAuditDTO>> FetchAuditLogs()
        {
            var data = await db.Audit.Where(x=>x.IsDeleted==false).ToListAsync();
            var res = mapper.Map<List<FetchAuditDTO>>(data);
            return (res);
        }

        public async Task<FetchAuditDTO> FindById(int id)
        {
            var data = await db.Audit.FirstOrDefaultAsync(x => x.LogId == id && x.IsDeleted == false);
            if (data == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<FetchAuditDTO>(data);
            }
        }

        public async Task<FetchAuditDTO> UpdateAudit(int id,UpdateAuditDTO e)
        {
            var Data = await db.Audit.FirstOrDefaultAsync(x => x.LogId == id);
            if(Data == null)
            {
                return null;
                
            }
            else
            {
                Data.Action = e.Action;
                Data.Description = e.Description;
                Data.serviceName = e.serviceName;
                Data.modifiedBy = "system";
                Data.modifiedAt = DateTime.Now;
                await db.SaveChangesAsync();
                return mapper.Map<FetchAuditDTO>(Data);
            }

        }
    }
}
