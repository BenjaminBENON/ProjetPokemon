using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetC_
{
    public class Attack
    {
        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public Attack(string name)
        {
            Name = name;
        }

    }
}