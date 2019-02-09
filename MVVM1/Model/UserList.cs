using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.Model
{
    public class UserList
    {
        public List<Users> Users { get; set; }
        public UserList()
        {
            Users = new List<Users>();
        }
    }
}
