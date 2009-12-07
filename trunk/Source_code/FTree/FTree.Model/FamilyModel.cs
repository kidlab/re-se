using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class FamilyModel : BaseModel, IFamilyModel
    {
        #region CONSTRUCTOR

        public FamilyModel()
            : base()
        {

        }

        #endregion

        #region ILinqModel<FamilyDTO> Members

        public IEnumerable<FTree.DTO.FamilyDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<FamilyDTO> matches =
                    _db.FAMILies.Select(family => ConvertToDTO(family));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<FamilyDTO> Members

        public IList<FTree.DTO.FamilyDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<FamilyDTO> matches =
                    _db.FAMILies.Select(family => ConvertToDTO(family));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Get the information of a family including the first generation along with his (her) descendants.
        /// </summary>
        /// <param name="id">The ID of the family.</param>
        /// <returns>An instance of FamilyDTO.</returns>
        public FTree.DTO.FamilyDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                FAMILY familyMapper =
                    _db.FAMILies.SingleOrDefault(fa => fa.IDFamily == id);
               
                FamilyDTO familyDto = ConvertToDTO(familyMapper);

                // Get the tree of this family.
                int rootId = _getRootPersonID(id);
                FamilyMemberDTO rootPerson = null;
                if (rootId >= 0)
                    rootPerson = new FamilyMemberModel().GetOne(rootId);
                
                familyDto.RootPerson = rootPerson;
                
                return familyDto;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FTree.DTO.FamilyDTO obj)
        {
            try
            {
                FAMILY mapper = ConvertToMapper(obj);
                _db.FAMILies.InsertOnSubmit(mapper);
                this._save();
                obj.ID = mapper.IDFamily;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(FamilyDTO obj)
        {
            try
            {
                IEnumerable<FAMILY> matches =
                    from family in _db.FAMILies
                    where family.IDFamily == obj.ID
                    select family;

                FAMILY familyMapper = matches.SingleOrDefault();
                _updateModel(ref familyMapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Delete a family and all its members in DB.
        /// </summary>
        /// <param name="obj">An instance of FamilyDTO</param>
        public void Delete(FTree.DTO.FamilyDTO obj)
        {
            try
            {
                IEnumerable<FAMILY> matches =
                    from family in _db.FAMILies
                    where family.IDFamily == obj.ID
                    select family;

                FAMILY familyMapper = matches.SingleOrDefault();

                _db.FAMILies.DeleteOnSubmit(familyMapper);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion


        #region IFamilyModel Members

        public IEnumerable<FamilyDTO> FindByName(string familyName)
        {
            try
            {
                IEnumerable<FamilyDTO> matches =
                    from family in _db.FAMILies
                    where family.Name.ToUpper() == familyName.ToUpper()
                    select ConvertToDTO(family);
                    //_db.FAMILies.Select(family => ConvertToDTO(family));

                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static FAMILY ConvertToMapper(FamilyDTO dto)
        {
            FAMILY mapper = new FAMILY();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static FamilyDTO ConvertToDTO(FAMILY mapper)
        {
            FamilyDTO dto = new FamilyDTO();
            dto.ID = mapper.IDFamily;
            dto.Name = mapper.Name;

            return dto;
        }

        /// <summary>
        /// Get the ID of the root person.
        /// </summary>
        /// <param name="familyID">ID of the family.</param>
        /// <returns>ID of the root person.</returns>
        private int _getRootPersonID(int familyID)
        {
            IEnumerable<int> matches =
                    from member in _db.MEMBERs
                    where (member.IDFamily == familyID)
                        && (member.GenLevel == FTreeConst.FIRST_GENERATION)
                    select member.IDMember;

            List<int> memberIDs = matches.ToList();

            if (memberIDs.Count > 0)
                return memberIDs[0];

            return -1;
        }

        private FamilyMemberDTO _getRootPerson(int familyID)
        {
            FamilyMemberDTO rootPerson = null;

            IEnumerable<MEMBER> matches =
                    from member in _db.MEMBERs
                    where (member.IDFamily == familyID)
                        && (member.GenLevel == FTreeConst.FIRST_GENERATION)
                    select member;

            List<MEMBER> members = matches.ToList();
            
            if (members.Count > 0)
                rootPerson = FamilyMemberModel.ConvertToDTO(members[0]);

            return rootPerson;
        }

        private static void _updateModel(ref FAMILY mapper, FamilyDTO dto)
        {
            mapper.IDFamily = dto.ID;
            mapper.Name = dto.Name;
        }

        #endregion

    }
}
