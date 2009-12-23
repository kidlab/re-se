using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;

namespace FTree.Presenter.ViewModel
{
    public class FamilyViewModel : TreeViewItemViewModel
    {
        #region VARIABLES

        private readonly FamilyDTO _family;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the FamilyDTO object associating with this object.
        /// </summary>
        public FamilyDTO Family
        {
            get { return _family; }
        }

        public string FamilyName
        {
            get { return _family.Name; }
            set
            {
                if (value != _family.Name)
                {
                    _family.Name = value;
                    this.OnPropertyChanged("FamilyName");
                }
            }
        }

        /// <summary>
        /// Returns a value indicating whether the specified 
        /// System.String object occurs within this string.
        /// </summary>
        /// <param name="text">String need finding.</param>
        /// <returns>True if the param string occurs in this string.</returns>
        public bool NameContainsText(string text, bool matchCase)
        {
            if (String.IsNullOrEmpty(text) 
                    || String.IsNullOrEmpty(this.FamilyName))
                return false;

            StringComparison condition = StringComparison.InvariantCultureIgnoreCase;

            if (matchCase)
                condition = StringComparison.InvariantCulture;

            return this.FamilyName.IndexOf(text, condition) > -1;
        }

        #endregion

        #region CONSTRUCTOR

        public FamilyViewModel(FamilyDTO family)
            : base(null, true)
        {
            _family = family;
        }

        #endregion

        #region CORE METHODS

        protected override void LoadChildren()
        {
            if (_family.RootPerson == null)
                return;

            base.Children.Add(new PersonViewModel(_family.RootPerson, this));  
        }

        #endregion
    }
}
