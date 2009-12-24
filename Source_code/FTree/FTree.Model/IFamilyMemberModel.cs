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

        IList<FamilyMemberDTO> GetAll(int familyID);
        IList<FamilyMemberDTO> GetAll(string familyName);
        RelationTypeDTO GetRelationship(FamilyMemberDTO youngerPerson, FamilyMemberDTO olderPerson);
    }
}
