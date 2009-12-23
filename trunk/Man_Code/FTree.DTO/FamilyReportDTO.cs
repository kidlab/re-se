using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class FamilyReportDTO : DataTransferObject
    {
        public DateTime TimeToReport { get; set; }
              
        public int Year { get; set; }
        public int BirthQuantity { get; set; }
        public int MarriageQuantity { get; set; }
        public int DeathQuantity { get; set; }

        public FamilyReportDTO()
            : base()
        {
        }
    }
}
