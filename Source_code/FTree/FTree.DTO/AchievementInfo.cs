﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    public class AchievementInfo : DataTransferObject
	{
        public AchievementType AchievementType { get; set; }
		public string Description {get; set;}
		public DateTime AchievementDate {get; set;}

        public AchievementInfo()
            : base()
        {
            AchievementType = new AchievementType();
        }

        public override string ToString()
        {
            return AchievementType.ToString();
        }
	}
}