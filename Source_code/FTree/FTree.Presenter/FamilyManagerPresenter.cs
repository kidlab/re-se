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
        
        #region CONSTRUCTOR

        public FamilyManagerPresenter(IFamilyModel model, IFamilyMangerView view)
        {
            _model = model;
            _view = view;
        }

        public FamilyManagerPresenter(IFamilyMangerView view)
            : this(new FamilyModel(), view)
        {
        }

        #endregion

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

        protected override void _disposeComponents()
        {
            _model = null;
            _view = null;
        }
    }
}
