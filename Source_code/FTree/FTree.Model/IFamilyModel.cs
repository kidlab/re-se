﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IFamilyModel : ILinqModel<FamilyDTO>
    {
        IEnumerable<FTree.DTO.FamilyDTO> FindByName(String familyName);
        FamilyMemberDTO LoadFullFamilyTree(int rootID);
    }
}
