﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class RelationTypeModel : BaseModel, IRelationTypeModel
    {
         #region CONSTRUCTOR

        public RelationTypeModel()
            : base()
        {

        }

        #endregion

        #region ILinqModel<RelationTypeDTO> Members

        public IEnumerable<RelationTypeDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<RelationTypeDTO> matches =
                    _db.RELATIONSHIP_TYPEs.Select(rType => ConvertToDTO(rType));

                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<RelationTypeDTO> Members

        public IList<RelationTypeDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<RelationTypeDTO> matches =
                    _db.RELATIONSHIP_TYPEs.Select(rType => ConvertToDTO(rType));

                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public RelationTypeDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                RELATIONSHIP_TYPE type = _db.RELATIONSHIP_TYPEs.SingleOrDefault(rType => rType.IDRelationship == id);
                return ConvertToDTO(type);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(RelationTypeDTO obj)
        {
            try
            {
                RELATIONSHIP_TYPE mapper = ConvertToMapper(obj);
                _db.RELATIONSHIP_TYPEs.InsertOnSubmit(mapper);
                this._save();
                obj.ID = mapper.IDRelationship;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(RelationTypeDTO obj)
        {
            try
            {
                _db.RELATIONSHIP_TYPEs.DeleteOnSubmit(ConvertToMapper(obj));
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(RelationTypeDTO obj)
        {
            try
            {
                IEnumerable<RELATIONSHIP_TYPE> matches =
                    from type in _db.RELATIONSHIP_TYPEs
                    where type.IDRelationship == obj.ID
                    select type;
                
                RELATIONSHIP_TYPE relationType = matches.SingleOrDefault();
                _updateModel(ref relationType, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(RelationTypeModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static RELATIONSHIP_TYPE ConvertToMapper(RelationTypeDTO dto)
        {
            RELATIONSHIP_TYPE mapper = new RELATIONSHIP_TYPE();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static RelationTypeDTO ConvertToDTO(RELATIONSHIP_TYPE mapper)
        {
            RelationTypeDTO dto = new RelationTypeDTO();
            dto.ID = mapper.IDRelationship;
            dto.Name = mapper.Name;
            return dto;
        }

        private static void _updateModel(ref RELATIONSHIP_TYPE mapper, RelationTypeDTO dto)
        {
            mapper.IDRelationship = dto.ID;
            mapper.Name = dto.Name;
        }

        #endregion
    }
}