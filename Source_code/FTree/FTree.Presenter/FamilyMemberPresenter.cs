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

        private FamilyMemberDTO _member;

        /// <summary>
        /// Gets the current family member was processed.
        /// </summary>
        public FamilyMemberDTO FamilyMember
        {
            get { return _member; }
        }

        #endregion

        #region CONSTRUCTOR

        public FamilyMemberPresenter(IFamilyMemberModel model, IFamilyMemberView view)
        {
            _model = model;
            _view = view;
        }

        public FamilyMemberPresenter(IFamilyMemberView view) : this(new FamilyMemberModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        public void Add()
        {
            try
            {
                _member = _generateDTO();
                _model.Add(_member);
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
                _member = _generateDTO();
                _model.Update(_member);
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

        #endregion

        #region UTILITY METHODS

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }

        private FamilyMemberDTO _generateDTO()
        {
            FamilyMemberDTO member = new FamilyMemberDTO();
            //member.Family = _view.Family;
            //member.FirstName = _view.FirstName;
            //member.LastName = _view.LastName;
            //member.IsFemale = _view.IsFemale;
            //member.Address = _view.Address;
            //member.HomeTown = _view.HomeTown;
            //member.Birthday = _view.BirthDay;
            //member.DateJointFamily = _view.DateJoinFamily;
            //member.Job = _view.Career; 

            return member;
        }

        #endregion
    }
}
