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
    public class FamilyPresenter : BasePresenter<IFamilyModel, IFamilyView>
    {
        #region CONSTRUCTOR

        public FamilyPresenter(IFamilyModel model, IFamilyView view)
        {
            _model = model;
            _view = view;
        }

        public FamilyPresenter(IFamilyView view)
            : this(new FamilyModel(), view)
        {
        }

        #endregion

        #region CORE METHODS

        public void Add()
        {
            try
            {
                FamilyDTO dto = _view.Family;

                if (IsExistent(dto.Name))
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_FAMILY_ALREADY_EXIST), dto.Name));

                _model.Add(dto);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_FAMILY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_INSERT_FAMILY_FAILED));
            }
        }

        public void Update()
        {
            try
            {
                FamilyDTO dto = _view.Family;

                if (IsExistent(dto.Name))
                    throw new FTreePresenterException(String.Format(Util.GetStringResource(StringResName.ERR_FAMILY_ALREADY_EXIST), dto.Name));

                _model.Update(_view.Family);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw;
            }
            catch (FTreeDbAccessException exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_FAMILY_FAILED));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyPresenter), exc);
                throw new FTreePresenterException(exc, Util.GetStringResource(StringResName.ERR_UPDATE_FAMILY_FAILED));
            }
        }


        #endregion

        #region UTILITY METHODS

        public bool IsExistent(string familyName)
        {
            IEnumerable<FamilyDTO> families = _model.FindByName(familyName);
            if (families.Count() > 0)
                return true;
            return false;
        }

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }

        #endregion
    }
}
