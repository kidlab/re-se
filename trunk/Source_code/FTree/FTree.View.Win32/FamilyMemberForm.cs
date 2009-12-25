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
    public partial class FamilyMemberForm : BaseDialogForm, IFamilyMemberView, IValidator
    {
        #region VARIABLES

        private FamilyMemberPresenter _presenter;

        private IList<HomeTownDTO> _homeTowns;
        private IList<JobDTO> _careersList;
        private FamilyMemberDTO _currentMember;
        private IList<FamilyMemberDTO> _familyMembers;
        private IList<RelationTypeDTO> _relationTypesList;
        private RelationTypeDTO _selectedRelationType;
        private RelationTypeDTO _currentRelationType;
        private FamilyMemberDTO _relativePerson;
        private FamilyMemberDTO _selectedRelativePerson;
        private bool _isRootPerson = false;
        private FamilyDTO _family;
        private DataFormMode _mode = DataFormMode.CreateNew;
        private ListResultForm _frmResult;
        private AchievementInfo _selectedAchievementInfo;
        private bool _isAhievementLoaded = false;
        private BindingSource _bindingSource;

        /// <summary>
        /// Used to store the previous color of DataGridViewRow 
        /// to change the BackColor when mouse enters and restore the color when mouse leaves.
        /// </summary>
        private Color _previousRowColor;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Create new instance of FamilyMemberForm with the default settings.
        /// </summary>
        public FamilyMemberForm()
        {
            InitializeComponent();
            _initDataGridViewMouseHoverEvents();
            _bindingSource = new BindingSource();
        }

        /// <summary>
        /// Create a new instance of FamilyMemberForm with a specific family object. 
        /// </summary>
        /// <param name="isCreatingRootPerson">Determines that the person if the root person of the family or not.</param>
        /// <param name="family">The family containing the person.</param>
        public FamilyMemberForm(bool isCreatingRootPerson, FamilyDTO family)
            : this()
        {
            _isRootPerson = isCreatingRootPerson;
            _family = family;
        }

        /// <summary>
        /// Create a new instance of FamilyMemberForm with a specific family member object. 
        /// </summary>
        /// <param name="relativePerson">The person associating with this person.</param>
        public FamilyMemberForm(FamilyMemberDTO relativePerson)
            : this()
        {
            _relativePerson = relativePerson;
            _family = _relativePerson.Family;
        }

        /// <summary>
        /// Create a new instance of FamilyMemberForm with a specific family member object,
        /// and his/her relative person.
        /// This means that the form will allow user to edit/update the specified 'person' information.
        /// </summary>
        /// <param name="relativePerson">The person associating with 'person'.
        /// Leave this param null to show the information of the root person.</param>
        /// <param name="person">The person need updating profile.</param>
        public FamilyMemberForm(FamilyMemberDTO relativePerson, FamilyMemberDTO person)
            : this()
        {
            _relativePerson = relativePerson;
            _currentMember = person;
            _family = _currentMember.Family;

            if (relativePerson == null)
                _isRootPerson = true;

            _mode = DataFormMode.Edit;
        }

        #endregion

        #region UI EVENTS

        private void FamilyMemberForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);
                ThreadHelper.DoWork(_loadPersonalData);

                if (_isRootPerson)
                {
                    this.lblRootPersonWarning.Visible = true;
                    this.gbxRelationship.Enabled = false;
                }

                if (_familyMembers == null || _familyMembers.Count <= 0)
                {
                    this.txtSearch.Enabled = false;
                    this.btnSearch.Enabled = false;
                }

                if (_mode == DataFormMode.Edit)
                {
                    this.Text = "Edit Person Profile";
                    if (!personInfoTabControl.TabPages.Contains(achievementTab))
                        this.personInfoTabControl.TabPages.Add(achievementTab);
                }
                else
                {
                    this.personInfoTabControl.TabPages.Remove(achievementTab);
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(exc.Message);
            }
        }

        private void personInfoTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mode == DataFormMode.Edit
                    && personInfoTabControl.SelectedTab == achievementTab
                    && !_isAhievementLoaded)
            {
                ThreadHelper.DoWork(_loadAchievements);
                _setAchieveDataBindings();
                _checkAchievementDataGrid();
                _isAhievementLoaded = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateInputData())
                    return;

                switch (_mode)
                {
                    case DataFormMode.Edit:
                        if (_isDataChanged())
                        {
                            if (!_acceptDuplicatedPerson())
                                return;

                            _generateDTO();
                            ThreadHelper.DoWork(_presenter.Update);
                        }

                        break;

                    case DataFormMode.CreateNew:
                        _generateDTO();

                        if (!_acceptDuplicatedPerson())
                            return;

                        if (!_checkRelationshipConstraint())
                            return;
                        _addNewPerson();
                        break;

                    default:
                        return;
                }

                if (_isRootPerson)
                    _family.RootPerson = _currentMember;

                if (!_presenter.AutoSubmitChanges)
                {
                    ThreadHelper.DoWork(_presenter.SaveAllChanges);
                }

                //UIUtils.Info("Person Added Successfully!");
                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_PERSON_FAILED));
            }
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
                    || !(sender is DataGridView))
                return;

            DataGridView dg = sender as DataGridView;

            if (dg.Rows.Count < 0)
                return;

            _previousRowColor = dg.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            dg.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
                    || !(sender is DataGridView))
                return;

            DataGridView dg = sender as DataGridView;

            if (dg.Rows.Count < 0)
                return;

            dg.Rows[e.RowIndex].DefaultCellStyle.BackColor = _previousRowColor;
        }

        #region TAB PERSON INFO

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _simpleSearchPerson();
        }

        private void cbRelativePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRelativePerson.SelectedItem != null)
                _selectedRelativePerson = cbRelativePerson.SelectedItem as FamilyMemberDTO;
        }

        private void cbRelationshipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRelationshipType.SelectedItem != null)
            {
                _selectedRelationType = cbRelationshipType.SelectedItem as RelationTypeDTO;

                if (_selectedRelationType != null)
                {
                    string name = _selectedRelationType.Name.ToUpper();
                    if (name == DefaultSettings.RelationType.Child.ToString().ToUpper())
                    {
                        this.lblMarriageDate.Visible = false;
                        this.marriageDatePicker.Visible = false;
                        this.marriageDatePicker.Enabled = false;
                    }
                    else if (name == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
                    {
                        this.lblMarriageDate.Visible = true;
                        this.marriageDatePicker.Visible = true;
                        this.marriageDatePicker.Enabled = true;

                        if (_selectedRelativePerson != null)
                        {
                            if (_selectedRelativePerson.IsFemale)
                                rbMale.Checked = true;
                            else
                                rbFemale.Checked = true;
                        }
                    }
                }
            }
        }
        
        private void btnShowDeathInfo_Click(object sender, EventArgs e)
        {
            _showDeathInfo();
        }

        private void btnDeleteDeathInfo_Click(object sender, EventArgs e)
        {
            _deleteDeathInfo();
        }

        #endregion

        #region TAB ACHIEVEMENTS

        private void btnAddAchievement_Click(object sender, EventArgs e)
        {
            _addAchievement();
        }

        private void btnEditAchievement_Click(object sender, EventArgs e)
        {
            _editAchievement();
        }

        private void btnDeleteAchievement_Click(object sender, EventArgs e)
        {
            _deleteAchievement();
        }

        private void dgAchievements_SelectionChanged(object sender, EventArgs e)
        {
            if (_checkAchievementDataGrid())
            {
                int achievementID = (int)dgAchievements.CurrentRow.Cells[FTreeConst.ID_FIELD].Value;
                _selectedAchievementInfo =
                    _currentMember.Achievements.SingleOrDefault(achieve => achieve.ID == achievementID);
            }
        }

        #endregion

        #endregion

        #region CORE METHODS

        private void _loadPersonalData()
        {
            try
            {              
                // Firstly, load all necessary parameters.
                _presenter.LoadAllParameters();
                
                if (_mode == DataFormMode.Edit)
                {
                    // Bind data to associate controls.
                    this.Invoke(new ThreadHelper.VoidDelegate(_loadPersonProfile));

                    if (_relativePerson != null && !_isRootPerson)
                    {
                        _selectedRelativePerson = _relativePerson;
                        _currentRelationType = _presenter.GetRelationship();
                    }
                    _presenter.LoadRelativeMembers(true);                    
                }
                else
                {
                    if (_relativePerson != null)
                    {
                        _familyMembers = new List<FamilyMemberDTO>();
                        _familyMembers.Add(_relativePerson);
                    }
                    else if (!_isRootPerson)
                        _presenter.LoadRelativeMembers(false);
                }                

                if (_family != null)
                    lblFamilyName.Text = _family.Name;

                cbRelativePerson.DataSource = _familyMembers;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _loadPersonProfile()
        {
            if (_currentMember == null)
                return;

            // If this person is not the root person.
            if (_currentRelationType != null)
            {
                this.cbRelationshipType.SelectedItem = _currentRelationType;
                _selectedRelationType = _currentRelationType;
            }

            this.rbFemale.Checked = _currentMember.IsFemale;
            this.rbMale.Checked = !_currentMember.IsFemale;
            this.txtFirstname.Text = _currentMember.FirstName;
            this.txtLastname.Text = _currentMember.LastName;
            this.birthdayPicker.Value = _currentMember.Birthday;
            this.birthtimePicker.Value = _currentMember.Birthday;

            if (_currentMember.HomeTown != null)
                this.cbHomeTown.SelectedItem = _currentMember.HomeTown;

            if (_currentMember.Job != null)
                this.cbOccupation.SelectedItem = _currentMember.Job;

            this.txtAddress.Text = _currentMember.Address;
            this.dateJointPicker.Value = _currentMember.DateJointFamily;

            bool isEnableDeathControls = (_currentMember != null && _currentMember.IsDead);
            _setupDeathAtmosphere(isEnableDeathControls);         
        }

        private void _loadAchievements()
        {
            try
            {
                _presenter.GetAllAchievements();                
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _addNewPerson()
        {
            if (_isRootPerson)
                _currentMember.GenerationNumber = 1;            

            // Add new person.
            ThreadHelper.DoWork(_presenter.Add);
        }

        private void _addAchievement()
        {   
            AchievementForm frmAchievement = new AchievementForm(_currentMember);
            frmAchievement.SetAutoSave(false);
            if (frmAchievement.ShowDialog(false) == DialogResult.OK)
            {
                _bindingSource.ResetBindings(false);
                _formatDataGridViewRowColor();
            }
        }

        private void _editAchievement()
        {
            AchievementForm frmAchievement = new AchievementForm(_currentMember, _selectedAchievementInfo);
            frmAchievement.SetAutoSave(false);
            if (frmAchievement.ShowDialog(false) == DialogResult.OK)
            {
                _bindingSource.ResetBindings(false);
                _formatDataGridViewRowColor();
            }
        }

        private void _deleteAchievement()
        {
            try
            {
                // Ask for confirm.
                DialogResult result = UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_ENTRY));

                if (result != DialogResult.OK)
                    return;

                ThreadHelper.DoWork(_presenter.DeleteAchievement);                
                _bindingSource.ResetBindings(false);
                _formatDataGridViewRowColor();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #region UTILITY METHODS

        private void _setErrorToolTip(Control control, string message)
        {
            this.errorToolTip.SetToolTip(control, message);
            this.errorToolTip.Show(message, control, 3000);
        }

        private void _initPresenter()
        {
            _presenter = new FamilyMemberPresenter(this);

            if (_mode == DataFormMode.Edit)
                _presenter.AutoSubmitChanges = false;
            else
                _presenter.AutoSubmitChanges = true;
        }

        private void _generateDTO()
        {
            if (_currentMember == null)
                _currentMember = new FamilyMemberDTO();

            _currentMember.Family = _family;
            _currentMember.FirstName = txtFirstname.Text.Trim();
            _currentMember.LastName = txtLastname.Text.Trim();
            _currentMember.IsFemale = rbFemale.Checked;

            if(!String.IsNullOrEmpty(txtAddress.Text.Trim()))
                _currentMember.Address = txtAddress.Text.Trim();

            if (cbHomeTown.SelectedItem != null)
                _currentMember.HomeTown = cbHomeTown.SelectedItem as HomeTownDTO;

            // Combines values of Birthday and Birthtime.
            DateTime birthday = new DateTime(
                birthdayPicker.Value.Year,
                birthdayPicker.Value.Month,
                birthdayPicker.Value.Day,
                birthtimePicker.Value.Hour,
                birthtimePicker.Value.Minute,
                birthtimePicker.Value.Second);

            _currentMember.Birthday = birthday;
            _currentMember.DateJointFamily = dateJointPicker.Value;

            if (cbOccupation.SelectedItem != null)
                _currentMember.Job = cbOccupation.SelectedItem as JobDTO;
            string name = _selectedRelationType.Name.ToUpper();

            if (name == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
            {
                _currentMember.MarriedDate = marriageDatePicker.Value;
            }

        }

        /// <summary>
        /// Detects that the person profile was changed or not (on edit mode).
        /// </summary>
        /// <returns>True if person information was changed, otherwise, returns False.</returns>
        private bool _isDataChanged()
        {
            // Test only.
            return true;
        }

        private void _setAchieveDataBindings()
        {
            _bindingSource.DataSource = _currentMember.Achievements;
            this.dgAchievements.DataSource = _bindingSource;

            // Hide some unnecessary columns.
            foreach (DataGridViewColumn col in dgAchievements.Columns)
            {
                switch (col.Name)
                {
                    case "AchievementType":
                        col.HeaderText = "Achievement Type";
                        col.Visible = true;
                        break;

                    case "Description":
                        col.Visible = true;
                        break;

                    case "AchievementDate":
                        col.Visible = true;
                        col.HeaderText = "Achievement Date";
                        break;

                    default:
                        col.Visible = false;
                        break;
                }
            }

            // Format the color of rows for easy-looking.
            _formatDataGridViewRowColor();
        }

        /// <summary>
        /// Format the color of rows for easy-looking.
        /// </summary>
        private void _formatDataGridViewRowColor()
        {
            for (int i = 0; i < dgAchievements.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dgAchievements.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
            }
        }

        private bool _checkAchievementDataGrid()
        {
            bool enabled = true;

            if (dgAchievements.DataSource == null
                    || dgAchievements.Columns.Count <= 0
                    || dgAchievements.Rows.Count <= 0)
                enabled = false;

            if (dgAchievements.SelectionMode == DataGridViewSelectionMode.FullRowSelect
                    && dgAchievements.SelectedRows.Count <= 0)
                enabled = false;
            else if (dgAchievements.SelectionMode != DataGridViewSelectionMode.FullRowSelect
                    && dgAchievements.CurrentRow == null)
                enabled = false;

            this.btnEditAchievement.Enabled = enabled;
            this.btnDeleteAchievement.Enabled = enabled;

            return enabled;
        }

        public void UpdateRelationship(FamilyMemberDTO person)
        {
            try
            {
                if (_relativePerson == null)
                    _relativePerson = _selectedRelativePerson;

                if (person == null
                        || _relativePerson == null
                        || _selectedRelationType == null)
                    return;

                FamilyMemberPresenter.CopyRelatives(_relativePerson, ref person);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_FIND_RELATIONSHIP_FAILED));
            }
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

            if (cbRelativePerson.Items.Contains(_frmResult.SelectedItem))
                cbRelativePerson.SelectedItem = _frmResult.SelectedItem;
            else
            {
                FamilyMemberDTO person = _frmResult.SelectedItem as FamilyMemberDTO;

                IEnumerable<FamilyMemberDTO> matches =
                    from p in _familyMembers
                    where p.ID == person.ID
                    select p;

                FamilyMemberDTO resultPerson = matches.Single();
                this.cbRelativePerson.SelectedItem = resultPerson;
            }
        }

        /// <summary>
        /// Assigns MouseLeave and MouseEnter events for each data grid views in this form.
        /// </summary>
        private void _initDataGridViewMouseHoverEvents()
        {
            dgAchievements.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView_CellMouseEnter);
            dgAchievements.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView_CellMouseLeave);
        }

        private void _showDeathInfo()
        {
            if (_currentMember == null
                    || !_currentMember.IsDead
                    || _currentMember.DeathInfo == null)
                return;

            SadNewsForm frmSadNews = new SadNewsForm(_currentMember, false);
            frmSadNews.SetAutoSave(false);
            frmSadNews.ShowDialog(false);
        }

        private void _deleteDeathInfo()
        {
            try
            {
                // Ask for confirm.
                DialogResult result = UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_ENTRY));

                if (result != DialogResult.OK)
                    return;

                ThreadHelper.DoWork(_presenter.DeleteDeathInfo);
                _setupDeathAtmosphere(false);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        private void _setupDeathAtmosphere(bool enabled)
        {
            this.lblDeathInfo.Enabled = enabled;
            this.lblDeathInfo.Visible = enabled;

            this.btnShowDeathInfo.Enabled = enabled;
            this.btnShowDeathInfo.Visible = enabled;

            this.btnDeleteDeathInfo.Enabled = enabled;
            this.btnDeleteDeathInfo.Visible = enabled;

            if (enabled)
                this.BackColor = UIUtils.SAD_PINK_COLOR; 
            else
                this.BackColor = System.Drawing.SystemColors.Control;
        }

        private bool _checkRelationshipConstraint()
        {
            if (_selectedRelativePerson == null)
                return true;

            string name = _selectedRelationType.Name.ToUpper();

            #region Check Spouses > 1

            if (name == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
            {
                bool hasSpouse = false;
                if (_selectedRelativePerson.Spouses != null && _selectedRelativePerson.Spouses.Count > 0)
                    hasSpouse = true;
                else 
                    hasSpouse = _presenter.CheckPersonHasSpouse();

                if (hasSpouse && _selectedRelativePerson.IsFemale)
                {
                    DialogResult result =
                        UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_MORE_THAN_ONE_HUSBAND));
                    if (result == DialogResult.Cancel)
                        return false;
                }
                else if (hasSpouse && !_selectedRelativePerson.IsFemale)
                {
                    DialogResult result =
                        UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_MORE_THAN_ONE_WIFE));
                    if (result == DialogResult.Cancel)
                        return false;
                }
            }

            #endregion

            #region Check no wife/husband but add new child.

            if (name == DefaultSettings.RelationType.Child.ToString().ToUpper())
            {
                bool hasSpouse = false;
                if (_selectedRelativePerson.Spouses != null && _selectedRelativePerson.Spouses.Count > 0)
                    hasSpouse = true;
                else
                    hasSpouse = _presenter.CheckPersonHasSpouse();

                if (!hasSpouse)
                {
                    string message = String.Format(Util.GetStringResource(StringResName.MSG_NO_SPOUSE_BUT_HAS_CHILD), _selectedRelativePerson.ToString());
                    DialogResult result =
                        UIUtils.ConfirmOKCancel(message);
                    if (result == DialogResult.Cancel)
                        return false;
                }
            }

            #endregion

            #region Check person was died but was added as relative.

            if (_selectedRelativePerson.IsDead)
            {
                string message = String.Format(Util.GetStringResource(StringResName.MSG_ADD_RELATIVE_ON_DIED_PERSON), _selectedRelativePerson.ToString());
                DialogResult result =
                    UIUtils.ConfirmOKCancel(message);
                if (result == DialogResult.Cancel)
                    return false;
            }

            #endregion

            return true;
        }

        private bool _acceptDuplicatedPerson()
        {
            int num = _presenter.CountPersonByFullname(_currentMember.ToString());
            if ((_mode == DataFormMode.CreateNew && num > 0)
                    || (_mode == DataFormMode.Edit && num > 1))
            {
                string message = String.Format(Util.GetStringResource(StringResName.MSG_DUPLICATED_PEOPLE), _currentMember.ToString());
                DialogResult result = UIUtils.ConfirmOKCancel(message);
                if (result == DialogResult.Cancel)
                    return false;
            }

            return true;
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get
            {
                return this.ToString();
            }
        }

        #endregion

        #region IValidator Members

        public bool ValidateInputData()
        {
            if (!_isRootPerson)
            {
                if (this.cbRelativePerson.SelectedIndex < 0
                    && (this.cbRelationshipType.SelectedIndex < 0
                            || this.cbRelationshipType.SelectedIndex >= 0))
                {
                    _setErrorToolTip(cbRelativePerson, Util.GetStringResource(StringResName.MSG_FINISH_RELATIONSHIP));
                    return false;
                }

                if (this.cbRelationshipType.SelectedIndex < 0
                    && (this.cbRelativePerson.SelectedIndex < 0
                            || this.cbRelativePerson.SelectedIndex >= 0))
                {
                    _setErrorToolTip(cbRelativePerson, Util.GetStringResource(StringResName.MSG_FINISH_RELATIONSHIP));
                    return false;
                }

                if (((_selectedRelativePerson.IsFemale && rbFemale.Checked)
                        || (!_selectedRelativePerson.IsFemale && rbMale.Checked))
                    && _selectedRelationType.Name.ToUpper() == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
                {
                    _setErrorToolTip(rbMale, Util.GetStringResource(StringResName.ERR_SPOUSE_HAS_SAME_GENDER));
                    return false;
                }

                if (_selectedRelationType.Name.ToUpper() == DefaultSettings.RelationType.Child.ToString().ToUpper())
                {
                    if (_selectedRelativePerson.Birthday.CompareTo(birthdayPicker.Value) >= 0)
                    {
                        _setErrorToolTip(birthdayPicker, Util.GetStringResource(StringResName.MSG_INVALID_AGE_CHILD_PARENT));
                        return false;
                    }
                }
            }

            if (!rbFemale.Checked && !rbMale.Checked)
            {
                _setErrorToolTip(rbMale, Util.GetStringResource(StringResName.MSG_SELECT_GENDER));
                return false;
            }            
          
            if (String.IsNullOrEmpty(txtFirstname.Text.Trim()))
            {
                _setErrorToolTip(txtFirstname, Util.GetStringResource(StringResName.MSG_ENTER_FIRSTNAME));
                return false;
            }

            if (String.IsNullOrEmpty(txtLastname.Text.Trim()))
            {
                _setErrorToolTip(txtLastname, Util.GetStringResource(StringResName.MSG_ENTER_LASTNAME));
                return false;
            }

            if (birthdayPicker.Value.Date.CompareTo(DateTime.Now.Date) > 0)
            {
                _setErrorToolTip(birthdayPicker, Util.GetStringResource(StringResName.ERR_INVALID_BIRTHDAY));
                return false;
            }

            if ((dateJointPicker.Value.Date.CompareTo(DateTime.Now.Date) > 0)
                    || (dateJointPicker.Value.Date.CompareTo(birthdayPicker.Value.Date) < 0))
            {
                _setErrorToolTip(birthdayPicker, Util.GetStringResource(StringResName.ERR_INVALID_DATE));
                return false;
            }

            return true;
        }

        #endregion

        #region IFamilyMemberView Members

        public FamilyMemberDTO FamilyMember
        {
            get
            {
                return _currentMember;
            }
            set
            {
                _currentMember = value;
            }
        }

        public FamilyDTO Family
        {
            get
            {
                return _family;
            }
            set
            {
                _family = value;
            }
        }

        public FamilyMemberDTO RelativePerson
        {
            get
            {
                return _selectedRelativePerson;
            }
            set
            {
                _selectedRelativePerson = value;
            }
        }

        public IList<HomeTownDTO> HomeTownsList
        {
            set
            {
                if (value == _homeTowns)
                    return;

                _homeTowns = value;
                cbHomeTown.DataSource = _homeTowns;
            }
        }

        public IList<JobDTO> CareersList
        {
            set
            {
                if (value == _careersList)
                    return;

                _careersList = value;
                cbOccupation.DataSource = _careersList;
            }
        }

        public IList<FamilyMemberDTO> FamilyMembers
        {
            get
            {
                return _familyMembers;
            }
            set
            {
                if (value == _familyMembers)
                    return;

                _familyMembers = value;
                cbRelativePerson.DataSource = _familyMembers;
            }
        }

        public IList<RelationTypeDTO> RelationTypesList
        {
            set
            {
                if (value == _relationTypesList)
                    return;

                _relationTypesList = value;
                cbRelationshipType.DataSource = _relationTypesList;
            }
        }

        public RelationTypeDTO RelationType
        {
            get
            {
                return _selectedRelationType;
            }
            set
            {
                _selectedRelationType = value;
            }
        }

        public AchievementInfo SelectedAchievementInfo
        {
            get
            {
                return _selectedAchievementInfo;
            }
            set
            {
                _selectedAchievementInfo = value;
            }
        }

        #endregion
    }
}
