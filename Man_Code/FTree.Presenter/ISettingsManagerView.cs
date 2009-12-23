using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface ISettingsManagerView : IView
    {
        IList<RelationTypeDTO> RelationTypes { get; set; }
        RelationTypeDTO RelationType { get; }

        IList<HomeTownDTO> HomeTowns { get; set; }
        HomeTownDTO HomeTown { get; }

        IList<JobDTO> Jobs { get; set; }
        JobDTO Job { get; }

        IList<AchievementType> AchievementTypes { get; set; }
        AchievementType AchievementType { get; }

        IList<DeathReasonDTO> DeathReasons { get; set; }
        DeathReasonDTO DeathReason { get; }

        IList<BuryPlaceDTO> BuryPlaces { get; set; }
        BuryPlaceDTO BuryPlace { get; }
    }
}
