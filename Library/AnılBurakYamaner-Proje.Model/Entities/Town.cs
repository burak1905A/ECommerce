using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Town : CoreEntity
    {
        public string Name { get; set; }

        public User CreatedUserTown { get; set; }
        public User ModifiedUserTown { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }
    }
}
