using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class FamilyMemberModel : BaseModel, IFamilyMemberModel
    {
        #region VARIABLES


        #endregion

        #region CONSTRUCTOR

        public FamilyMemberModel()
            : base()
        {
        }

        #endregion

        #region ILinqModel<FamilyMemberDTO> Members

        public IEnumerable<FamilyMemberDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<FamilyMemberDTO> matches =
                    _db.MEMBERs.Select(member => ConvertToDTO(member));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<FamilyMemberDTO> Members

        /// <summary>
        /// Get all person in DB.
        /// </summary>
        /// <returns>List of family's members.</returns>
        public IList<FamilyMemberDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<FamilyMemberDTO> matches =
                    _db.MEMBERs.Select(member => ConvertToDTO(member));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Get all persons of a specific family.
        /// </summary>
        /// <param name="familyID">ID of the family.</param>
        /// <returns>List of family's members.</returns>
        public IList<FamilyMemberDTO> GetAll(int familyID)
        {
            try
            {
                _refreshDataContext();
                IEnumerable<FamilyMemberDTO> matches =
                    _db.MEMBERs.Where(member => member.IDFamily == familyID)
                    .Select(familyMember => ConvertToDTO(familyMember));

                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Gets a person info and all his relative person by his ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An instance of FamilyMemberDTO.</returns>
        public FamilyMemberDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                // Recursively!!!
                return _getFamilyTree(id, true, true);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        private FamilyMemberDTO _getFamilyTree(int id, bool needFindFather, bool needFindMother)
        {
            try
            {
                IEnumerable<MEMBER> matches =
                    from member in _db.MEMBERs
                    where member.IDMember == id
                    select member;
                MEMBER personMapper = matches.Single();

                FamilyMemberDTO personDto = ConvertToDTO(personMapper);

                // Get spouse(s) of this person,
                personDto.Spouses = _getSpouses(personMapper);

                // Get children of this person (recursively).
                List<int> childrenIDs = _getChildrenIDs(personMapper);
                foreach (int childID in childrenIDs)
                {
                    FamilyMemberDTO child = null;
                    if (personDto.IsFemale)
                    {
                        child = _getFamilyTree(childID, true, false);
                        child.Mother = personDto;
                    }
                    else
                    {
                        child = _getFamilyTree(childID, false, true);
                        child.Father = personDto;
                    }
                }

                if (needFindFather)
                    // Get father of this person.
                    personDto.Father = _getParent(true, personMapper);

                if (needFindMother)
                    // Get mother of this person.
                    personDto.Mother = _getParent(false, personMapper);

                return personDto;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FamilyMemberDTO obj)
        {
            try
            {
                MEMBER member = ConvertToMapper(obj);
                _db.MEMBERs.InsertOnSubmit(member);
                this._save();
                obj.ID = member.IDMember;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void AddRelative(FamilyMemberDTO person, FamilyMemberDTO relative, RelationTypeDTO relationType)
        {
            try
            {
                RELATIONSHIP relationship = new RELATIONSHIP();
                relationship.IDMember1 = person.ID;
                relationship.IDMember2 = relative.ID;
                relationship.IDRelationship = relationType.ID;

                _db.RELATIONSHIPs.InsertOnSubmit(relationship);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void AssignAchievement(FamilyMemberDTO person, AchievementInfo achievement)
        {
            try
            {
                MEMBER_EVENT mem_event = new MEMBER_EVENT();
                mem_event.IDMember = person.ID;
                mem_event.IDEvent = achievement.AchievementType.ID;
                mem_event.EventDate = achievement.AchievementDate;
                mem_event.Description = achievement.Description;

                _db.MEMBER_EVENTs.InsertOnSubmit(mem_event);
                this._save();
                achievement.ID = mem_event.IDEventMem;
                person.Achievements.Add(achievement);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void ReportDeath(FamilyMemberDTO person, DeathInfo deathInfo)
        {
            try
            {
                DEATH_INFO death = new DEATH_INFO();
                death.IDMember = person.ID;
                death.IDBuryPlace = deathInfo.BuryPlace.ID;
                death.IDBuryReason = deathInfo.Reason.ID;
                death.BuryDay = deathInfo.DeathDay;

                _db.DEATH_INFOs.InsertOnSubmit(death);
                this._save();

                deathInfo.ID = person.ID;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Update(FamilyMemberDTO obj)
        {
            try
            {
                IEnumerable<MEMBER> matches =
                    from member in _db.MEMBERs
                    where member.IDMember == obj.ID
                    select member;
                //_db.MEMBERs.Where(member => member.IDMember == obj.ID)
                //.Select(member);

                MEMBER memberMapper = matches.SingleOrDefault();
                _updateModel(ref memberMapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(FamilyMemberDTO obj)
        {
            try
            {

            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static MEMBER ConvertToMapper(FamilyMemberDTO dto)
        {
            MEMBER mapper = new MEMBER();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static FamilyMemberDTO ConvertToDTO(MEMBER mapper)
        {
            FamilyMemberDTO dto = new FamilyMemberDTO();
            dto.ID = mapper.IDMember;
            dto.FirstName = mapper.FirstName;
            dto.LastName = mapper.LastName;
            dto.IsFemale = IsFemale(mapper);
            dto.Job = JobModel.ConvertToDTO(mapper.JOB);
            dto.HomeTown = HomeTownModel.ConvertToDTO(mapper.BIRTHPLACE);
            dto.GenerationNumber = (int)mapper.GenLevel;
            dto.Family = FamilyModel.ConvertToDTO(mapper.FAMILY);
            dto.Address = mapper.Address;
            dto.Birthday = mapper.Birthday.GetValueOrDefault();
            dto.DateJointFamily = mapper.DayJointFamily.GetValueOrDefault();
            dto.DeathInfo = _getDeathInfo(mapper);

            return dto;
        }

        private static DeathInfo _getDeathInfo(MEMBER mapper)
        {
            if (mapper.DEATH_INFO == null)
                return null;

            DeathInfo deathInfo = new DeathInfo();
            deathInfo.BuryPlace = BuryPlaceModel.ConvertToDTO(mapper.DEATH_INFO.BURYPLACE);
            deathInfo.Reason = DeadReasonModel.ConvertToDTO(mapper.DEATH_INFO.BURYREASON);
            deathInfo.DeathDay = mapper.DEATH_INFO.BuryDay.GetValueOrDefault();

            return deathInfo;
        }

        private FamilyMemberDTO _getParent(bool isFather, MEMBER personMapper)
        {
            FamilyMemberDTO parent = null;
            IEnumerable<RELATIONSHIP> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs
                    where (relation.IDMember1 == personMapper.IDMember)
                        && (relation.IDRelationship == (int)DefaultSettings.RelationType.Child)
                    select relation;
            List<RELATIONSHIP> lstRelations = relationships.ToList();

            if (isFather)
            {
                // Get his father.                
                foreach (RELATIONSHIP r in lstRelations)
                {
                    if (!IsFemale(r.MEMBER1))
                    {
                        parent = ConvertToDTO(r.MEMBER1);
                        break;
                    }
                }
            }
            else
            {
                // Get his mother.                
                foreach (RELATIONSHIP r in lstRelations)
                {
                    if (IsFemale(r.MEMBER1))
                    {
                        parent = ConvertToDTO(r.MEMBER1);
                        break;
                    }
                }
            }
            return parent;
        }

        private static List<FamilyMemberDTO> _getSpouses(MEMBER personMapper)
        {
            List<FamilyMemberDTO> spouses = null;
            IEnumerable<RELATIONSHIP> relationships = null;

            if (IsFemale(personMapper))
            {
                // Get her husband(s).
                relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.IDRelationship == (int)DefaultSettings.RelationType.Spouse)
                    select relation;
                List<RELATIONSHIP> lstRelations = relationships.ToList();
                if (lstRelations.Count > 0)
                {
                    spouses = new List<FamilyMemberDTO>();
                    foreach (RELATIONSHIP r in lstRelations)
                    {
                        FamilyMemberDTO husband = ConvertToDTO(r.MEMBER);
                        spouses.Add(husband);
                    }
                }
            }
            else
            {
                // Get his wife(s).
                relationships =
                    from relation in personMapper.RELATIONSHIPs
                    where (relation.IDMember1 == personMapper.IDMember)
                        && (relation.IDRelationship == (int)DefaultSettings.RelationType.Spouse)
                    select relation;
                List<RELATIONSHIP> lstRelations = relationships.ToList();
                if (lstRelations.Count > 0)
                {
                    spouses = new List<FamilyMemberDTO>();
                    foreach (RELATIONSHIP r in lstRelations)
                    {
                        FamilyMemberDTO wife = ConvertToDTO(r.MEMBER1);
                        spouses.Add(wife);
                    }
                }
            }

            return spouses;
        }

        private static List<FamilyMemberDTO> _getChildren(MEMBER personMapper)
        {
            List<FamilyMemberDTO> children = null;
            IEnumerable<RELATIONSHIP> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.IDRelationship == (int)DefaultSettings.RelationType.Child)
                    select relation;
            List<RELATIONSHIP> lstRelations = relationships.ToList();
            if (lstRelations.Count > 0)
            {
                children = new List<FamilyMemberDTO>();
                foreach (RELATIONSHIP r in lstRelations)
                {
                    FamilyMemberDTO child = ConvertToDTO(r.MEMBER);
                    children.Add(child);
                }
            }

            return children;
        }

        private static List<int> _getChildrenIDs(MEMBER personMapper)
        {
            IEnumerable<int> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.IDRelationship == (int)DefaultSettings.RelationType.Child)
                    select relation.IDMember1;

            return relationships.ToList(); ;
        }

        private static List<AchievementInfo> _getAchievements(MEMBER personMapper)
        {
            List<AchievementInfo> achievements = new List<AchievementInfo>();
            foreach (MEMBER_EVENT memEvent in personMapper.MEMBER_EVENTs)
            {
                AchievementInfo aInfo = new AchievementInfo();
                aInfo.AchievementType = AchievementTypeModel.ConvertToDTO(memEvent.EVENT);
                aInfo.AchievementDate = memEvent.EventDate.GetValueOrDefault();
                aInfo.ID = memEvent.IDEventMem;
                aInfo.Description = memEvent.Description;

                achievements.Add(aInfo);
            }

            return achievements;
        }

        internal static bool IsFemale(MEMBER personMapper)
        {
            return (byte)personMapper.Gender == FTreeConst.FEMALE ? true : false;
        }

        private static void _updateModel(ref MEMBER mapper, FamilyMemberDTO dto)
        {
            mapper.IDMember = dto.ID;
            
            if (dto.Family.ID > 0)
                mapper.IDFamily = dto.Family.ID;
            
            mapper.FirstName = dto.FirstName;
            mapper.LastName = dto.LastName;
            mapper.Gender = dto.IsFemale ? (byte)FTreeConst.FEMALE : (byte)FTreeConst.MALE;
            mapper.Birthday = dto.Birthday;
            
            if(dto.HomeTown.ID > 0)
                mapper.IDBirthPlace = dto.HomeTown.ID;
            
            mapper.Address = dto.Address;
            mapper.DayJointFamily = dto.DateJointFamily;
            
            if(dto.Job.ID > 0)
                mapper.IDJob = dto.Job.ID;

            if (dto.IsDead)
            {
                mapper.DEATH_INFO.IDMember = dto.ID;
                mapper.DEATH_INFO.BuryDay = dto.DeathInfo.DeathDay;
                mapper.DEATH_INFO.IDBuryReason = dto.DeathInfo.Reason.ID;
                mapper.DEATH_INFO.IDBuryPlace = dto.DeathInfo.BuryPlace.ID;
            }
        }

        #endregion
    }
}