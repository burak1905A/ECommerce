using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Country : CoreEntity
    {
        public Country()
        {
            Members = new HashSet<Member>();

            Locations = new HashSet<Location>();
        }
        public string Name { get; set; }
        public string Code { get; set; }

        public User CreatedUserCountry { get; set; }
        public User ModifiedUserCountry { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
