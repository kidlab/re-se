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
    public class FamilyMemberPresenter : BasePresenter<IFamilyMemberModel, IFamilyMemberView>
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

        public FamilyMemberPresenter(IFamilyMemberModel model, IFamilyMemberView view)
        {
            _model = model;
            _autoSubmit = false;
            _model.AutoSubmitChanges = _autoSubmit;
            _view = view;
        }

        public FamilyMemberPresenter(IFamilyMemberView view)
            : this(new FamilyMemberModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        public void LoadRelativeMembers(bool exceptCurrentPerson)
        {
            try
            {
                _view.FamilyMembers = _model.GetAll(_view.Family.Name);

                if (exceptCurrentPerson 
                        && _view.FamilyMembers != null
                        && _view.FamilyMember != null)
                {
                    // Remove the current person in the list.
                    IEnumerable<FamilyMemberDTO> removedPersons = 
                        from person in _view.FamilyMembers
                        where person.ID == _view.FamilyMember.ID
                        select person;

                    FamilyMemberDTO removedPerson = removedPersons.Single();

                    _view.FamilyMembers.Remove(removedPerson);
                }
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        public void LoadAllParameters()
        {
            try
            {
                IRelationTypeModel relationType = new RelationTypeModel();
                IHomeTownModel homeTown = new HomeTownModel();
                IJobModel job = new JobModel();
                
                _view.RelationTypesList = relationType.GetAll();
                _view.HomeTownsList = homeTown.GetAll();
                _view.CareersList = job.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        public void Add()
        {
            try
            {
                bool isRootPerson = (_view.RelativePerson == null);

                if (!isRootPerson)
                    // Update the relationship in DTO objects.
                    DetermineRelationship(_view.FamilyMember, _view.RelativePerson, _view.RelationType);

                // Save person information.
                _model.Add(_view.FamilyMember);

                if (!isRootPerson)
                    // Add new relationship.
                    _model.AddRelative(_view.FamilyMember, _view.RelativePerson, _view.RelationType);  
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_PERSON_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_PERSON_FAILED));
            }
        }

        public void Update()
        {
            try
            {
                _model.Update(_view.FamilyMember);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_PERSON_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_PERSON_FAILED));
            }
        }

        public void Delete(FamilyMemberDTO member)
        {
            try
            {
                _model.Delete(member);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_PERSON_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_PERSON_FAILED));
            }
        }

        /// <summary>
        /// Get the relationship between current person and his/her relative.
        /// </summary>
        /// <returns>An instance of RelationTypeDTO.</returns>
        public RelationTypeDTO GetRelationship()
        {
            try
            {
                if (_view.FamilyMember == _view.RelativePerson)
                    return null;

                RelationTypeDTO relationType = _model.GetRelationship(_view.FamilyMember, _view.RelativePerson);
                return relationType;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_FIND_RELATIONSHIP_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_FIND_RELATIONSHIP_FAILED));
            }
        }

        /// <summary>
        /// Load the full family tree with the current person is the root person.
        /// </summary>
        public void LoadFamilyTree()
        {
            try
            {
                if (_view.FamilyMember == null)
                    return;

                _view.FamilyMember = _model.GetOne(_view.FamilyMember.ID);
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

        public void GetAllAchievements()
        {
            try
            {
                if (_view.FamilyMember == null)
                    return;

               _view.FamilyMember.Achievements = _model.GetAchievements(_view.FamilyMember);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        public void DeleteAchievement()
        {
            try
            {
                _model.DeleteAchievement(_view.SelectedAchievementInfo);
                _view.FamilyMember.Achievements.Remove(_view.SelectedAchievementInfo);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        public void UpdateAchievement()
        {
            try
            {
                _model.UpdateAchievement(_view.FamilyMember, _view.SelectedAchievementInfo);
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

        public void DeleteDeathInfo()
        {
            try
            {
                _model.DeleteDeathInfo(_view.FamilyMember);
                if (_autoSubmit)
                    _view.FamilyMember.DeathInfo = null;
                else
                    _view.FamilyMember.DeathInfo.State = DataState.Deleted;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
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
                if (!_autoSubmit)
                {       
                    // Save achievements
                    if (_view.FamilyMember.Achievements != null)
                        foreach (AchievementInfo dto in _view.FamilyMember.Achievements)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.AssignAchievement(_view.FamilyMember, dto);
                                    break;
                                case DataState.Modified:
                                    _model.UpdateAchievement(_view.FamilyMember, dto);
                                    break;
                                case DataState.Deleted:
                                    _model.DeleteAchievement(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    // Save Death Info
                    if (_view.FamilyMember.DeathInfo != null)
                    {
                        switch (_view.FamilyMember.DeathInfo.State)
                        {
                            case DataState.New:
                                _model.ReportDeath(_view.FamilyMember);
                                break;
                            case DataState.Modified:
                                _model.UpdateDeathInfo(_view.FamilyMember);
                                break;
                            case DataState.Deleted:
                                _model.DeleteDeathInfo(_view.FamilyMember);
                                _view.FamilyMember.DeathInfo = null;
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
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        #endregion

        #region UTILITY METHODS

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }

        public int CountPersonByFullname(string fullName)
        {
            IList<FamilyMemberDTO> matches = _model.FindByFullName(fullName.Trim());
            return matches.Count;
        }

        /// <summary>
        /// Checks that the current selected relative person already had spouse(s) or not.
        /// </summary>
        /// <returns>True if this person had married, otherwise returns False.</returns>
        public bool CheckPersonHasSpouse()
        {
            try
            {
                _view.RelativePerson.Spouses = _model.GetSpouses(_view.RelativePerson);

                if (_view.RelativePerson.Spouses != null
                        && _view.RelativePerson.Spouses.Count > 0)
                    return true;
                return false;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberPresenter), exc);
            }

            return false;
        }

        public static void DetermineRelationship(FamilyMemberDTO person, FamilyMemberDTO relative, RelationTypeDTO relationType)
        {
            if (person == null 
                    || relative == null 
                    || relationType == null)
                return;

            if (relationType.Name == DefaultSettings.RelationType.Child.ToString())
            {
                // Increase the genration level.
                person.GenerationNumber = relative.GenerationNumber + 1;
                
                relative.Descendants.Add(person);
            }
            else if (relationType.Name == DefaultSettings.RelationType.Spouse.ToString())
            {
                person.GenerationNumber = relative.GenerationNumber;
                relative.Spouses.Add(person);
            }
        }

        /// <summary>
        /// Copy relatives (children, husband/wife,etc) from person1 to person2.
        /// </summary>
        /// <param name="person1">Source FamilyMemberDTO.</param>
        /// <param name="person2">Destination FamilyMemberDTO need copying information.</param>
        public static void CopyRelatives(FamilyMemberDTO person1, ref FamilyMemberDTO person2)
        {
            if (person1 == null || person2 == null)
                return;

            person2.Father = person1.Father;
            person2.Mother = person1.Mother;
            person2.Spouses = person1.Spouses;
            person2.Descendants = person1.Descendants;
        }

        #endregion
    }
}
