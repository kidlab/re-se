using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IBuryPlaceModel : ILinqModel<BuryPlaceDTO>
    {
        IEnumerable<BuryPlaceDTO> FindByName(String name);
    }
}
