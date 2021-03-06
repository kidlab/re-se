﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using MVPCore;

namespace FTree.Model
{
    public interface IRelationTypeModel : ILinqModel<RelationTypeDTO>
    {
        IEnumerable<RelationTypeDTO> FindByName(String relationName);
    }
}
