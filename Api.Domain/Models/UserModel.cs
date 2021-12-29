using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserModel
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
