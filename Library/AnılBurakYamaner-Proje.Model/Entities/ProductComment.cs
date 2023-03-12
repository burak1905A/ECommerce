using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class ProductComment : CoreEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Rank { get; set; }
        public string isAnonymous { get; set; }

        public User CreatedUserProductComment { get; set; }
        public User ModifiedUserProductComment { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
