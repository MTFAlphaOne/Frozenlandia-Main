using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL_Main.ConfigObjects
{
    public class ItemSpawn
    {
        public ItemType Item { get; set; }
        public int MinAmmount { get; set; }
        public int MaxAmmount { get; set; }
    }
}
