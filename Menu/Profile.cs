using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Profile
    {  public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public Profile(string n, string g, string a)
        {
            this.Name = n;
            this.Gender = g;
            this.Age = a;
        }
      

    }
}