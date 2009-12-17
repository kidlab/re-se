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
        FamilyMemberDTO FamilyMember { get; set; }
        
        /// <summary>
        /// Sets the list of all available home towns.
        /// </summary>
        IList<HomeTownDTO> HomeTownsList { set; }

        /// <summary>
        /// Sets the list of all available occupations.
        /// </summary>
        IList<JobDTO> CareersList { set; }

        /// <summary>
        /// A family member that has relationship to this person, e.g, father, mother, wife,...
        /// </summary>
        FamilyMemberDTO RelativePerson { get; set; }

        /// <summary>
        /// All other members in the family associate with this person.
        /// </summary>
        IList<FamilyMemberDTO> FamilyMembers { get; set; }

        /// <summary>
        /// Sets the list of all available relation types.
        /// </summary>
        IList<RelationTypeDTO> RelationTypesList {set; }

        /// <summary>
        /// The selected relation type.
        /// </summary>
        RelationTypeDTO RelationType { get; set; }        
    }
}
