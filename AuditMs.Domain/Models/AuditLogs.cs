using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditMs.Domain.Models
{
    public class AuditLogs
    {
        [Key]
        public int LogId { get; set; }

        public string userId { get; set; }

        public string serviceName { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public string createdBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? modifiedBy { get; set; }

        public DateTime modifiedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
