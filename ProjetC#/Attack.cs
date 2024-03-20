using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Attack
{
    private string m_name;

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public virtual void Use()
    {
        Console.WriteLine("Utilisation de l'attaque ->" + Name);
    }

    public Attack(string name)
    {
        Name = name;
    }

}