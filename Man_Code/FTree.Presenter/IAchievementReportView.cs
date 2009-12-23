using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVPCore;
using FTree.DTO;
using FTree.Common;
using FTree.Model;

namespace FTree.Presenter
{
    public interface IAchievementReportView : IView, IReport<AchievementReportDTO>
    {
        //DateTime AchievementDate { get; set; }
        //AchievementType AchievementType { get; set; }
        //int Quantity { get; set; }
        //int AchievementYear { get; set; }
        //List<MEMBER_EVENT> listAchieve { get; set;}
        DataGridView dgview { get; set; }
    }
}
