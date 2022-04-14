using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetins.Models.User.Output
{
    public class BlockUserOutput
    {
        public bool LockoutEnabled { get; set; }
        public string LockoutEnd { get; set; }
    }
}
