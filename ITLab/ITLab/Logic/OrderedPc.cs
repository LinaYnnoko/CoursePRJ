using ITLab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Logic
{
    public class OrderedPc
    {
        public Computers pc { get; set; }
        public OrderedPc(Computers pc)
        {
            this.pc = pc;
            Type = pc.TypeComputer;
            RAMSize = pc.SizeRAM;
            RAMType = pc.TypeRAM;
            HardSize = pc.SizeHardDisk.ToString();
            HardType = pc.TypeHardDisk;
            using(var db = new ITLabDBEntities())
            {
                try
                {
                    CPUName = db.CPUs.FirstOrDefault(x => x.ComputerId == pc.ID).Model;
                    GPUName = db.GPUs.FirstOrDefault(x => x.ComputerId == pc.ID).Model;
                    UserId = db.Users.FirstOrDefault(x => x.ID == pc.UserID).ID;
                }
                catch { }
            }
            TakeDate = pc.TimeOfOrder;
        }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string RAMSize { get; set; }

        public string RAMType { get; set; }

        public string HardSize { get; set; }

        public string HardType { get; set; }

        public string CPUName { get; set; }

        public string GPUName { get; set; }
        public DateTime? TakeDate { get; set; }
    }
}
