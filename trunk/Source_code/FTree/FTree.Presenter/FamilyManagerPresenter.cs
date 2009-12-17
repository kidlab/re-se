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

        public void Delete()
        {
            try
            {
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
