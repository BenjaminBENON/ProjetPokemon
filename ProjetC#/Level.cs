using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

public class Level
{
    private int m_currentLevel;
    private int m_currentXp;

    private int m_baseNeedXp;
    private int m_currentNeedXp;

    private float m_baseXpCalculCoeff;
    private float m_currentXpCalculCoeff;

    // Not used 
    private int m_maxLevel;

    public Level()
    {
        CurrentLevel = 0;

        // Calcul Coeff
        m_baseXpCalculCoeff = 1.005f;
        m_currentXpCalculCoeff = m_baseXpCalculCoeff;

        // Xp
        m_baseNeedXp = 100;
        m_currentNeedXp = m_baseNeedXp;
    }

    public int CurrentLevel
    {
        get { return m_currentLevel; }
        set { m_currentLevel = value; }
    }
    public int CurrentXp
    {
        get { return m_currentXp; }
        set {
            if (m_currentXp + value >= m_currentNeedXp)
            {
                m_currentXp = m_currentNeedXp;
                return;
            }
            m_currentXp = value; 
        }
    }

    public int CurrentNeedXp
    {
        get { return m_currentNeedXp; }
        set { m_currentNeedXp = value; }
    }
    public void Update()
    {
        if (m_currentXp >= m_currentNeedXp)
        {
            IncrementLevel();
        }
    }

    public void IncrementLevel()
    {
        m_currentLevel += 1;
        Console.WriteLine($"Congratulations! You reached level {CurrentLevel}!");
        CalculateNextLevel();
        m_currentXp = 0;

        Console.WriteLine($"XP necessary for the next level: {CurrentNeedXp}");
    }

    private void CalculateNextLevel()
    {
        m_currentXpCalculCoeff *= m_baseXpCalculCoeff;
        Console.WriteLine($"Actual Coeff: {m_currentXpCalculCoeff}");
        m_currentNeedXp = (int)(m_currentNeedXp * m_currentXpCalculCoeff);
    }
}
