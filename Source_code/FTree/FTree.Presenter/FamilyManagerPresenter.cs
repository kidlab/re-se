using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.Model;
using FTree.DTO;
using FTree.Common;

namespace FTree.Presenter
{
    public class FamilyManagerPresenter : BasePresenter<IFamilyModel, IFamilyMangerView>
    {
        #region VARIABLES

        private bool _autoSubmit;

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not. The default value is False.
        /// </summary>
        /// <remarks>If False, you need to call SaveAllChanges after finishing all works.</remarks>
        public bool AutoSubmitChanges
        {
            get
            {
                return this._autoSubmit;
            }
            set
            {
                _autoSubmit = value;
                _model.AutoSubmitChanges = _autoSubmit;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public FamilyManagerPresenter(IFamilyModel model, IFamilyMangerView view)
        {
            _model = model;
            _view = view;

            _autoSubmit = false;

            // Turn off the auto-submit changes feature.
            _model.AutoSubmitChanges = _autoSubmit;
        }

        public FamilyManagerPresenter(IFamilyMangerView view)
            : this(new FamilyModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        public void LoadAllFamilies()
        {
            try
            {                
                _view.Families = _model.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_FAMILIES_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_FAMILIES_FAILED));
            }
        }

        /// <summary>
        /// Load the full family tree from the root person of current family.
        /// </summary>
        public void LoadFamilyTree()
        {
            try
            {
                if (_view.CurrentFamily == null
                        || _view.CurrentFamily.RootPerson == null)
                    return;

                _view.CurrentFamily.RootPerson = 
                    _model.LoadFullFamilyTree(_view.CurrentFamily.RootPerson.ID);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_FTREE_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_FTREE_FAILED));
            }
        }

        public void Add()
        {
            try
            {
                FamilyDTO dto = _view.CurrentFamily;

                if (CountFamilyWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_FAMILY_ALREADY_EXIST), dto.Name));

