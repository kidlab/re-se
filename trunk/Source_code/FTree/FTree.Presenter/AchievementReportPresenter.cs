using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.Model;
using FTree.DTO;



namespace FTree.Presenter
{
    public class AchievementReportPresenter : BasePresenter<IAchievementReportModel, IAchievementReportView>
    {
        #region Implement interface
        
        protected override void _disposeComponents()
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region CONSTRUCTOR
        public AchievementReportPresenter(IAchievementReportModel model, IAchievementReportView view)
        {
            this._model = model;
            this._view = view;

        }
        public AchievementReportPresenter(IAchievementReportView view)
            : this(new AchievementReportModel(), view)
        { }

        #endregion

        #region CORE METHOD
        public List<MEMBER_EVENT> AchievementReport()
        {
            try
            {
                List<MEMBER_EVENT> query = this._model.AchievementReport();
                this.listAchievment = query;
                return query;
            }
            catch (FTreeDbAccessException exc)
            {
                throw new FTreePresenterException();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException();
            }
        }
        #endregion

        #region ULTILITY METHOD
        public string AddWithString()
        {
            try
            {
                string query = this._model.AddWithString();
                return query;
            }
            catch (FTreeDbAccessException exc)
            {
                throw new FTreePresenterException();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException();
            }
        }
        public Array AddWithArray()
        {
            try
            {
                Array query = this._model.AddWithArray();
                return query;
            }
            catch (FTreeDbAccessException exc)
            {
                throw new FTreePresenterException();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException();
            }
        }
        public List<MEMBER_EVENT> Add()
        {
            try
            {
                List<MEMBER_EVENT> query = this._model.Add();
                this.listAchievment = query;
                return query;
            }
            catch (FTreeDbAccessException exc)
            {
                throw new FTreePresenterException();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException();
            }
        }
        #endregion

        

        #region VARIABLE
        //public System.Windows.Forms.DataGridView dgview;
        public List<MEMBER_EVENT> listAchievment;
           
        #endregion
    }
}
