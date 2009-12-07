using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.Common;

namespace FTree.Model
{
    public class BaseModel
    {
        #region VARIABLES

        protected FTreeDataContext _db;

        #endregion

        #region CONSTRUCTOR

        public BaseModel()
        {
            _refreshDataContext();
        }

        #endregion

        #region UTILITIY METHODS
        
        /// <summary>
        /// Submit all changes and refresh DataContext.
        /// </summary>
        protected virtual void _save()
        {
            try
            {
                _db.SubmitChanges();
                _refreshDataContext();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BaseModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        protected void _refreshDataContext()
        {
            _db = new FTreeDataContext();
        }

        #endregion
    }
}
