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
    public class DeathInfoPresenter : BasePresenter<IFamilyMemberModel, IDeathInfoView>
    {
        #region VARIABLES

        private Random rand = new Random();

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

        public DeathInfoPresenter(IFamilyMemberModel model, IDeathInfoView view)
        {
            _model = model;
            _view = view;
            _autoSubmit = true;
        }

        public DeathInfoPresenter(IDeathInfoView view)
            : this(new FamilyMemberModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        #endregion

        public void LoadAllDeathReasons()
        {
            try
            {
                IDeathReasonModel deathReasonModel = new DeathReasonModel();
                _view.DeathReasonsList = deathReasonModel.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        public void LoadAllBuryPlaces()
        {
            try
            {
                IBuryPlaceModel buryPlaceModel = new BuryPlaceModel();
                _view.BuryPlacesList = buryPlaceModel.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        /// <summary>
        /// Add new DeathInfo.
        /// </summary>
        public void Add()
        {
            try
            {
                _view.Person.DeathInfo = _view.DeathInfo;

                if (_autoSubmit)
                {
                    _model.ReportDeath(_view.Person);
                }
                else
                {
                    // Generate a random ID.
                    _view.DeathInfo.ID = rand.Next();
                }                
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Update existing DeathInfo.
        /// </summary>
        public void Update()
        {
            try
            {
                _view.DeathInfo.State = DataState.Modified;

                if (_autoSubmit)
                {
                    _model.UpdateDeathInfo(_view.Person);
                }
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Save all changes to DB.
        /// </summary>
        public void SaveAllChanges()
        {
            try
            {
                _model.Save();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeathInfoPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        #region UTILITY METHODS

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }

        #endregion

    }
}
