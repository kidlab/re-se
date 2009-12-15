using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class DeathReasonDTO : DataTransferObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DeathReasonDTO()
            : base()
        {
            Name = String.Empty;
            Description = String.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
