using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class HomeTownModel : BaseModel, IHomeTownModel
    {
        #region CONSTRUCTOR

        public HomeTownModel()
            : base()
        {

        }

        public HomeTownModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {

        }

        #endregion

        #region ILinqModel<HomeTownDTO> Members

        public IEnumerable<HomeTownDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<HomeTownDTO> matches =
                    _db.BIRTHPLACEs.Select(place => ConvertToDTO(place));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<HomeTownDTO> Members

        public IList<HomeTownDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<HomeTownDTO> matches =
                    _db.BIRTHPLACEs.Select(place => ConvertToDTO(place));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public HomeTownDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                BIRTHPLACE place = _db.BIRTHPLACEs.SingleOrDefault(p => p.IDBirthPlace == id);
                return ConvertToDTO(place);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(HomeTownDTO obj)
        {
            try
            {
                BIRTHPLACE place = ConvertToMapper(obj);
                _db.BIRTHPLACEs.InsertOnSubmit(place);
                this._save();
                obj.ID = place.IDBirthPlace;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(HomeTownDTO obj)
        {
            try
            {
                BIRTHPLACE mapper = _search(obj).SingleOrDefault();
                _db.BIRTHPLACEs.DeleteOnSubmit(mapper);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(HomeTownDTO obj)
        {
            try
            {
                BIRTHPLACE mapper = _search(obj).SingleOrDefault();
                _updateModel(ref mapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(HomeTownModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static BIRTHPLACE ConvertToMapper(HomeTownDTO dto)
        {
            BIRTHPLACE mapper = new BIRTHPLACE();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static HomeTownDTO ConvertToDTO(BIRTHPLACE mapper)
        {
            HomeTownDTO dto = new HomeTownDTO();
            dto.ID = mapper.IDBirthPlace;
            dto.Name = mapper.Name;
            return dto;
        }

        private static void _updateModel(ref BIRTHPLACE mapper, HomeTownDTO dto)
        {
            mapper.IDBirthPlace = dto.ID;
            mapper.Name = dto.Name;
        }

        private IEnumerable<BIRTHPLACE> _search(HomeTownDTO obj)
        {
            IEnumerable<BIRTHPLACE> matches =
                from entry in _db.BIRTHPLACEs
                where entry.IDBirthPlace == obj.ID
                select entry;

            return matches;
        }

        #endregion
    }
}
