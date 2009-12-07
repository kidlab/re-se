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
            toolTip1.SetToolTip(maskedTextBox1, "You can just enter 4 numbers");
            toolTip1.SetToolTip(maskedTextBox2, "You can just enter 4 numbers");
        }

        private void FamilyReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<FamilyReportDTO> list_arDTO = this._presenter.FamilyReport(Int32.Parse(this.maskedTextBox1.Text), Int32.Parse(this.maskedTextBox2.Text));
            dataGridView1.DataSource = list_arDTO;
            dataGridView1.Refresh();
        }

        
        #region IView Members

        public string ViewName
        {
            get { throw new NotImplementedException(); }
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
            throw new NotImplementedException();
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
