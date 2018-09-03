using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoAqua
{
    interface IConnect
    {
        void Initialize();
        bool OpenConnection();
        bool CloseConnection();
    }
}
