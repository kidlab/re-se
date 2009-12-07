using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class FamilyDTO : DataTransferObject
    {
        public string Name { get; set; }
        public FamilyMemberDTO RootPerson { get; set; }

        public FamilyDTO()
        {
            Name = String.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
