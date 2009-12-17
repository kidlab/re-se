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
        void AssignAchievement(FamilyMemberDTO person, AchievementInfo achievement);
        void ReportDeath(FamilyMemberDTO person, DeathInfo deathInfo);
        IList<FamilyMemberDTO> GetAll(int familyID);
        IList<FamilyMemberDTO> GetAll(string familyName);
    }
}
