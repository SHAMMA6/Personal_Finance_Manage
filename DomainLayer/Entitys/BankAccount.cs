using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime ConnectedDate { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }

}
