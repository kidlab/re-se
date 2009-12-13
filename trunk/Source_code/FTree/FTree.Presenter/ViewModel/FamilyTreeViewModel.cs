using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Presenter.ViewModel
{
    /// <summary>
    /// This is the View-Model of the FamilyTree. It provides a data source
    /// for the TreeView (the FirstGeneration property), a bindable
    /// SearchText property, and the SearchCommand to perform a search.
    /// </summary>
    public class FamilyTreeViewModel
    {
        #region VARIABLES

        private readonly ObservableCollection<FamilyViewModel> _families;
        private FamilyViewModel _currentFamily;

        private IEnumerator<FamilyViewModel> _matchingFamiliesEnumerator;
        private IEnumerator<PersonViewModel> _matchingPeopleEnumerator;
        private string _searchText = String.Empty;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets/sets a fragment of the name to search for.
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText)
                    return;

                _searchText = value.Trim();

                _matchingPeopleEnumerator = null;
                _matchingFamiliesEnumerator = null;
            }
        }

        /// <summary>
        /// Returns a read-only collection containing the first person 
        /// in the family tree, to which the TreeView can bind.
        /// </summary>
        public ObservableCollection<FamilyViewModel> Families
        {
            get { return _families; }
        }

        #endregion

        #region CONSTRUCTOR

        public FamilyTreeViewModel(List<FamilyDTO> familes)
        {
            List<FamilyViewModel> tmpFamilies = new List<FamilyViewModel>();
            foreach (FamilyDTO family in familes)
                tmpFamilies.Add(new FamilyViewModel(family));
            _families = new ObservableCollection<FamilyViewModel>(tmpFamilies);
        }

        public FamilyTreeViewModel(ObservableCollection<FamilyViewModel> familes)
        {
            _families = familes;
        }

        #endregion

        #region CORE METHODS

        /// <summary>
        /// Search for the keywords of the property SearchText in this tree.
        /// </summary>
        /// <returns>True if found, otherwise returns False.</returns>
        public bool ExecuteSearch()
        {
            try
            {
                return _performSearch();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyTreeViewModel), exc);
                throw new FTreePresenterException(exc);
            }
        }

        /// <summary>
        /// Search for the keywords in this tree.
        /// </summary>
        /// <param name="keywords">Keywords needs searching.</param>
        /// <returns>True if found, otherwise returns False.</returns>
        public bool ExecuteSearch(string keywords)
        {
            try
            {
                SearchText = keywords;
                return _performSearch();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException(exc);
            }
        }

        private bool _performSearch()
        {
            if (String.IsNullOrEmpty(_searchText))
                return false;

            bool isFamilyFound = false;
            bool isPeopleFound = true;

            if (_matchingFamiliesEnumerator == null)
            {
                isFamilyFound = _verifyMatchingFamiliesEnumerator();

                if (isFamilyFound)
                {
                    _currentFamily = _matchingFamiliesEnumerator.Current;
                    _currentFamily.IsSelected = true;
                    _currentFamily.IsExpanded = true;
                }
            }
            else if (_matchingFamiliesEnumerator.MoveNext())
            {
                _currentFamily = _matchingFamiliesEnumerator.Current;
                _currentFamily.IsSelected = true;
                _currentFamily.IsExpanded = true;

                isFamilyFound = true;
            }
            // Not found anything in Families, so find it in People collection.
            if (!isFamilyFound && _matchingPeopleEnumerator == null)
            {
                isPeopleFound = _verifyMatchingPeopleEnumerator();

                if (isPeopleFound)
                {
                    var person = _matchingPeopleEnumerator.Current;
                    // Ensure that this person is in view.
                    person.Parent.IsExpanded = true;
                    person.IsSelected = true;
                }
            }
            else if (!isFamilyFound && _matchingPeopleEnumerator.MoveNext())
            {
                var person = _matchingPeopleEnumerator.Current;
                // Ensure that this person is in view.
                person.Parent.IsExpanded = true;
                person.IsSelected = true;
            }

            return isFamilyFound || isPeopleFound;
        }

        private bool _verifyMatchingFamiliesEnumerator()
        {
            var matches = this._findFamilyMatches(_searchText);
            _matchingFamiliesEnumerator = matches.GetEnumerator();

            if (!_matchingFamiliesEnumerator.MoveNext())
                return false;

            return true;
        }

        private bool _verifyMatchingPeopleEnumerator()
        {
            IEnumerable<PersonViewModel> matches = null;

            if (_currentFamily != null)
            {
                matches = _findPeopleMatches(_searchText, _currentFamily.Children.First() as PersonViewModel);
            }
            // No family was found, so we must try the last one: find in all families!
            else
            {
                matches = _findPeopleMatches(_searchText);
            }

            _matchingPeopleEnumerator = matches.GetEnumerator();

            if (!_matchingPeopleEnumerator.MoveNext())
                return false;

            return true;
        }

        private IEnumerable<FamilyViewModel> _findFamilyMatches(string searchText)
        {
            foreach (FamilyViewModel family in _families)
                if (family.NameContainsText(searchText, false))
                    yield return family;
        }

        /// <summary>
        /// This is a recursive methods that walks through the family tree 
        /// and finds matching people.
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        private IEnumerable<PersonViewModel> _findPeopleMatches(string searchText, PersonViewModel person)
        {
            if (person.NameContainsText(searchText, false))
                yield return person;

            // Expand this person to load all his children.
            person.IsExpanded = true;

            foreach (TreeViewItemViewModel child in person.Children)
            {
                PersonViewModel _child = child as PersonViewModel;
                foreach (PersonViewModel match in this._findPeopleMatches(searchText, _child))
                    yield return match;
            }

            person.IsExpanded = false;
        }

        /// <summary>
        /// This is a recursive methods that walks through all of the families
        /// in family tree and finds matching people.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        private IEnumerable<PersonViewModel> _findPeopleMatches(string searchText)
        {
            Stack<PersonViewModel> stack = new Stack<PersonViewModel>();
            List<PersonViewModel> result = new List<PersonViewModel>();
            bool matchCase = false;

            foreach (FamilyViewModel family in _families)
            {
                family.IsExpanded = true;

                PersonViewModel person = family.Children.First() as PersonViewModel;
                while (true)
                {
                    if (person.NameContainsText(searchText, matchCase))
                        result.Add(person);
                    
                    // Expand this person to load all his children.
                    person.IsExpanded = true;

                    foreach (TreeViewItemViewModel child in person.Children)
                    {
                        stack.Push(child as PersonViewModel);
                    }

                    if (stack.Count > 0)
                        person = stack.Pop();
                    else
                        break;

                    person.IsExpanded = false;
                }

                family.IsExpanded = false;
            }

            return result.AsEnumerable();
        }

        #endregion
    }
}
