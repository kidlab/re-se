using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.Model;
using FTree.DTO;

namespace FTree.Presenter
{
    public class FamilyMemberPresenter : BasePresenter<IFamilyMemberModel, IFamilyMemberView>
    {
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
                _model.Add(_generateDTO());
            }
            catch (FTreeDbAccessException exc)
            {
                throw new FTreePresenterException();
            }
            catch (Exception exc)
            {
                throw new FTreePresenterException();
            }
        }

        #endregion

        #region UTILITY METHODS

        protected override void _disposeComponents()
        {
            throw new NotImplementedException();
        }

        private FamilyMemberDTO _generateDTO()
        {
            FamilyMemberDTO member = new FamilyMemberDTO();

            return member;
        }

        #endregion
    }
}
