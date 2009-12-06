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
    public partial class AchievementReport : BaseDialogForm, IAchievementReportView, IValidator
    {
        #region CONSTRUCTOR
        public AchievementReport()
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

        public DateTime AchievementDate
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

        public AchievementType AchievementType
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

        public int Quantity
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

        public int AchievementYear
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

        public List<FTree.Model.MEMBER_EVENT> listAchieve
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
            throw new NotImplementedException();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //List<MEMBER_EVENT> query = this._presenter.Add();
            this._presenter.AchievementReport();
            //Array query = this._presenter.AddWithArray();
            //MessageBox.Show(query.ToString());
            //dataGridView1.DataSource = query.ToList();
            
            
            //dataGridView1.DataSource = this._presenter.listAchievment;
            dataGridView1.DataSource = this._presenter.listAchievment;
            //1. presenter trả về list
            // view -> presenter goi ham lay source ve day
            // presenter -> goi ham xu ly truy van
            // model -> truy van phai xu ly tum lum ne`, xu ly xong tao tra list member_event cho
            
            //2. presenter chứa datagridview
            //3. view thay model
        }
               
    }
}
