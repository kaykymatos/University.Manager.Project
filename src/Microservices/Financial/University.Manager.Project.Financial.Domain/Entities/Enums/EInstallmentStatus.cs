using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Manager.Project.Financial.Domain.Entities.Enums
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
