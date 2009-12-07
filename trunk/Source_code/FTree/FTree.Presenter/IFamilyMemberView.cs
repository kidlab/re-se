using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IFamilyMemberView : IView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        bool IsFemale { get; set; }
        
        /// <summary>
        /// Sets the list of all available home towns.
        /// </summary>
        IList<HomeTownDTO> HomeTownsList { set; }

        /// <summary>
        /// The selected home town.
        /// </summary>
        HomeTownDTO HomeTown { get; set; }

        /// <summary>
        /// Sets the list of all available occupations.
        /// </summary>
        IList<JobDTO> CareersList { set; }

        /// <summary>
        /// The selected occupation.
        /// </summary>
        JobDTO Career { get; set; }

        string Address { get; set; }

        DateTime DateJoinFamily { get; set; }
        DateTime BirthDay { get; set; }

        /// <summary>
        /// A family member that has relationship to this person, e.g, father, mother, wife,...
        /// </summary>
        FamilyMemberDTO RelativePerson { get; set; }

        /// <summary>
        /// Sets the list of all available relation types.
        /// </summary>
        IList<RelationTypeDTO> RelationTypesList {set; }

        /// <summary>
        /// The family associate with this person.
        /// </summary>
        FamilyDTO Family { get; set; }

        /// <summary>
        /// The selected relation type.
        /// </summary>
        RelationTypeDTO RelationType { get; set; }        
    }
}
