using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Manager.Project.Financial.Application.DTOs.Enums
{
    public enum EInstallmentStatus
    {
        Pending,
        Paid,
        Overdue,
        Cancelled,
        Refunded,
        Other
    }
}
