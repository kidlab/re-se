using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class DeadReasonModel : BaseModel, IDeathReasonModel
    {
        #region CONSTRUCTOR

        public DeadReasonModel()
            : base()
        {

        }

        public DeadReasonModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {

        }

        #endregion

        #region ILinqModel<DeathReasonDTO> Members

        public IEnumerable<DeathReasonDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<DeathReasonDTO> matches =
                    _db.BURYREASONs.Select(place => ConvertToDTO(place));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<DeathReasonDTO> Members

        public IList<DeathReasonDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<DeathReasonDTO> matches =
                    _db.BURYREASONs.Select(reason => ConvertToDTO(reason));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public DeathReasonDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                BURYREASON reason = _db.BURYREASONs.SingleOrDefault(r => r.IDBuryReason == id);
                return ConvertToDTO(reason);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(DeathReasonDTO obj)
        {
            try
            {
                BURYREASON mapper = ConvertToMapper(obj);
                _db.BURYREASONs.InsertOnSubmit(mapper);
                this._save();
                obj.ID = mapper.IDBuryReason;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(DeathReasonDTO obj)
        {
            try
            {
                BURYREASON mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _db.BURYREASONs.DeleteOnSubmit(mapper);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(DeathReasonDTO obj)
        {
            try
            {
                BURYREASON mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _updateModel(ref mapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static BURYREASON ConvertToMapper(DeathReasonDTO dto)
        {
            BURYREASON mapper = new BURYREASON();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static DeathReasonDTO ConvertToDTO(BURYREASON mapper)
        {
            DeathReasonDTO dto = new DeathReasonDTO();
            dto.ID = mapper.IDBuryReason;
            dto.Name = mapper.Name;
            dto.State = DataState.Copied;
            return dto;
        }

        private static void _updateModel(ref BURYREASON mapper, DeathReasonDTO dto)
        {
            mapper.IDBuryReason = dto.ID;
            mapper.Name = dto.Name;
        }

        private IEnumerable<BURYREASON> _search(DeathReasonDTO obj)
        {
            IEnumerable<BURYREASON> matches =
                from entry in _db.BURYREASONs
                where entry.IDBuryReason == obj.ID
                select entry;

            return matches;
        }

        #endregion

        #region IDeathReasonModel Members

        public IEnumerable<DeathReasonDTO> FindByName(string name)
        {
            try
            {
                IEnumerable<DeathReasonDTO> matches =
                    from entity in _db.BURYREASONs
                    where entity.Name.ToUpper() == name.ToUpper()
                    select ConvertToDTO(entity);

                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(DeadReasonModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion
    }
}
