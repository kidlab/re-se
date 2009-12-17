﻿using System;
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
        private DeathInfo _deathInfo = null;

		public string FirstName {get; set;}
        public string LastName { get; set; }
        public bool IsFemale { get; set; }
        public JobDTO Job { get; set; }
        public HomeTownDTO HomeTown { get; set; }
        public string Address { get; set; }

        public FamilyDTO Family { get; set; }
		public DateTime Birthday {get; set;}
        public DateTime DateJointFamily { get; set; }

        public FamilyMemberDTO Father { get; set; }
        public FamilyMemberDTO Mother { get; set; }
        public List<FamilyMemberDTO> Spouses { get; set; }
        public List<FamilyMemberDTO> Descendants { get; set; }
        public int GenerationNumber { get; set; }

        public List<AchievementInfo> Achievements { get; set; }
            
        public bool IsDead { get; private set; }
        public DeathInfo DeathInfo
        {
            get
            {
                return _deathInfo;
            }
            set
            {
                _deathInfo = value;
                if (value != null)
                    IsDead = true;
            }
        }

        public FamilyMemberDTO()
            : base()
        {
            Family = new FamilyDTO();
            Job = new JobDTO();
            HomeTown = new HomeTownDTO();
            Spouses = new List<FamilyMemberDTO>();
            Descendants = new List<FamilyMemberDTO>();
        }

        public FamilyMemberDTO(FamilyDTO family)
            : base()
        {
            Family = family;
            Job = new JobDTO();
            HomeTown = new HomeTownDTO();
            Spouses = new List<FamilyMemberDTO>();
            Descendants = new List<FamilyMemberDTO>();
        }

        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}
