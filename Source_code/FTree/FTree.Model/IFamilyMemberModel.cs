using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IFamilyMemberModel : ILinqModel<FamilyMemberDTO>
    {
        /// <summary>
        /// Delete a person and shift all his/her children to a specific another person.
        /// </summary>
        /// <param name="deletedPerson">The person which would be deleted.</param>
        /// <param name="newParent">The person will contain the children of the deleted person.</param>
        void DeleteAndShiftDescendants(FamilyMemberDTO deletedPerson, FamilyMemberDTO newParent);

        void AddRelative(FamilyMemberDTO person, FamilyMemberDTO relative, RelationTypeDTO relationType);
        void UpdateRelative(FamilyMemberDTO person, FamilyMemberDTO relative, RelationTypeDTO relationType);
        void DeleteRelative(FamilyMemberDTO person, FamilyMemberDTO relative);

        IList<AchievementInfo> GetAchievements(FamilyMemberDTO person);
        void AssignAchievement(FamilyMemberDTO person, AchievementInfo achievement);
        void UpdateAchievement(FamilyMemberDTO person, AchievementInfo achievement);
        void DeleteAchievement(AchievementInfo achievement);

        void ReportDeath(FamilyMemberDTO person);
        void UpdateDeathInfo(FamilyMemberDTO person);
        void DeleteDeathInfo(FamilyMemberDTO person);

        IList<FamilyMemberDTO> GetSpouses(FamilyMemberDTO person);
        IList<FamilyMemberDTO> GetDescendants(FamilyMemberDTO person);
        FamilyMemberDTO GetParent(bool isFather, FamilyMemberDTO dto);

        IList<FamilyMemberDTO> GetAll(int familyID);
        IList<FamilyMemberDTO> GetAll(string familyName);

        RelationTypeDTO GetRelationship(FamilyMemberDTO youngerPerson, FamilyMemberDTO olderPerson);

        IList<FamilyMemberDTO> FindByFullName(string fullName);
        IList<FamilyMemberDTO> FindByFirstName(string firstName);
        IList<FamilyMemberDTO> FindByLastName(string lastName);
    }
}
