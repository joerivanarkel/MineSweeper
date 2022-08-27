using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeperLogic
{
    public class CellEnumerator
    {
        public Cell FoundCell { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
    }
}