                _model.Add(dto);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_FAMILY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_FAMILY_FAILED));
            }
        }

        public void Update()
        {
            try
            {
                FamilyDTO dto = _view.CurrentFamily;

                if (CountFamilyWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_FAMILY_ALREADY_EXIST), dto.Name));

                _model.Update(_view.CurrentFamily);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_FAMILY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_FAMILY_FAILED));
            }
        }

        /// <summary>
        /// Delete entirely a family, included all its members.
        /// </summary>
        public void Delete()
        {
            try
            {
                if (_view.CurrentFamily.RootPerson != null)
                {
                    IFamilyMemberModel memModel = new FamilyMemberModel();
                    memModel.Delete(_view.CurrentFamily.RootPerson);
                }

                _model.Delete(_view.CurrentFamily);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_FAMILY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_FAMILY_FAILED));
            }
        }

        /// <summary>
        /// Delete entirely a member's information in DB.
        /// </summary>
        /// <param name="person"></param>
        public static void DeletePerson(FamilyMemberDTO person)
        {
            try
            {
                if (person == null)
                    return;

                IFamilyMemberModel memModel = new FamilyMemberModel();
                memModel.Delete(person);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Delete entirely a member's information in DB, included all its descendant and relationship, except spouses.
        /// </summary>
        /// <param name="person"></param>
        public static void DeleteKeepSpouse(FamilyMemberDTO person)
        {
            try
            {
                IFamilyMemberModel memModel = new FamilyMemberModel();

                // Keep all spouses of this person.
                // 1. Gets the parent of this person.
                FamilyMemberDTO relative = null;
                if (person.Father != null)
                    relative = person.Father;
                else if (person.Mother != null)
                    relative = person.Mother;
                else
                {
                    // Try to search in DB.
                    relative = memModel.GetParent(true, person);

                    if(relative == null)
                        relative = memModel.GetParent(false, person);
                }

                if (relative != null && person.Spouses != null)
                {
                    RelationTypeModel typeModel = new RelationTypeModel();
                    RelationTypeDTO relationType = typeModel.FindByName(DefaultSettings.RelationType.Child.ToString()).Single();

                    // 2. Add relationship between spouses and parent.
                    foreach (FamilyMemberDTO spouse in person.Spouses)
                        memModel.AddRelative(spouse, relative, relationType);
                }

                memModel.Delete(person);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Delete a member's information in DB, except spouses and children.
        /// </summary>
        /// <param name="person"></param>
        public static void DeleteKeepSpouseAndChildren(FamilyMemberDTO person)
        {
            try
            {
                IFamilyMemberModel memModel = new FamilyMemberModel();

                if (person.Spouses != null && person.Spouses.Count > 0)
                {
                    // Keep all spouses and children of this person.
                    // 1. Gets the parent of this person.
                    FamilyMemberDTO relative = null;
                    if (person.Father != null)
                        relative = person.Father;
                    else if (person.Mother != null)
                        relative = person.Mother;
                    else
                    {
                        // Try to search in DB.
                        relative = memModel.GetParent(true, person);

                        if (relative == null)
                            relative = memModel.GetParent(false, person);
                    }

                    RelationTypeModel typeModel = new RelationTypeModel();
                    RelationTypeDTO relationType = typeModel.FindByName(DefaultSettings.RelationType.Child.ToString()).Single();

                    if (relative != null)
                    {                       

                        // 2. Add relationship between spouses and parent.
                        foreach (FamilyMemberDTO spouse in person.Spouses)
                            memModel.AddRelative(spouse, relative, relationType);
                    }

                    // 3. Add relationship between spouse and children.
                    foreach (FamilyMemberDTO child in person.Descendants)
                        memModel.AddRelative(child, person.Spouses[0], relationType);
                }

                memModel.Delete(person);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Delete a member's information in DB, then shift all his children to a new one.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="newParent">The new person will manage the children of the deleted person.</param>
        public static void DeleteKeepChildren(FamilyMemberDTO person)
        {
            try
            {
                if (person == null)
                    return;

                IFamilyMemberModel memModel = new FamilyMemberModel();

                // 1. Gets the parent of this person.
                FamilyMemberDTO newParent = null;
                if (person.Father != null)
                    newParent = person.Father;
                else if (person.Mother != null)
                    newParent = person.Mother;
                else
                {
                    // Try to search in DB.
                    newParent = memModel.GetParent(true, person);

                    if (newParent == null)
                        newParent = memModel.GetParent(false, person);
                }


                if (newParent != null)
                {
                    RelationTypeModel typeModel = new RelationTypeModel();
                    RelationTypeDTO relationType = typeModel.FindByName(DefaultSettings.RelationType.Child.ToString()).Single();

                    // Add relationship between new parent and children.
                    foreach (FamilyMemberDTO child in person.Descendants)
                        memModel.AddRelative(child, newParent, relationType);
                }

                memModel.Delete(person);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Save all changes to DB.
        /// </summary>
        public void SaveAllChanges()
        {
            try
            {
                if (!_autoSubmit && _view.Families != null)
                {
                    foreach (FamilyDTO dto in _view.Families)
                    {
                        switch (dto.State)
                        {
                            case DataState.New:
                                _model.Add(dto);
                                break;
                            case DataState.Modified:
                                _model.Update(dto);
                                break;
                            case DataState.Deleted:
                                _model.Delete(dto);
                                break;
                            default:
                                break;
                        }
                    }
                }

                _model.Save();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Searches for a FamilyMember in current family.
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public FamilyMemberDTO SearchInCurrentFamily(int memberID)
        {
            try
            {
                if(_view.CurrentFamily == null || 
                        _view.CurrentFamily.RootPerson == null)
                    return null;

                Stack<FamilyMemberDTO> stack = new Stack<FamilyMemberDTO>();
                FamilyMemberDTO result = _view.CurrentFamily.RootPerson;

                while (true)
                {
                    if (result.ID == memberID)
                        return result;

                    if (result.Father != null && result.Father.ID == memberID)
                        return result.Father;

                    if (result.Mother != null && result.Mother.ID == memberID)
                        return result.Mother;

                    if (result.RelativePerson != null && result.RelativePerson.ID == memberID)
                        return result.RelativePerson;

                    // Now, push all his/her spouses to stack.
                    if (result.Spouses != null && result.Spouses.Count > 0)
                        foreach (FamilyMemberDTO spouse in result.Spouses)
                            stack.Push(spouse);

                    // Push all his/her children to stack
                    if (result.Descendants != null && result.Descendants.Count > 0)
                        foreach (FamilyMemberDTO child in result.Descendants)
                            stack.Push(child);

                    if (stack.Count > 0)
                        result = stack.Pop();
                    else
                        break;
                }

                // Not found anyone!
                return null;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_SEARCH_ENTRY_FAILED));
            }
        }

        #endregion

        #region UTILITY METHODS

        public int CountFamilyWithName(string familyName)
        {
            IEnumerable<FamilyDTO> families = _model.FindByName(familyName);
            return families.Count();
        }

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }

        #endregion
    }
}
