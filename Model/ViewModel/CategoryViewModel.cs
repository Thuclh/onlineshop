using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class CategoryViewModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string MetaTitle { get; set; }

        public long? ParentId { get; set; }

        public int? DisplayOrder { get; set; }
        
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        
        public string ModifieBy { get; set; }
        
        public string MetaKeywords { get; set; }
        
        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }
    }
}
