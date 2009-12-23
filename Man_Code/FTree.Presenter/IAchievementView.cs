using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IAchievementView : IView
    {
        /// <summary>
        /// The person who are assigned this achievement.
        /// </summary>
        FamilyMemberDTO Person { get; set; }

        /// <summary>
        /// List of all available achievement type.
        /// </summary>
        IList<AchievementType> AchievementTypeList { get; set; }

        /// <summary>
        /// The selected 
        /// </summary>
        AchievementType SelectedAchievementType { get;}

        /// <summary>
        /// The achievement of the person.
        /// </summary>
        AchievementInfo AchievementInfo { get; set; }
        
    }
}
