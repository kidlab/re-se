﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTree.DTO
{
    public class BuryPlaceDTO : DataTransferObject
    {
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}