using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    public class PersonDTO : DataObject
    {
		public string Name {get; set;}
		public DateTime BirthDay {get; set;}
		public DateTime DeathDay {get; set;}
		public Hashtable Ancestors {get; set;}
		public Hashtable Descendants {get; set;}
        public List<AchievementInfo> Achievements { get; set; }
    }
}
