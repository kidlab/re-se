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
        #region VARIABLES

        private bool _autoSubmit;

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not. The default value is True.
        /// </summary>
        public bool AutoSubmitChanges
        {
            get
            {
                return this._autoSubmit;
            }
            set
            {
                _autoSubmit = value;
                _model.SetAutoSubmitChanges(_autoSubmit);
            }
        }

        #endregion

        #region CONSTRUCTOR

        public SettingsManagerPresenter(ISettingsManagerView view)
        {
            _model = new SettingsManagerModel();
           
            _autoSubmit = false;
           
            // Turn off the auto-submit changes feature.
            _model.SetAutoSubmitChanges(_autoSubmit);

            _view = view;
        }

        #endregion

        #region CORE METHODS

        #region RELATION TYPE

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
                if (CountRelationTypeWithName(dto.Name) > 0)
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

                if (CountRelationTypeWithName(dto.Name) > 1)
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

        #endregion

        #region HOMETOWN

        public void LoadAllHomeTowns()
        {
            try
            {
                _view.HomeTowns = _model.HomeTownModel.GetAll();
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

        public void AddHomeTown()
        {
            try
            {
                HomeTownDTO dto = _view.HomeTown;
                if (CountHomeTownWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.HomeTownModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        public void UpdateHomeTown()
        {
            try
            {
                HomeTownDTO dto = _view.HomeTown;

                if (CountHomeTownWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.HomeTownModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        public void DeleteHomeTown()
        {
            try
            {
                _model.HomeTownModel.Delete(_view.HomeTown);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #region OCCUPATION

        public void LoadAllJobs()
        {
            try
            {
                _view.Jobs = _model.JobModel.GetAll();
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

        public void AddJob()
        {
            try
            {
                JobDTO dto = _view.Job;
                if (CountCareerWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.JobModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        public void UpdateJob()
        {
            try
            {
                JobDTO dto = _view.Job;

                if (CountCareerWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.JobModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        public void DeleteJob()
        {
            try
            {
                _model.JobModel.Delete(_view.Job);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #region ACHIEVEMENT

        public void LoadAllAchievements()
        {
            try
            {
                _view.AchievementTypes = _model.AchievementTypeModel.GetAll();
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

        public void AddAchievement()
        {
            try
            {
                AchievementType dto = _view.AchievementType;
                if (CountAchieveWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.AchievementTypeModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        public void UpdateAchievement()
        {
            try
            {
                AchievementType dto = _view.AchievementType;

                if (CountAchieveWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.AchievementTypeModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        public void DeleteAchievement()
        {
            try
            {
                _model.AchievementTypeModel.Delete(_view.AchievementType);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #region DEATH REASON

        public void LoadAllDeathReasons()
        {
            try
            {
                _view.DeathReasons = _model.DeadReasonModel.GetAll();
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

        public void AddDeathReason()
        {
            try
            {
                DeathReasonDTO dto = _view.DeathReason;
                if (CountDeathReasonWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.DeadReasonModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        public void UpdateDeathReason()
        {
            try
            {
                DeathReasonDTO dto = _view.DeathReason;

                if (CountDeathReasonWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.DeadReasonModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        public void DeleteDeathReason()
        {
            try
            {
                _model.DeadReasonModel.Delete(_view.DeathReason);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #region BURY PLACE

        public void LoadAllBuryPlaces()
        {
            try
            {
                _view.BuryPlaces = _model.BuryPlaceModel.GetAll();
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

        public void AddBuryPlace()
        {
            try
            {
                BuryPlaceDTO dto = _view.BuryPlace;
                if (CountBuryPlaceWithName(dto.Name) > 0)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.BuryPlaceModel.Add(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        public void UpdateBuryPlace()
        {
            try
            {
                BuryPlaceDTO dto = _view.BuryPlace;

                if (CountBuryPlaceWithName(dto.Name) > 1)
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), dto.Name));

                _model.BuryPlaceModel.Update(dto);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        public void DeleteBuryPlace()
        {
            try
            {
                _model.BuryPlaceModel.Delete(_view.BuryPlace);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        /// <summary>
        /// Save all changes to DB.
        /// </summary>
        public void SaveAllChanges()
        {
            try
            {
                if (!_autoSubmit)
                {
                    #region RELATION TYPE

                    if (_view.RelationTypes != null)
                        foreach (RelationTypeDTO dto in _view.RelationTypes)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.RelationTypeModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.RelationTypeModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.RelationTypeModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion

                    #region HOMETOWN

                    if (_view.HomeTowns != null)
                        foreach (HomeTownDTO dto in _view.HomeTowns)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.HomeTownModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.HomeTownModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.HomeTownModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion

                    #region OCCUPATION

                    if (_view.Jobs != null)
                        foreach (JobDTO dto in _view.Jobs)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.JobModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.JobModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.JobModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion

                    #region ACHIEVEMENT

                    if (_view.AchievementTypes != null)
                        foreach (AchievementType dto in _view.AchievementTypes)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.AchievementTypeModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.AchievementTypeModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.AchievementTypeModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion

                    #region DEATH REASON

                    if (_view.DeathReasons != null)
                        foreach (DeathReasonDTO dto in _view.DeathReasons)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.DeadReasonModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.DeadReasonModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.DeadReasonModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion

                    #region BURY PLACE

                    if (_view.BuryPlaces != null)
                        foreach (BuryPlaceDTO dto in _view.BuryPlaces)
                        {
                            switch (dto.State)
                            {
                                case DataState.New:
                                    _model.BuryPlaceModel.Add(dto);
                                    break;
                                case DataState.Modified:
                                    _model.BuryPlaceModel.Update(dto);
                                    break;
                                case DataState.Deleted:
                                    _model.BuryPlaceModel.Delete(dto);
                                    break;
                                default:
                                    break;
                            }
                        }

                    #endregion
                }

                _model.Save();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        #endregion

        #region UTILIY METHODS

        public int CountRelationTypeWithName(string name)
        {
            IEnumerable<RelationTypeDTO> matches = _model.RelationTypeModel.FindByName(name);
            return matches.Count();
        }

        public int CountHomeTownWithName(string name)
        {
            IEnumerable<HomeTownDTO> matches = _model.HomeTownModel.FindByName(name);
            return matches.Count();
        }

        public int CountCareerWithName(string name)
        {
            IEnumerable<JobDTO> matches = _model.JobModel.FindByName(name);
            return matches.Count();
        }

        public int CountAchieveWithName(string name)
        {
            IEnumerable<AchievementType> matches = _model.AchievementTypeModel.FindByName(name);
            return matches.Count();
        }

        public int CountDeathReasonWithName(string name)
        {
            IEnumerable<DeathReasonDTO> matches = _model.DeadReasonModel.FindByName(name);
            return matches.Count();
        }

        public int CountBuryPlaceWithName(string name)
        {
            IEnumerable<BuryPlaceDTO> matches = _model.BuryPlaceModel.FindByName(name);
            return matches.Count();
        }

        protected override void _disposeComponents()
        {
            _model.DisposeAllModels();
        }

        #endregion

    }
}
