using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameStates
{
    MENU,
    INGAME
}

public class States
{
    private bool m_active;

    ///////////////////////////////////////////////////

    public bool isActive()
    {
        return m_active;
    }

    public void enter()
    {
        m_active = true;
        onEnter();
    }


    public void exit()
    {
        m_active = false;
        onExit();
    }

    virtual public void onPushed() { }

    virtual public void onPopped() { }

    virtual public void Update (float deltaTime) {}
    
    ///////////////////////////////////////////////////

    virtual protected void onEnter() { }
    
    virtual protected void onExit() { }
}

public class MenuState : States
{
    override public void Update(float deltaTime)
    {
        Debug.Log("Running");
    }
}

public class InGameState : States
{
    public Dictionary<string, List<Orbital>> m_Systems = new Dictionary<string, List<Orbital>>();
    public List<string> m_systemNames = new List<string>();

    public List<Orbital> m_playerOwned = new List<Orbital>();

    public List<Orbital> m_activeSystem;
    public string m_activeSytemName;
    public Orbital m_activePlanet;

    bool m_changedActivePlanets;

    public InGameState()
    {
        m_systemNames.Add("Sol");
        m_activeSytemName = m_systemNames[0];

        m_Systems.Add(m_activeSytemName, Factory.Instance.CreatNewSystem(5, 12));
        m_Systems[m_activeSytemName].Add(Factory.Instance.CreatStarterPlanet());

        m_activeSystem = m_Systems[m_activeSytemName];

        m_playerOwned.Add(m_activeSystem[m_activeSystem.Count - 1]);

        m_activePlanet = m_playerOwned[0];
        m_changedActivePlanets = true;
    }

    override public void Update(float deltaTime)
    {
        if (m_changedActivePlanets == true)
        {
            ChangedActivePlanets();
        }

        m_activePlanet.Update(deltaTime);

        GameManager.GM.m_incomeMineralsText.text = "Minerals Income = " + m_activePlanet.m_mineralIncome;
        GameManager.GM.m_incomeEnergyText.text = "Energy Income = " + m_activePlanet.m_energyIncome;
        GameManager.GM.m_incomeFoodText.text = "Food Income = " + m_activePlanet.m_foodIncome;

        GameManager.GM.m_planetSpaceText.text = "Space = " + m_activePlanet.m_usedSpace + "/" + m_activePlanet.m_maxSpace;
        GameManager.GM.m_planetHealthText.text = "Health = " + m_activePlanet.m_health;
        GameManager.GM.m_planetHappynessText.text = "Happyness = " + m_activePlanet.m_happiness;

    }

    private void ChangedActivePlanets()
    {
        m_changedActivePlanets = false;

        GameManager.GM.m_activePlanet = m_activePlanet;

        GameManager.GM.m_baseMineralsText.text = "Base Minerals = " + m_activePlanet.m_baseMinerals;
        GameManager.GM.m_baseEnergyText.text = "Base Energy = " + m_activePlanet.m_baseEnergy;
        GameManager.GM.m_baseFoodText.text = "Base Food = " + m_activePlanet.m_baseFood;

        List<SpecialResources> used = new List<SpecialResources>();

        int count = 0;

        int textNum = 0;

        foreach (SpecialResources sp in m_activePlanet.m_spList)
        {
            if (CheckIfUsed(sp, used) == false)
            {
                foreach (SpecialResources Special in m_activePlanet.m_spList)
                {
                    if (sp.GetRosuceType() == Special.GetRosuceType() && CheckIfUsed(Special, used) == false)
                    {
                        count++;
                        used.Add(Special);
                    }
                }

                if (count > 0)
                {
                    GameManager.GM.m_specialResouces[textNum].text = sp.m_name + " " + count;
                }
                else
                {
                    GameManager.GM.m_specialResouces[textNum].text = "";
                }

                textNum++;
            }

            count = 0;
        }

        for (int i = textNum; i < 3; i++)
        {
            GameManager.GM.m_specialResouces[i].text = "";
        }
    }

    private bool CheckIfUsed(SpecialResources checker, List<SpecialResources> usedResouces)
    {
        foreach (SpecialResources sp in usedResouces)
        {
            if (checker == sp)
            {
                return true;
            }
        }
        return false;
    }
}
