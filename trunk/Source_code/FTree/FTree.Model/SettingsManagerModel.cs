using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    /// <summary>
    /// This class manages and manipulates all minor tables,
    /// such as: Relationship types, home towns, Jobs, Achievements, 
    /// Death reasons and Bury places.
    /// </summary>
    public class SettingsManagerModel
    {
        #region VARIABLES

        private IRelationTypeModel _relationTypeModel;

        /// <summary>
        /// Gets the DB manipulator of Relationship types.
        /// </summary>
        public IRelationTypeModel RelationTypeModel
        {
            get { return _relationTypeModel; }
        }

        private IHomeTownModel _homeTownModel;

        /// <summary>
        /// Gets the DB manipulator of Home towns.
        /// </summary>
        public IHomeTownModel HomeTownModel
        {
            get { return _homeTownModel; }
        }

        private IJobModel _jobModel;

        /// <summary>
        /// Gets the DB manipulator of Jobs.
        /// </summary>
        public IJobModel JobModel
        {
            get { return _jobModel; }
        }

        private IAchievementTypeModel _achievementTypeModel;

        /// <summary>
        /// Gets the DB manipulator of Achievement types.
        /// </summary>
        public IAchievementTypeModel AchievementTypeModel
        {
            get { return _achievementTypeModel; }
        }

        private IDeathReasonModel _deadReasonModel;

        /// <summary>
        /// Gets the DB manipulator of Dead reasons.
        /// </summary>
        public IDeathReasonModel DeadReasonModel
        {
            get { return _deadReasonModel; }
        }

        private IBuryPlaceModel _buryPlaceModel;

        /// <summary>
        /// Gets the DB manipulator of Bury places.
        /// </summary>
        public IBuryPlaceModel BuryPlaceModel
        {
            get { return _buryPlaceModel; }
        }

        #endregion

        #region CONSTRCUTOR

        public SettingsManagerModel()
        {
            _initModels();
        }

        #endregion

        #region UTILTY METHODS

        /// <summary>
        /// Initializes all internal model objects.
        /// </summary>
        protected virtual void _initModels()
        {
            _relationTypeModel      = new RelationTypeModel();
            _homeTownModel          = new HomeTownModel();
            _jobModel               = new JobModel();
            _achievementTypeModel   = new AchievementTypeModel();
            _deadReasonModel        = new DeadReasonModel();
            _buryPlaceModel         = new BuryPlaceModel();
        }

        /// <summary>
        /// Dispose all model objects.
        /// </summary>
        public virtual void DisposeAllModels()
        {
            _relationTypeModel = null;
            _homeTownModel = null;
            _jobModel = null;
            _achievementTypeModel = null;
            _deadReasonModel = null;
            _buryPlaceModel = null;
        }

        /// <summary>
        /// Sets the value determining that the models will automatically submit all changes to DB or not.
        /// </summary>
        /// <param name="value">True for automatic submiting changes,
        /// otherwise, manually submit by programmer if False.</param>
        public virtual void SetAutoSubmitChanges(bool value)
        {
            _relationTypeModel.AutoSubmitChanges    = value;
            _homeTownModel.AutoSubmitChanges        = value;
            _jobModel.AutoSubmitChanges             = value;
            _achievementTypeModel.AutoSubmitChanges = value;
            _deadReasonModel.AutoSubmitChanges      = value;
            _buryPlaceModel.AutoSubmitChanges       = value;
        }

        /// <summary>
        /// Submit all changes to DB.
        /// </summary>
        public virtual void SubmitAllChanges()
        {
            try
            {
                _relationTypeModel.Save();
                _homeTownModel.Save();
                _jobModel.Save();
                _achievementTypeModel.Save();
                _deadReasonModel.Save();
                _buryPlaceModel.Save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsManagerModel), exc);
                throw;  // Keep all original error stacks.
            }
        }

        #endregion
    }
}
