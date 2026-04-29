using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditMs.Application.DTO
{
    public class AddAuditDTO
    {
        public string userId { get; set; }

        public string serviceName { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public string createdBy { get; set; }

        public string modifiedBy { get; set; }

    }
}
