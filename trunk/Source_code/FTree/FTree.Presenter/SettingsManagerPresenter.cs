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
    public class SettingsManagerPresenter : BasePresenter<SettingsManagerModel, ISettingsManagerView>
    {
        #region CONSTRUCTOR

        public SettingsManagerPresenter(ISettingsManagerView view)
        {
            _model = new SettingsManagerModel();

            // Turn off the auto-submit changes feature.
            //_model.SetAutoSubmitChanges(false);

            _view = view;
        }

        #endregion

        #region CORE METHODS

        #region RELATION SHIP

        public void LoadAllRelationTypes()
        {
            try
            {
                _view.RelationTypes = _model.RelationTypeModel.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        public void AddRelationType()
        {
            try
            {
                RelationTypeDTO dto = _view.RelationType;

                if (IsRelationTypeExistent(dto))
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_RELATION_TYPE_ALREADY_EXIST), dto.Name));

                _model.RelationTypeModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_RELATION_TYPE_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_RELATION_TYPE_FAILED));
            }
        }

        public void UpdateRelationType()
        {
            try
            {
                RelationTypeDTO dto = _view.RelationType;

                if (IsRelationTypeExistent(dto))
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_RELATION_TYPE_ALREADY_EXIST), dto.Name));

                _model.RelationTypeModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_RELATION_TYPE_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_RELATION_TYPE_FAILED));
            }
        }

        public void DeleteRelationType()
        {
            try
            {
                _model.RelationTypeModel.Delete(_view.RelationType);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_RELATION_TYPE_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_RELATION_TYPE_FAILED));
            }
        }

        /// <summary>
        /// Save all changes to DB.
        /// </summary>
        public void SaveAllChanges()
        {
            try
            {
                _model.SubmitAllChanges();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_RELATION_TYPE_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_RELATION_TYPE_FAILED));
            }
        }

        #endregion

        #endregion

        #region UTILIY METHODS

        public bool IsRelationTypeExistent(RelationTypeDTO dto)
        {
            IEnumerable<RelationTypeDTO> matches = _model.RelationTypeModel.FindByName(dto.Name);
            if (matches.Count() > 0)
                return true;
            return false;
        }

        #endregion

        protected override void _disposeComponents()
        {
            _model.DisposeAllModels();
        }
    }
}
