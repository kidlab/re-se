using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Presenter
{
    public interface IFamilyView : IView
    {
        FamilyDTO Family{get;set;}
    }
}
