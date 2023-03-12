using AnılBurakYamaner_Proje.Common.Enums;
using System;

namespace AnılBurakYamaner_Proje.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public Guid? CreatedUserId { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedComputerName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Guid? ModifiedUserId { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedComputerName { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
