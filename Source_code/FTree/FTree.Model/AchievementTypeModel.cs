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
                IEnumerable<AchievementType> matches =
                    _db.EVENTs.Select(eventType => ConvertToDTO(eventType));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<AchievementType> Members

        public IList<FTree.DTO.AchievementType> GetAll()
        {
            try
            {
                IEnumerable<AchievementType> matches =
                    _db.EVENTs.Select(eventType => ConvertToDTO(eventType));
                
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FTree.DTO.AchievementType GetOne(int id)
        {            
            try
            {
                EVENT eventType = _db.EVENTs.SingleOrDefault(eType => eType.IDEvent == id);
                return ConvertToDTO(eventType);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FTree.DTO.AchievementType obj)
        {
            try
            {
                _db.EVENTs.InsertOnSubmit(ConvertToMapper(obj));  
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(FTree.DTO.AchievementType obj)
        {
            try
            {
                _db.EVENTs.DeleteOnSubmit(ConvertToMapper(obj));
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(FTree.DTO.AchievementType obj)
        {
            try
            {
                IEnumerable<EVENT> matches =
                    from eType in _db.EVENTs
                    where eType.IDEvent == obj.ID
                    select eType;
                //_db.MEMBERs.Where(member => member.IDMember == obj.ID)
                //.Select(member);

                EVENT eventMapper = matches.SingleOrDefault();
                _updateModel(ref eventMapper, obj);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Save()
        {
            try
            {
                _db.SubmitChanges();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementType), exc);
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
            dto.ID = mapper.IDEvent;
            dto.Name = mapper.Name;
            return dto;
        }

        private static void _updateModel(ref EVENT mapper, AchievementType dto)
        {
            mapper.IDEvent = dto.ID;
            mapper.Name = dto.Name;
        }

        #endregion
    }
}
