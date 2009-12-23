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
    public class AchievementPresenter : BasePresenter<IFamilyMemberModel, IAchievementView>
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

        public AchievementPresenter(IFamilyMemberModel model, IAchievementView view)
        {
            _model = model;
            _view = view;
            _autoSubmit = true;
        }

        public AchievementPresenter(IAchievementView view)
            : this(new FamilyMemberModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        public void LoadAllAchievementTypes()
        {
            try
            {
                IAchievementTypeModel aTypeModel = new AchievementTypeModel();
                _view.AchievementTypeList = aTypeModel.GetAll();
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        /// <summary>
        /// Add new Achievement.
        /// </summary>
        public void Add()
        {
            try
            {
                if (_autoSubmit)
                {
                    _model.AssignAchievement(_view.Person, _view.AchievementInfo);
                }
                else
                {
                    // Generate a random ID.
                    _view.AchievementInfo.ID = rand.Next();
                }

                _view.Person.Achievements.Add(_view.AchievementInfo);
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        /// <summary>
        /// Update existing Achievement.
        /// </summary>
        public void Update()
        {
            try
            {
                _view.AchievementInfo.State = DataState.Modified;

                if (_autoSubmit)
                {
                    _model.UpdateAchievement(_view.Person, _view.AchievementInfo);
                }
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
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
                Tracer.Log(typeof(AchievementPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementPresenter), exc);
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

        #endregion
    }
}
