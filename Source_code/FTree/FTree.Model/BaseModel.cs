using System;
using System.Collections.Generic;
using System.Data.Linq;
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
        protected bool _isDataContextShared;

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

        /// <summary>
        /// Gets the value indicating that FTreeDataContext is shared across model classes or not.
        /// </summary>
        public bool IsDataContextShared
        {
            get { return _isDataContextShared; }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Creates a new instance of BaseModel with a new FTreeDataContext.
        /// </summary>
        public BaseModel()
        {
            _refreshDataContext();
            _autoSubmitChanges = true;
            _isDataContextShared = false;
        }

        /// <summary>
        /// Creates a new instance of BaseModel with a FTreeDataContext shared across model classes.
        /// </summary>
        /// <param name="sharedDataContext">The shared FTreeDataContext.</param>
        public BaseModel(FTreeDataContext sharedDataContext)
        {
            _db = sharedDataContext;
            _autoSubmitChanges = true;
            _isDataContextShared = true;
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
                    this.Save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BaseModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        protected void _refreshDataContext()
        {
            // Should not re-create data context in shared mode,
            // because of conflicting data.
            if(!_isDataContextShared)
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

        /// <summary>
        /// Use this method to share one DataContext across model classes 
        /// to avoid conflict when submiting data to DB.
        /// </summary>
        /// <param name="dataContext">An instance of FTreeDataContext.</param>
        public virtual void ShareDataContext(FTreeDataContext dataContext)
        {
            _db = dataContext;
        }

        #endregion
    }
}
