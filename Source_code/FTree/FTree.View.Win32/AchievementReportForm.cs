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
        #region CONSTRUCTOR
        public AchievementReportForm()
        {
            InitializeComponent();
            _presenter = new AchievementReportPresenter(this);
            toolTip1.SetToolTip(maskedTextBox1, "You can just enter 4 numbers");
            toolTip1.SetToolTip(maskedTextBox2, "You can just enter 4 numbers");

            //ListViewItem item1 = new ListViewItem("Something");
            //item1.SubItems.Add("SubItem1a");
            //item1.SubItems.Add("SubItem1b");

            //ListViewItem item2 = new ListViewItem("Something2");
            //item2.SubItems.Add("SubItem2a");
            //item2.SubItems.Add("SubItem2a");

            //ListViewItem item3 = new ListViewItem("Somethin3");
            //item3.SubItems.Add("SubItem3a");
            //item3.SubItems.Add("SubItem3a");

            //listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            
          //  var query =          from book in books
          //where book.Length > 10
          //orderby book
          //select new { Book = book.ToUpper() };

          //  dataGridView1.DataSource = query.ToList();
        }
        #endregion

        #region EVENT
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region VARIABLES

        private AchievementReportPresenter _presenter;
        

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
            get { throw new NotImplementedException(); }
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
            if (String.IsNullOrEmpty(this.maskedTextBox1.Text.Trim()))
            {
                MessageBox.Show("Enter From Year");
                return false;
            }
            if (String.IsNullOrEmpty(this.maskedTextBox2.Text.Trim()))
            {
                MessageBox.Show("Enter To Year");
                return false;
            }
            return true;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputData())
                return;
            List<AchievementReportDTO> list_arDTO= this._presenter.AchievementReport(Int32.Parse(this.maskedTextBox1.Text), Int32.Parse(this.maskedTextBox2.Text));
            dataGridView1.DataSource = list_arDTO;        
            dataGridView1.Refresh();                     
        }
        
    }
}
