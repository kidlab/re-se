using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IMembersList : IView
    {
        IList<FamilyMemberDTO> MembersList { get; set; }
        bool Add(FamilyMemberDTO newMember);
        bool Update(FamilyMemberDTO member);
        bool Delete(FamilyMemberDTO member);
    }
}
