using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Maillist : CoreEntity
    {
    
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }

        public User CreatedUserMaillist { get; set; }
        public User ModifiedUserMaillist { get; set; }

        

    }
}
