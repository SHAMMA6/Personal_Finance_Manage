using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class Budget
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Limit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }

}
