using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class HomeTownDTO : DataTransferObject
    {
        public string Name { get; set; }
        
        public override string ToString()
        {
            return this.Name;
        }
    }
}
