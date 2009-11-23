using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    public class AchievementInfo : DataObject
	{
		public string Title {get; set;}
		public string Description {get; set;}
		public DateTime AchievementDate {get; set;}
	}
}