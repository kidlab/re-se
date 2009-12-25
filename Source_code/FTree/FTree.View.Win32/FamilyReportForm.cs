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
//using FTree.Model;

namespace FTree.View.Win32
{
    public partial class FamilyReportForm : BaseDialogForm, IFamilyReportView, IValidator
    {
        private FamilyReportPresenter _presenter;

        public FamilyReportForm()
        {
            InitializeComponent();
            this._presenter = new FamilyReportPresenter(this);
            toolTip.SetToolTip(txtFromYear, "You can just enter 4 numbers");
            toolTip.SetToolTip(txtToYear, "You can just enter 4 numbers");
        }

        private void FamilyReport_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputData())
                    return;
                List<FamilyReportDTO> list_arDTO = this._presenter.FamilyReport(Int32.Parse(this.txtFromYear.Text), Int32.Parse(this.txtToYear.Text));
                dgResult.DataSource = list_arDTO;
                dgResult.Refresh();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyReportForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_CREATE_REPORT_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyReportForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_CREATE_REPORT_FAILED));
            }
        }
        
        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion

        #region IReport<FamilyReportDTO> Members

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

        public IList<FamilyReportDTO> GetReportByYear()
        {
            throw new NotImplementedException();
        }

        public IList<FamilyReportDTO> GetReportByMonthYear()
        {
            throw new NotImplementedException();
        }

        public IList<FamilyReportDTO> GetReportByDayMonthYear()
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

        #region IFamilyReportView Members

        public DataGrid datagrid
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

        #endregion
    }
}
