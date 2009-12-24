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

        public FamilyMemberModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {

        }

        #endregion

        #region CORE METHODS

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
        /// Get all persons of a specific family.
        /// </summary>
        /// <param name="familyName">Name of the family.</param>
        /// <returns>List of family's members.</returns>
        public IList<FamilyMemberDTO> GetAll(string familyName)
        {
            try
            {
                _refreshDataContext();

                IEnumerable<FamilyMemberDTO> matches =
                    from member in _db.MEMBERs
                    join family in _db.FAMILies
                    on member.IDFamily equals family.IDFamily
                    where family.Name == familyName
                    select ConvertToDTO(member);

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
        /// Note that this method will get the full family tree associating with this person.
        /// </summary>
        /// <param name="id">ID of the member.</param>
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

        public FamilyMemberDTO GetOneWithoutDescendants(int id)
        {
            try
            {
                _refreshDataContext();
                IEnumerable<MEMBER> matches =
                    from member in _db.MEMBERs
                    where member.IDMember == id
                    select member;

                MEMBER mapper = matches.Single();

                FamilyMemberDTO personDto = ConvertToDTO(mapper);
                return personDto;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Gets all wives or husbands of a person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IList<FamilyMemberDTO> GetSpouses(FamilyMemberDTO person)
        {
            try
            {
                _refreshDataContext();
                MEMBER mapper = _search(person).SingleOrDefault();

                return _getSpouses(mapper);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Gets all children of a person (only one level).
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IList<FamilyMemberDTO> GetDescendants(FamilyMemberDTO person)
        {
            try
            {
                _refreshDataContext();
                MEMBER mapper = _search(person).SingleOrDefault();

                return _getChildren(mapper);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FamilyMemberDTO GetParent(bool isFather, FamilyMemberDTO dto)
        {
            try
            {                 
                IEnumerable<MEMBER> matches =
                    from member in _db.MEMBERs
                    where member.IDMember == dto.ID
                    select member;
                MEMBER personMapper = matches.Single();
                // Get father of this person.
                return _getParent(isFather, personMapper);
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
                personDto.Descendants = new List<FamilyMemberDTO>();
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
                    personDto.Descendants.Add(child);
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

                // Add the marriage date.
                if (relationType.Name.ToUpper() == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
                {
                    relationship.MarriedDate = person.MarriedDate;
                }

                _db.RELATIONSHIPs.InsertOnSubmit(relationship);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void UpdateRelative(FamilyMemberDTO person, FamilyMemberDTO relative, RelationTypeDTO relationType)
        {
            throw new NotImplementedException();
        }

        public void DeleteRelative(FamilyMemberDTO person, FamilyMemberDTO relative)
        {
            throw new NotImplementedException();
        }
        
        public IList<AchievementInfo> GetAchievements(FamilyMemberDTO person)
        {
            try
            {
                return _getAchievements(person);
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
                mem_event.IDAchievement = achievement.AchievementType.ID;
                mem_event.AchievementDate = achievement.AchievementDate;
                mem_event.Description = achievement.Description;

                _db.MEMBER_EVENTs.InsertOnSubmit(mem_event);
                this._save();
                achievement.ID = mem_event.IDAchievementMember;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void UpdateAchievement(FamilyMemberDTO person, AchievementInfo achievement)
        {
            try
            {
                IEnumerable<MEMBER_EVENT> matches =
                    from achieve in _db.MEMBER_EVENTs
                    where achieve.IDAchievementMember == achievement.ID
                    select achieve;

                MEMBER_EVENT mapper = matches.Single();
                mapper.IDAchievementMember = achievement.ID;
                mapper.IDMember = person.ID;

                // System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException: 
                // Operation is not valid due to the current state of the object.!!!
                // mapper.IDEvent = achievement.AchievementType.ID;

                mapper.EVENT = _db.EVENTs.Single(e => e.IDAchievement == achievement.AchievementType.ID);
                mapper.AchievementDate = achievement.AchievementDate;
                mapper.Description = achievement.Description;

                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void DeleteAchievement(AchievementInfo achievement)
        {
            try
            {
                IEnumerable<MEMBER_EVENT> matches =
                    from achieve in _db.MEMBER_EVENTs
                    where achieve.IDAchievementMember == achievement.ID
                    select achieve;
                
                MEMBER_EVENT mapper = matches.Single();

                _db.MEMBER_EVENTs.DeleteOnSubmit(mapper);

                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void ReportDeath(FamilyMemberDTO person)
        {
            try
            {
                DEATH_INFO death = new DEATH_INFO();
                death.IDMember = person.ID;
                death.IDBuryPlace = person.DeathInfo.BuryPlace.ID;
                death.IDBuryReason = person.DeathInfo.Reason.ID;
                death.BuryDay = person.DeathInfo.DeathDay;

                _db.DEATH_INFOs.InsertOnSubmit(death);
                this._save();

                person.DeathInfo.ID = person.ID;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void UpdateDeathInfo(FamilyMemberDTO person)
        {
            try
            {
                IEnumerable<DEATH_INFO> matches =
                    from deathInf in _db.DEATH_INFOs
                    where deathInf.IDMember == person.ID
                    select deathInf;

                DEATH_INFO mapper = matches.Single();
                
                mapper.IDMember = person.ID;

                // System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException: 
                // Operation is not valid due to the current state of the object.!!!
                // mapper.IDBuryPlace = person.DeathInfo.BuryPlace.ID;
                mapper.BURYPLACE = 
                    _db.BURYPLACEs.Single(place => place.IDBuryPlace == person.DeathInfo.BuryPlace.ID);

                mapper.BURYREASON = 
                    _db.BURYREASONs.Single(reason => reason.IDBuryReason == person.DeathInfo.Reason.ID);

                mapper.BuryDay = person.DeathInfo.DeathDay;

                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void DeleteDeathInfo(FamilyMemberDTO person)
        {

            try
            {
                IEnumerable<DEATH_INFO> matches =
                    from deathInf in _db.DEATH_INFOs
                    where deathInf.IDMember == person.ID
                    select deathInf;

                DEATH_INFO mapper = matches.Single();

                _db.DEATH_INFOs.DeleteOnSubmit(mapper);

                this._save();
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
                MEMBER memberMapper = _search(obj).SingleOrDefault();
                _updateModel(ref memberMapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        /// <summary>
        /// Deletes entirely a person and his/her family tree in DB.
        /// CAUTION: This action cannot be undone !
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(FamilyMemberDTO obj)
        {
            try
            {
                _entirelyDeletePerson(obj);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        private void _entirelyDeletePerson(FamilyMemberDTO obj)
        {
            Stack<MEMBER> stack = new Stack<MEMBER>();
            MEMBER mapper = _search(obj).Single();

            // Turn of auto submit changes.
            //_autoSubmitChanges = false;

            while (true)
            {
                // 1. Delete Death Info.
                if (mapper.DEATH_INFO != null)
                    _db.DEATH_INFOs.DeleteOnSubmit(mapper.DEATH_INFO);

                // 2. Delete all Events or Achievements.

                foreach (MEMBER_EVENT memEvent in mapper.MEMBER_EVENTs)
                    _db.MEMBER_EVENTs.DeleteOnSubmit(memEvent);

                // 3. Delete all relationship (recursively).
                foreach (RELATIONSHIP relation in mapper.RELATIONSHIPs)
                {
                    _db.RELATIONSHIPs.DeleteOnSubmit(relation);
                }

                foreach (RELATIONSHIP relation in mapper.RELATIONSHIPs1)
                {
                    stack.Push(relation.MEMBER);
                    _db.RELATIONSHIPs.DeleteOnSubmit(relation);
                }

                // 4. Delete the person in MEMEBER table. The end.
                _db.MEMBERs.DeleteOnSubmit(mapper);

                if (stack.Count > 0)
                    mapper = stack.Pop();
                else
                    break;
            }

            this.Save();

            // Turn on auto submit changes.
            _autoSubmitChanges = true;
        }
     
        /// <summary>
        /// Delete a person and shift all his/her children to a specific another person.
        /// </summary>
        /// <param name="deletedPerson">The person which would be deleted.</param>
        /// <param name="newParent">The person will contain the children of the deleted person.</param>
        public void DeleteAndShiftDescendants(FamilyMemberDTO deletedPerson, FamilyMemberDTO newParent)
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

        public RelationTypeDTO GetRelationship(FamilyMemberDTO youngerPerson, FamilyMemberDTO olderPerson)
        {
            try
            {
                return _findRelationship(youngerPerson, olderPerson);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        public IList<FamilyMemberDTO> FindByFullName(string fullName)
        {
            try
            {
                IEnumerable<FamilyMemberDTO> matches =
                    from person in _db.MEMBERs
                    where (person.LastName + " " + person.FirstName).ToUpper() 
                                == fullName.ToUpper()
                    select ConvertToDTO(person);

                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public IList<FamilyMemberDTO> FindByFirstName(string firstName)
        {
            try
            {
                IEnumerable<FamilyMemberDTO> matches =
                    from person in _db.MEMBERs
                    where person.FirstName.ToUpper() == firstName.ToUpper()
                    select ConvertToDTO(person);

                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public IList<FamilyMemberDTO> FindByLastName(string lastName)
        {
            try
            {
                IEnumerable<FamilyMemberDTO> matches =
                    from person in _db.MEMBERs
                    where person.LastName.ToUpper() == lastName.ToUpper()
                    select ConvertToDTO(person);

                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }


        internal MEMBER ConvertToMapper(FamilyMemberDTO dto)
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

            if (mapper.JOB != null)
                dto.Job = JobModel.ConvertToDTO(mapper.JOB);

            if (mapper.BIRTHPLACE != null)
                dto.HomeTown = HomeTownModel.ConvertToDTO(mapper.BIRTHPLACE);

            if (mapper.GenLevel != null)
                dto.GenerationNumber = (int)mapper.GenLevel;

            if (mapper.FAMILY != null)
                dto.Family = FamilyModel.ConvertToDTO(mapper.FAMILY);

            dto.Address = mapper.Address;
            dto.Birthday = mapper.Birthday.GetValueOrDefault();
            dto.DateJointFamily = mapper.DayJointFamily.GetValueOrDefault();
            dto.DeathInfo = _getDeathInfo(mapper);

            dto.State = DataState.Copied;

            return dto;
        }

        internal static DeathInfo _getDeathInfo(MEMBER mapper)
        {
            if (mapper.DEATH_INFO == null)
                return null;

            DeathInfo deathInfo = new DeathInfo();
            deathInfo.BuryPlace = BuryPlaceModel.ConvertToDTO(mapper.DEATH_INFO.BURYPLACE);
            deathInfo.Reason = DeathReasonModel.ConvertToDTO(mapper.DEATH_INFO.BURYREASON);
            deathInfo.DeathDay = mapper.DEATH_INFO.BuryDay.GetValueOrDefault();
            deathInfo.State = DataState.Copied;
            return deathInfo;
        }

        internal FamilyMemberDTO _getParent(bool isFather, MEMBER personMapper)
        {
            FamilyMemberDTO parent = null;
            IEnumerable<RELATIONSHIP> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs
                    where (relation.IDMember1 == personMapper.IDMember)
                        && (relation.RELATIONSHIP_TYPE.Name.ToUpper() == DefaultSettings.RelationType.Child.ToString().ToUpper())
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

        internal List<FamilyMemberDTO> _getSpouses(MEMBER personMapper)
        {
            List<FamilyMemberDTO> spouses = new List<FamilyMemberDTO>();
            IEnumerable<RELATIONSHIP> relationships = null;

            if (IsFemale(personMapper))
            {
                // Get her husband(s).
                relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.RELATIONSHIP_TYPE.Name.ToUpper() == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
                    select relation;
                List<RELATIONSHIP> lstRelations = relationships.ToList();
                if (lstRelations.Count > 0)
                {
                    foreach (RELATIONSHIP r in lstRelations)
                    {
                        FamilyMemberDTO husband = ConvertToDTO(r.MEMBER);
                        husband.MarriedDate = r.MarriedDate.GetValueOrDefault();
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
                        && (relation.RELATIONSHIP_TYPE.Name.ToUpper() == DefaultSettings.RelationType.Spouse.ToString().ToUpper())
                    select relation;
                List<RELATIONSHIP> lstRelations = relationships.ToList();
                if (lstRelations.Count > 0)
                {
                    foreach (RELATIONSHIP r in lstRelations)
                    {
                        FamilyMemberDTO wife = ConvertToDTO(r.MEMBER1);
                        wife.MarriedDate = r.MarriedDate.GetValueOrDefault();
                        spouses.Add(wife);
                    }
                }
            }

            return spouses;
        }

        internal List<FamilyMemberDTO> _getChildren(MEMBER personMapper)
        {
            List<FamilyMemberDTO> children = null;
            IEnumerable<RELATIONSHIP> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.RELATIONSHIP_TYPE.Name.ToUpper() == DefaultSettings.RelationType.Child.ToString().ToUpper())
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

        internal static List<int> _getChildrenIDs(MEMBER personMapper)
        {
            IEnumerable<int> relationships = null;

            relationships =
                    from relation in personMapper.RELATIONSHIPs1
                    where (relation.IDMember2 == personMapper.IDMember)
                        && (relation.RELATIONSHIP_TYPE.Name.ToUpper() == DefaultSettings.RelationType.Child.ToString().ToUpper())
                    select relation.IDMember1;

            return relationships.ToList(); ;
        }

        private List<AchievementInfo> _getAchievements(FamilyMemberDTO dto)
        {
            IEnumerable<MEMBER> matches =
                from person in _db.MEMBERs
                where person.IDMember == dto.ID
                select person;

            MEMBER personMapper = matches.Single();

            List<AchievementInfo> achievements = new List<AchievementInfo>();
            foreach (MEMBER_EVENT memEvent in personMapper.MEMBER_EVENTs)
            {
                AchievementInfo aInfo = new AchievementInfo();
                aInfo.AchievementType = AchievementTypeModel.ConvertToDTO(memEvent.EVENT);
                aInfo.AchievementDate = memEvent.AchievementDate.GetValueOrDefault();
                aInfo.ID = memEvent.IDAchievementMember;
                aInfo.Description = memEvent.Description;
                aInfo.State = DataState.Copied;
                achievements.Add(aInfo);
            }

            return achievements;
        }

        internal static bool IsFemale(MEMBER personMapper)
        {
            return (byte)personMapper.Gender == FTreeConst.FEMALE ? true : false;
        }

        private void _updateModel(ref MEMBER mapper, FamilyMemberDTO dto)
        {
            mapper.IDMember = dto.ID;
            
            if (dto.Family.ID > 0)
                mapper.FAMILY = 
                    _db.FAMILies.Single(f => f.IDFamily == dto.Family.ID);
            
            mapper.FirstName = dto.FirstName;
            mapper.LastName = dto.LastName;
            mapper.Gender = dto.IsFemale ? (byte)FTreeConst.FEMALE : (byte)FTreeConst.MALE;
            mapper.Birthday = dto.Birthday;

            if (dto.HomeTown.ID > 0)
                mapper.BIRTHPLACE =
                    _db.BIRTHPLACEs.Single(place => place.IDBirthPlace == dto.HomeTown.ID);
            
            mapper.Address = dto.Address;
            mapper.DayJointFamily = dto.DateJointFamily;

            if (dto.Job.ID > 0)
                mapper.JOB =
                    _db.JOBs.Single(job => job.IDJob == dto.Job.ID);

            if (dto.IsDead)
            {
                // System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException: 
                // Operation is not valid due to the current state of the object.!!!
                //  mapper.DEATH_INFO.IDBuryReason = bla bla bla... (ERROR!)
                //mapper.DEATH_INFO.MEMBER = mapper;
                mapper.DEATH_INFO.BuryDay = dto.DeathInfo.DeathDay;

                mapper.DEATH_INFO.BURYREASON = 
                    _db.BURYREASONs.Single(reason => reason.IDBuryReason == dto.DeathInfo.Reason.ID);

                mapper.DEATH_INFO.BURYPLACE = 
                    _db.BURYPLACEs.Single(place => place.IDBuryPlace == dto.DeathInfo.BuryPlace.ID);
            }

            if (dto.GenerationNumber > 0)
                mapper.GenLevel = dto.GenerationNumber;
        }

        private IEnumerable<MEMBER> _search(FamilyMemberDTO obj)
        {
            IEnumerable<MEMBER> matches =
                from entry in _db.MEMBERs
                where entry.IDMember == obj.ID
                select entry;

            return matches;
        }

        private RelationTypeDTO _findRelationship(FamilyMemberDTO youngerPerson, FamilyMemberDTO olderPerson)
        {
            RelationTypeDTO relation = null;

            IEnumerable<RELATIONSHIP_TYPE> matches =
                from relationship in _db.RELATIONSHIPs
                join relationType in _db.RELATIONSHIP_TYPEs
                on relationship.IDRelationship equals relationType.IDRelationship
                where (youngerPerson.ID == relationship.IDMember1)
                    && (olderPerson.ID == relationship.IDMember2)
                select relationType;

            RELATIONSHIP_TYPE mapper = matches.SingleOrDefault();

            relation = RelationTypeModel.ConvertToDTO(mapper);

            return relation;
        }

        #endregion
    }
}