using ConsoleApp1.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    interface IPetOwnerReader
    {
        IList<PetOwner> GetPetOwners();
    }
}
