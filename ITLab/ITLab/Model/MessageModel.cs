using ITLab.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Model
{
    public class MessageModel
    {
        Messages msg;
        public MessageModel(Messages msg)
        {
            this.msg = msg;
            using(var db = new ITLabDBEntities())
            {
                UserFullName = db.Users.FirstOrDefault(x => x.ID == msg.UserID1).FullName;
            }
            SendTime = msg.SendTime;
            Text = msg.Text;
        }
        public string UserFullName { get; set; }
        public DateTime? SendTime  { get; set; }
        public string Text { get; set; }

    }
}
