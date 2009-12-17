using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.Model;
using FTree.DTO;
using FTree.Common;

namespace FTree.Presenter
{
    public class FamilyReportPresenter : BasePresenter<IFamilyReportModel, IFamilyReportView>
    {
        protected override void _disposeComponents()
        {
            throw new NotImplementedException();
        }

        #region CONSTRUCTOR
        public FamilyReportPresenter(IFamilyReportModel model, IFamilyReportView view)
        {
            this._model = model;
            this._view = view;

        }
        public FamilyReportPresenter(IFamilyReportView view)
            : this(new FamilyReportModel(), view)
        { }

        #endregion

        #region VARIABLE
        //public System.Windows.Forms.DataGridView dgview;
        public List<FamilyReportDTO> listFRDTO;

        #endregion

        public List<FamilyReportDTO> FamilyReport(int fromYear, int toYear)
        //public void AchievementReport()
        {
            try
            {
                List<FamilyReportDTO> query = this._model.FamilyReport(fromYear, toYear);
                //this.listAchievment = query;
                //this._view.dgview.DataSource = query;
                //this.dtgrid.DataSource = query;
                return query;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyReportPresenter), exc);
                throw new FTreePresenterException(exc);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyReportPresenter), exc);
                throw new FTreePresenterException(exc);
            }
        }
    }
}