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
        protected bool _autoSubmitChanges;

        /// <summary>
        /// Gets or sets the value determining that the model will automatically submit all changes to DB or not. The default value is True.
        /// </summary>
        public bool AutoSubmitChanges
        {
            get
            {
                return _autoSubmitChanges;
            }
            set
            {
                _autoSubmitChanges = value;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public BaseModel()
        {
            _refreshDataContext();
            _autoSubmitChanges = true;
        }

        #endregion

        #region UTILITIY METHODS
        
        /// <summary>
        /// Submit all changes and refresh DataContext 
        /// if the value _autoSubmitChanges is True.
        /// </summary>
        protected virtual void _save()
        {
            try
            {
                if (_autoSubmitChanges)
                    Save();
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

        /// <summary>
        /// Submit all changes to DB and refresh the data context.
        /// </summary>
        public virtual void Save()
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

        #endregion
    }
}
