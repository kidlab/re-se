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
    public partial class MemberListForm : BaseDialogForm, IFamilyMangerView
    {
        private FamilyDTO _currentFamily;
        private IList<FamilyMemberDTO> _familyMembers;
        private FamilyManagerPresenter _presenter;
        private BindingSource _bindingSoure;
        private ListResultForm _frmResult;

        public MemberListForm(FamilyDTO family)
        {
            InitializeComponent();
            _currentFamily = family;
            _bindingSoure = new BindingSource();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _simpleSearchPerson();
        }

        public void _simpleSearchPerson()
        {
            try
            {
                string keywords = txtSearch.Text.Trim().ToUpper();

                if (String.IsNullOrEmpty(keywords))
                    return;

                // First, try the best condition: fullname was correctly entered.
                IEnumerable<FamilyMemberDTO> matches1 =
                   from person in _familyMembers
                   where person.ToString().ToUpper().Contains(keywords)
                   select person;

                // Second, try to search by lastname.
                IEnumerable<FamilyMemberDTO> matches2 =
                   from person in _familyMembers
                   where person.LastName.ToUpper().Contains(keywords)
                   select person;

                // Then, try to seatch by firstname.
                IEnumerable<FamilyMemberDTO> matches3 =
                   from person in _familyMembers
                   where person.FirstName.ToUpper().Contains(keywords)
                   select person;

                // Combine all results.
                matches1 = matches1.Union(matches2);
                matches1 = matches1.Union(matches3);

                // Show the result.
                List<FamilyMemberDTO> results = matches1.ToList();
                if (results.Count > 0)
                {
                    if (_frmResult == null || _frmResult.IsDisposed)
                    {
                        _frmResult = new ListResultForm();
                        _frmResult.ListBoxSelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(_frmResult_ListBoxSelectionChanged);
                    }
                    _frmResult.ClearListBox();

                    foreach (FamilyMemberDTO person in results)
                        _frmResult.AddItem(person);

                    // Set the location of the result form near to the button "Search".
                    Point p = new Point();
                    p.X = this.Location.X + this.btnSearch.Location.X + this.btnSearch.Width;
                    p.Y = this.Location.Y + this.btnSearch.Location.Y + this.btnSearch.Height;
                    _frmResult.Location = p;

                    if (!_frmResult.Visible)
                        _frmResult.Show(this);
                    else
                        _frmResult.BringToFront();
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
            }
        }

        private void _frmResult_ListBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_frmResult.SelectedItem == null
                    || !(_frmResult.SelectedItem is FamilyMemberDTO))
                return;


            FamilyMemberDTO person = _frmResult.SelectedItem as FamilyMemberDTO;

            for (int i = 0; i < dgMember.Rows.Count; i++)
            {
                int personID = (int)dgMember.Rows[0].Cells[FTreeConst.ID_FIELD].Value;
                if (personID == person.ID)
                {
                    dgMember.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// Format the color of rows for easy-looking.
        /// </summary>
        private void _formatDataGridViewRowColor()
        {
            for (int i = 0; i < dgMember.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dgMember.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
            }
        }

        #region IFamilyMangerView Members

        public IList<FamilyDTO> Families
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

        public FamilyDTO CurrentFamily
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion

        private void MemberListForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);
               _loadData();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _initPresenter()
        {
            _presenter = new FamilyManagerPresenter(this);
        }

        private void _loadData()
        {
            _familyMembers = _presenter.LoadALlMembers(_currentFamily.ID);
            IList<FamilyManagerPresenter.MemberReportItem> report = _presenter.GetFamilyMemberReport(_familyMembers);

            _bindingSoure.DataSource = report;
            dgMember.DataSource = report;

            _formatDataGridView();
        }

        private void _formatDataGridView()
        {
            // Hide some unnecessary columns.
            foreach (DataGridViewColumn col in dgMember.Columns)
            {
                switch (col.Name)
                {
                    case "Number":
                        col.HeaderText = "#";
                        col.Visible = true;
                        break;

                    case "FullName":
                        col.Visible = true;
                        break;

                    case "BirthDay":
                        col.Visible = true;
                        break;

                    case "GenLevel":
                        col.Visible = true;
                        col.HeaderText = "Generation Level";
                        break;

                    case "FatherName":
                        col.Visible = true;
                        col.HeaderText = "Father Name";
                        break;

                    case "MotherName":
                        col.Visible = true;
                        col.HeaderText = "Mother Name";
                        break;

                    default:
                        col.Visible = false;
                        break;
                }
            }
        }
    }
}
