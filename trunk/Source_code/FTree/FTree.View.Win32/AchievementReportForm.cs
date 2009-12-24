using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Presenter;
using FTree.DTO;
using FTree.Common;

namespace FTree.View.Win32
{
    /// <summary>
    ///  3. *** view thay model 
    ///  5. *** DTO - IView -IModel
    /// </summary>
    public partial class AchievementReportForm : BaseDialogForm, IAchievementReportView, IValidator
    {
        #region VARIABLES

        private AchievementReportPresenter _presenter;

        #endregion

        #region CONSTRUCTOR

        public AchievementReportForm()
        {
            InitializeComponent();
            _presenter = new AchievementReportPresenter(this);
            toolTip.SetToolTip(txtFromYear, "You can just enter 4 numbers");
            toolTip.SetToolTip(txtToYear, "You can just enter 4 numbers");
        }

        #endregion

        #region UI EVENTS

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidateInputData())
                    return;
                List<AchievementReportDTO> list_arDTO = this._presenter.AchievementReport(Int32.Parse(this.txtFromYear.Text), Int32.Parse(this.txtToYear.Text));
                dgResult.DataSource = list_arDTO;
                dgResult.Refresh();
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementReportForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_CREATE_REPORT_FAILED));
            }
        }

        #endregion        

        #region IAchievementReportView Members

        public DataGridView dgview
        {
            get
            {
                return dgview;
            }
            set
            {
                this.dgview = value;
            }
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion

        #region IReport<AchievementReportDTO> Members

        public DateTime FromDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime ToDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<AchievementReportDTO> GetReportByYear()
        {
            throw new NotImplementedException();
        }

        public IList<AchievementReportDTO> GetReportByMonthYear()
        {
            throw new NotImplementedException();
        }

        public IList<AchievementReportDTO> GetReportByDayMonthYear()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IValidator Members

        public bool ValidateInputData()
        {
            if (String.IsNullOrEmpty(this.txtFromYear.Text.Trim()))
            {
                MessageBox.Show("Enter From Year");
                return false;
            }
            if (String.IsNullOrEmpty(this.txtToYear.Text.Trim()))
            {
                MessageBox.Show("Enter To Year");
                return false;
            }
            return true;
        }

        #endregion        
    }
}
