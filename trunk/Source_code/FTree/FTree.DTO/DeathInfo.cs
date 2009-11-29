using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class DeathInfo : DataTransferObject
    {
        public DeathReasonDTO Reason { get; set; }
        public DateTime DeathDay { get; set; }
        public BuryPlaceDTO BuryPlace { get; set; }
    }
}
