using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVPCore;
using FTree.DTO;
using FTree.Common;

namespace FTree.Presenter
{
    public interface IFamilyReportView : IView, IReport<FamilyReportDTO>
    {
        DataGrid datagrid {get;set;}
    }
}
