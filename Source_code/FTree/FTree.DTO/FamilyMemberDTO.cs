using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FTree.DTO
{
    /// <summary>
    /// Represents for a person in the family.
    /// </summary>
    public class FamilyMemberDTO : DataTransferObject
    {
		public string FirstName {get; set;}
        public string LastName { get; set; }
        public bool IsFemale { get; set; }
        public CareerDTO Career { get; set; }
        public HomeTownDTO HomeTown { get; set; }
        public string Address { get; set; }

		public DateTime BirthDay {get; set;}
        public DateTime DateJoinFamily { get; set; }

        public FamilyMemberDTO Father { get; set; }
        public FamilyMemberDTO Mother { get; set; }
        public FamilyMemberDTO Spouse { get; set; }
		public Hashtable Descendants {get; set;}
        public int GenerationNumber { get; set; }

        public List<AchievementInfo> Achievements { get; set; }        
            
        public bool IsDead { get; set; }
        public DeathInfo DeathInfo { get; set; }

        public FamilyMemberDTO()
        {
            Career = new CareerDTO();
            HomeTown = new HomeTownDTO();
            Descendants = new Hashtable();
        }
    }
}
