using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class Backup
    {
        public int Id { get; set; }
        public DateTime BackupDate { get; set; }
        public string BackupData { get; set; } // Location or content of the backup

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }

}
