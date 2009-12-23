using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IAchievementReportModel : ILinqModel<AchievementReportDTO>
    {
        string AddWithString();
        List<MEMBER_EVENT> Add();

        Array AddWithArray();

        List<AchievementReportDTO> AchievementReport(int from, int to);

    }
}
