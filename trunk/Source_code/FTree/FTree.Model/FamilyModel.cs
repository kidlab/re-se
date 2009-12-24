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

        public FamilyModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
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
                FamilyMemberModel memModel = new FamilyMemberModel();

                IEnumerable<FamilyDTO> matches =
                    _db.FAMILies.Select(family => ConvertToDTO(family));

                IList<FamilyDTO> families = new List<FamilyDTO>();

                foreach (FamilyDTO family in matches)
                {
                    int rootID = _getRootPersonID(family.ID);
                    if (rootID > 0)
                        family.RootPerson = memModel.GetOneWithoutDescendants(rootID);
                    families.Add(family);
                }

                return families;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Get the information of a family including the first generation along with all his (her) descendants.
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
                FAMILY mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _updateModel(ref mapper, obj);
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
                FAMILY mapper = _search(obj).SingleOrDefault();

                if (mapper == null)
                    return;

                _db.FAMILies.DeleteOnSubmit(mapper);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FamilyMemberDTO LoadFullFamilyTree(int rootID)
        {
            try
            {
                FamilyMemberModel memModel = new FamilyMemberModel();
                return memModel.GetOne(rootID);
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
            dto.State = DataState.Copied;
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

        private IEnumerable<FAMILY> _search(FamilyDTO obj)
        {
            IEnumerable<FAMILY> matches =
                from entry in _db.FAMILies
                where entry.IDFamily == obj.ID
                select entry;

            return matches;
        }

        #endregion

    }
}
