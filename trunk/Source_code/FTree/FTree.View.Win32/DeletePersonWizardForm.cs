using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Common;
using FTree.Presenter;
using FTree.DTO;

namespace FTree.View.Win32
{
    public partial class DeletePersonWizardForm : BaseDialogForm
    {
        private FamilyMemberDTO _person;

        public DeletePersonWizardForm(FamilyMemberDTO person)
        {
            InitializeComponent();
            _person = person;
        }

        private void DeletePersonWizardForm_Load(object sender, EventArgs e)
        {
            this.rbDeleEntirelyPerson.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_deletePerson);
                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(DeletePersonWizardForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeletePersonWizardForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        private void _deletePerson()
        {
            if (rbDeleEntirelyPerson.Checked)
            {
                FamilyManagerPresenter.DeletePerson(_person);
            }
            else if (rbDelKeepSpouse.Checked)
            {
                FamilyManagerPresenter.DeleteKeepSpouse(_person);
            }
            else if (rbDelKeepSpouseChildren.Checked)
            {
                FamilyManagerPresenter.DeleteKeepSpouseAndChildren(_person);
            }
            else if (rbDelKeepChildren.Checked)
            {
                FamilyManagerPresenter.DeleteKeepChildren(_person);
            }
        }
    }
}
