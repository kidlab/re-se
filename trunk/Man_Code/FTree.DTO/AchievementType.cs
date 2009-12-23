using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class AchievementType : DataTransferObject
    {
        public string Name { get; set; }

        public AchievementType()
            : base()
        {
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
