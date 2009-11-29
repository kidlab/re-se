using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.Common
{
    /// <summary>
    /// Skeleton of all reportorial objects.
    /// </summary>
    /// <typeparam name="T">The type of each entry in the report.</typeparam>
    public interface IReport<T>
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        IList<T> GetReportByYear();
        IList<T> GetReportByMonthYear();
        IList<T> GetReportByDayMonthYear();
    }
}
