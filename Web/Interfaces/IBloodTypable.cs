using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeSangre.Enums;

namespace BancoDeSangre.Interfaces
{
    public interface IBloodTypable
    {
        BloodType BloodType { get; set; }
    }
}
