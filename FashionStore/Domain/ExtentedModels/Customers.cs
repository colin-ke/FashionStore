using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class Customers
    {
        public Genders Gender 
        {
            get { return gender ? Genders.Male : Genders.Female; }
            set { Gender = value; gender = value == Genders.Male ? true : false; }
        }

        public bool CheckPassword(string pwd)
        {
            return pwd == this.Password;
        }
    }

    public enum Genders { Male, Female }
}
