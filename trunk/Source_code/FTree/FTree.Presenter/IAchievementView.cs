using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        IList<AchievementInfo> AchievementsList { get; set; }
        
        /// <summary>
        /// The selected achievement.
        /// </summary>
        AchievementInfo Achievement { get; set; }
    }
}
