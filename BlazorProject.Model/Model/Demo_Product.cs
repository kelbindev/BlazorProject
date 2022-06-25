using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Model.Model
{
    public class Demo_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool showProperties { get; set; }
        public List<Demo_ProductProp> ProductProperties { get; set; }
    }
}
