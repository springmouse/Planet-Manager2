using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eOrbital
{
    TERRESTRIALEARTHLIKE,
    TERRESTRIALROCKY,
    ASTROIDBELT,
    GASGAINT,
    END
}

public class Orbital
{
    public string m_name;

    public float m_baseMinerals;
    public float m_baseEnergy;
    public float m_baseFood;

    public float m_mineralIncome;
    public float m_energyIncome;
    public float m_foodIncome;

    public float m_maxSpace;
    public float m_health;
    public float m_happiness;

    public float m_usedSpace;

    public List<SpecialResources> m_spList;

    public BuildingsManager m_buildings;

    public float m_resourceTimer;

    public Orbital()
    {
        m_buildings = new BuildingsManager();
        m_resourceTimer = 0;
    }

    public virtual void Update(float deltaTime)
    {
        m_resourceTimer += deltaTime;

        m_buildings.Update(deltaTime, this);

        foreach (SpecialResources sp in m_spList)
        {
            sp.Update(deltaTime);
        }

        if (m_resourceTimer >= 15.0f)
        {
            Income.Instance.AddResouceIncome(m_mineralIncome, m_energyIncome, m_foodIncome);
            m_resourceTimer = 0;
        }
    }
}

public class StarterPlanet : Orbital
{
    public StarterPlanet()
    {
        m_name = "Terrastrial Earth";

        m_baseMinerals = Random.Range(5, 11);
        m_baseEnergy = Random.Range(5, 11);
        m_baseFood = Random.Range(5, 20);

        m_mineralIncome = m_baseMinerals;
        m_energyIncome = m_baseEnergy;
        m_foodIncome = m_baseFood;

        m_maxSpace = Random.Range(50, 101);
        m_health = 100;
        m_happiness = 100;

        m_spList = new List<SpecialResources>();

        for (int i = 0; i < 3; i++)
        {
            m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
        }
    }
}

public class TerrestrialEarchLike : Orbital
{
    public TerrestrialEarchLike()
    {
        m_name = "Terrastrial Earth Like";

        m_baseMinerals = Random.Range(1, 11);
        m_baseEnergy = Random.Range(1, 9);
        m_baseFood = Random.Range(5, 20);

        m_mineralIncome = m_baseMinerals;
        m_energyIncome = m_baseEnergy;
        m_foodIncome = m_baseFood;

        m_maxSpace = Random.Range(25, 101);
        m_health = 100;
        m_happiness = 100;

        m_spList = new List<SpecialResources>();

        for (int i = 0; i < 3; i++)
        {
            m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
        }
    }

    
}

public class TerrestrialRocky : Orbital
{
    public TerrestrialRocky()
    {
        m_name = "Terrastrial Rocky";

        m_baseMinerals = Random.Range(1, 21);
        m_baseEnergy = Random.Range(1, 9);
        m_baseFood = Random.Range(1, 9);

        m_mineralIncome = m_baseMinerals;
        m_energyIncome = m_baseEnergy;
        m_foodIncome = m_baseFood;

        m_maxSpace = Random.Range(25, 101);
        m_health = 50;
        m_happiness = 75;

        m_spList = new List<SpecialResources>();

        for (int i = 0; i < 3; i++)
        {
            m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
        }
    }
}

public class AStroidBelt : Orbital
{
    public AStroidBelt()
    {
        m_name = "Astroid Belt";

        m_baseMinerals = Random.Range(16, 31);
        m_baseEnergy = Random.Range(1, 6);
        m_baseFood = Random.Range(1, 3);

        m_mineralIncome = m_baseMinerals;
        m_energyIncome = m_baseEnergy;
        m_foodIncome = m_baseFood;

        m_maxSpace = Random.Range(1, 26);
        m_health = 25;
        m_happiness = 25;

        m_spList = new List<SpecialResources>();
        
        m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
    }
}

public class GasGaint : Orbital
{
    public GasGaint()
    {
        m_name = "Gas Gaint";

        m_baseMinerals = Random.Range(1, 9);
        m_baseEnergy = Random.Range(10, 26);
        m_baseFood = Random.Range(1, 6);

        m_mineralIncome = m_baseMinerals;
        m_energyIncome = m_baseEnergy;
        m_foodIncome = m_baseFood;

        m_maxSpace = Random.Range(1, 26);
        m_health = 25;
        m_happiness = 25;

        m_spList = new List<SpecialResources>();

        m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
        m_spList.Add(Factory.Instance.CreatNewSpecialResouces());
    }
}
