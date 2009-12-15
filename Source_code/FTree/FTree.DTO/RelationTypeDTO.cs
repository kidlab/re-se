﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class RelationTypeDTO : DataTransferObject
    {
        public string Name { get; set; }

        public RelationTypeDTO()
            : base()
        {
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
