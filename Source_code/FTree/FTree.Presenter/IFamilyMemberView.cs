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
        /// List of all available home towns.
        /// </summary>
        IList<HomeTownDTO> HomeTownsList { get; set; }

        /// <summary>
        /// The selected home town.
        /// </summary>
        HomeTownDTO HomeTown { get; set; }

        /// <summary>
        /// List of all available occupations.
        /// </summary>
        IList<CareerDTO> CareersList { get; set; }

        /// <summary>
        /// The selected occupation.
        /// </summary>
        CareerDTO Career { get; set; }

        string Address { get; set; }

        DateTime DateJoinFamily { get; set; }
        DateTime BirthDay { get; set; }

        /// <summary>
        /// A family member that has relationship to this person, e.g, father, mother, wife,...
        /// </summary>
        FamilyMemberDTO RelativePerson { get; set; }

        /// <summary>
        /// List of all available relation types.
        /// </summary>
        IList<RelationTypeDTO> RelationTypesList { get; set; }

        /// <summary>
        /// The selected relation type.
        /// </summary>
        RelationTypeDTO RelationType { get; set; }        
    }
}
