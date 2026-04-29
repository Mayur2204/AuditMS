using AuditMs.Application.DTO;
using AuditMs.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditMs.Application.Mapping
{
    public class DTOMapping: Profile
    {
        public DTOMapping()
        {
            CreateMap<AuditLogs, AddAuditDTO>().ReverseMap();
            CreateMap<AuditLogs, FetchAuditDTO>().ReverseMap();
            CreateMap<AuditLogs, UpdateAuditDTO>().ReverseMap();
        }
    }
}
