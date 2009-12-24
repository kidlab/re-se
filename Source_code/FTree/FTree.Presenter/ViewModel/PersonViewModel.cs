using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;

namespace FTree.Presenter.ViewModel
{
    /// <summary>
    /// A UI-friendly wrapper around a Person object that implements the View-Model patterns.
    /// </summary>
    public class PersonViewModel : TreeViewItemViewModel
    {
        #region VARIABLES

        private readonly FamilyMemberDTO _person;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the FamilyMemberDTO object associating with this object.
        /// </summary>
        public FamilyMemberDTO Person
        {
            get { return _person; }
        }

        public string FullName
        {
            get { return _person.LastName + " " + _person.FirstName ; }
        }

        public string FirstName
        {
            get { return _person.FirstName; }
        }

        public string LastName
        {
            get { return _person.LastName; }
        }

        public string SpouseName
        {
            get
            {
                if (_person.Spouses != null && _person.Spouses.Count > 0)
                    return " & " + _person.Spouses[0].ToString();
                return String.Empty;
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
                    || String.IsNullOrEmpty(this.FullName))
                return false;

            StringComparison condition = StringComparison.InvariantCultureIgnoreCase;

            if (matchCase)
                condition = StringComparison.InvariantCulture;

            return this.FullName.IndexOf(text, condition) > -1;
        }

        #endregion

        #region CONSTRUCTOR

        public PersonViewModel(FamilyMemberDTO person)
            : base(null, true)
        {
            _person = person;
        }

        public PersonViewModel(FamilyMemberDTO person, FamilyViewModel parent)
            : base(parent, true)
        {
            _person = person;
        }

        public PersonViewModel(FamilyMemberDTO person, PersonViewModel parent)
            : base(parent, true)
        {
            _person = person;
        }

        #endregion

        #region CORE METHODS

        protected override void LoadChildren()
        {
            if (_person.Descendants == null)
                return;

            foreach (FamilyMemberDTO person in _person.Descendants)
                base.Children.Add(new PersonViewModel(person, this));
        }

        #endregion
    }
}
