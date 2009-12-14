using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class BuryPlaceModel : BaseModel, IBuryPlaceModel
    {
        #region CONSTRUCTOR

        public BuryPlaceModel()
            : base()
        {

        }

        #endregion

        #region ILinqModel<BuryPlaceDTO> Members

        public IEnumerable<FTree.DTO.BuryPlaceDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<BuryPlaceDTO> matches =
                    _db.BURYPLACEs.Select(place => ConvertToDTO(place));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }


        #endregion

        #region IModel<BuryPlaceDTO> Members

        public IList<FTree.DTO.BuryPlaceDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<BuryPlaceDTO> matches =
                    _db.BURYPLACEs.Select(place => ConvertToDTO(place));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FTree.DTO.BuryPlaceDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                BURYPLACE place = _db.BURYPLACEs.SingleOrDefault(p => p.IDBuryPlace == id);
                return ConvertToDTO(place);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FTree.DTO.BuryPlaceDTO obj)
        {
            try
            {
                BURYPLACE mapper = ConvertToMapper(obj);
                _db.BURYPLACEs.InsertOnSubmit(mapper);
                this._save();
                obj.ID = mapper.IDBuryPlace;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(FTree.DTO.BuryPlaceDTO obj)
        {
            try
            {
                _db.BURYPLACEs.DeleteOnSubmit(ConvertToMapper(obj));
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(FTree.DTO.BuryPlaceDTO obj)
        {
            try
            {
                IEnumerable<BURYPLACE> matches =
                        from place in _db.BURYPLACEs
                        where place.IDBuryPlace == obj.ID
                        select place;

                BURYPLACE placeMapper = matches.SingleOrDefault();
                _updateModel(ref placeMapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(BuryPlaceModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }
        
        #endregion

        #region UTILITY METHODS

        internal static BURYPLACE ConvertToMapper(BuryPlaceDTO dto)
        {
            BURYPLACE mapper = new BURYPLACE();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static BuryPlaceDTO ConvertToDTO(BURYPLACE mapper)
        {
            BuryPlaceDTO dto = new BuryPlaceDTO();
            dto.ID = mapper.IDBuryPlace;
            dto.Name = mapper.Name;
            return dto;
        }

        private static void _updateModel(ref BURYPLACE mapper, BuryPlaceDTO dto)
        {
            mapper.IDBuryPlace = dto.ID;
            mapper.Name = dto.Name;
        }

        #endregion
    }
}
