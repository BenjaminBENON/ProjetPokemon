using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetC_
{
    public class Pokemon
    {
        private string m_name;

        private int baseLifePoints;
        private int currentLifePoints;

        private int m_speedAttackPoint;
        private int m_attackPoint;
        private int m_defensePoint;

        private int m_precisionPoint;
        private int m_esquivePoint;

        private int m_level;

        // Attack list (4)
        List<Attack> m_vAttacks;

        // Getter / Setter
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public int BaseLifePoints
        {
            get { return baseLifePoints; }
            set { baseLifePoints = value; }
        }

        public int CurrentLifePoints
        {
            get { return currentLifePoints; }
            set { currentLifePoints = value; }
        }

        public int SpeedAttackPoint
        {
            get { return m_speedAttackPoint; }
            set { m_speedAttackPoint = value; }
        }

        public int AttackPoint
        {
            get { return m_attackPoint; }
            set { m_attackPoint = value; }
        }

        public int DefensePoint
        {
            get { return m_defensePoint; }
            set { m_defensePoint = value; }
        }

        public int PrecisionPoint
        {
            get { return m_precisionPoint; }
            set { m_precisionPoint = value; }
        }

        public int EsquivePoint
        {
            get { return m_esquivePoint; }
            set { m_esquivePoint = value; }
        }

        public int Level
        {
            get { return m_level; }
            set { m_level = value; }
        }

        // Constructor
        public Pokemon()
        {
        }
    }
}
