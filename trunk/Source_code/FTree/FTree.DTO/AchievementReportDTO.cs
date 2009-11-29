using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class AchievementReportDTO : DataTransferObject
    {
        public DateTime AchievementDate { get; set; }
        public AchievementType AchievementType { get; set; }
        public int Quantity { get; set; }
    }
}
