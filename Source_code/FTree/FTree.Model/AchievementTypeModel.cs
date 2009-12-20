using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class AchievementTypeModel : BaseModel, IAchievementTypeModel
    {
        #region CONSTRUCTOR

        public AchievementTypeModel()
            : base()
        {

        }

        public AchievementTypeModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region ILinqModel<AchievementType> Members

        public IEnumerable<FTree.DTO.AchievementType> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<AchievementType> matches =
                    _db.EVENTs.Select(eventType => ConvertToDTO(eventType));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<AchievementType> Members

        public IList<FTree.DTO.AchievementType> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<AchievementType> matches =
                    _db.EVENTs.Select(eventType => ConvertToDTO(eventType));
                
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FTree.DTO.AchievementType GetOne(int id)
        {            
            try
            {
                _refreshDataContext();
                EVENT eventType = _db.EVENTs.SingleOrDefault(eType => eType.IDAchievement == id);
                return ConvertToDTO(eventType);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FTree.DTO.AchievementType obj)
        {
            try
            {
                EVENT mapper = ConvertToMapper(obj);
                _db.EVENTs.InsertOnSubmit(mapper);
                this._save();
                obj.ID = mapper.IDAchievement; 
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(FTree.DTO.AchievementType obj)
        {
            try
            {
                EVENT mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _db.EVENTs.DeleteOnSubmit(mapper);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(FTree.DTO.AchievementType obj)
        {
            try
            {
                EVENT mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _updateModel(ref mapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static EVENT ConvertToMapper(AchievementType dto)
        {
            EVENT mapper = new EVENT();

            _updateModel(ref mapper, dto);
            
            return mapper;
        }

        internal static AchievementType ConvertToDTO(EVENT mapper)
        {
            AchievementType dto = new AchievementType();
            dto.ID = mapper.IDAchievement;
            dto.Name = mapper.Name;
            dto.State = DataState.Copied;
            return dto;
        }

        private static void _updateModel(ref EVENT mapper, AchievementType dto)
        {
            mapper.IDAchievement = dto.ID;
            mapper.Name = dto.Name;
        }

        private IEnumerable<EVENT> _search(AchievementType dto)
        {
            IEnumerable<EVENT> matches =
                from entry in _db.EVENTs
                where entry.IDAchievement == dto.ID
                select entry;

            return matches;
        }

        #endregion

        #region IAchievementTypeModel Members

        public IEnumerable<AchievementType> FindByName(string name)
        {
            try
            {
                IEnumerable<AchievementType> matches =
                    from entity in _db.EVENTs
                    where entity.Name.ToUpper() == name.ToUpper()
                    select ConvertToDTO(entity);

                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion
    }
}
