using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IFamilyMangerView : IView
    {
        IList<FamilyDTO> Families { get; set; }
        FamilyDTO CurrentFamily { get;}
    }
}
