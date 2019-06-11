using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMApp.Web.Admin.Models.Category
{
    public class CategoryTreeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Open { get; set; }
        public bool Checked { get; set; }
        public List<CategoryTreeViewModel> Children { get; set; }
    }
}
