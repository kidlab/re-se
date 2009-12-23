using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IDeathInfoView : IView
    {
        FamilyMemberDTO Person { get; set; }

        DateTime DeathTime { get; set; }

        IList<DeathReasonDTO> DeathReasonsList { get; set; }
        DeathReasonDTO DeathReason { get; set; }

        IList<BuryPlaceDTO> BuryPlacesList { get; set; }
        BuryPlaceDTO BuryPlace { get; set; }

        /// <summary>
        /// Gets or sets the information of this person's death.
        /// </summary>
        DeathInfo DeathInfo { get; set; }
    }
}
