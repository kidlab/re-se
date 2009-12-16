using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPCore;
using FTree.DTO;

namespace FTree.Model
{
    public interface IDeathReasonModel : ILinqModel<DeathReasonDTO>
    {
        IEnumerable<DeathReasonDTO> FindByName(String name);
    }
}
