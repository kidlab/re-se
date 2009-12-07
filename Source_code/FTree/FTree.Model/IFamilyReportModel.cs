using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IFamilyReportModel : ILinqModel<FamilyReportDTO>
    {
        List<FamilyReportDTO> FamilyReport(int fromYear, int toYear);
    }
}
