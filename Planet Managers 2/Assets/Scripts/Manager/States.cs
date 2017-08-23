using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System;

public enum eGameStates
{
    MENU,
    INGAME
}

public class States
{
    protected bool m_active;

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

    public string[] m_mapNames;

    protected override void onEnter()
    {
        GameManager.GM.m_InGameRoot.SetActive(false);
        GameManager.GM.m_InGame = false;

        m_mapNames = Directory.GetFiles(Application.dataPath + "/Saves/", "*.xml");

        for (int i = 0; i < m_mapNames.Length; i++)
        {
            Debug.Log(m_mapNames[i]);
        }
    }

    override public void Update(float deltaTime)
    {
        if (Input.GetKeyDown("l"))
        {
            GameManager.GM.PushState();
        }
    }
}

[Serializable]
public class InGameState : States
{
   
    [Serializable]
    public class OrbitalDicToList
    {
        public string key;

        [XmlArray(("All_orbitals_in_system")), XmlArrayItem(typeof(Orbital), ElementName = "orbitals_in_system")]
        public List<Orbital> value;

        public OrbitalDicToList()
        {
        }

        public OrbitalDicToList(string k, List<Orbital> v)
        {
            key = k;
            value = v;
        }
    }


    [XmlArray("List_of_Dictonary_of_universe"), XmlArrayItem(typeof(OrbitalDicToList), ElementName = "Key_and_Value")]
    public List<OrbitalDicToList> ToSave = new List<OrbitalDicToList>();

    [XmlIgnore]
    public Dictionary<string, List<Orbital>> m_Systems = new Dictionary<string, List<Orbital>>();

    [XmlArray("System_Names_List"), XmlArrayItem(typeof(string), ElementName = "System_Names")]
    public List<string> m_systemNames = new List<string>();

    [XmlArray("Player_orbitals_List"), XmlArrayItem(typeof(Orbital), ElementName = "Player_plantes")]
    public List<Orbital> m_playerOwned = new List<Orbital>();

    [XmlArray("Active_System_of_orbitals_List"), XmlArrayItem(typeof(Orbital), ElementName = "Active_plantes")]
    public List<Orbital> m_activeSystem = new List<Orbital>();

    [XmlElement(ElementName = "Active_System_Name")]
    public string m_activeSytemName;

    [XmlElement(ElementName = "Active_Planet")]
    public Orbital m_activePlanet;

    public string m_saveName = "tester";

    bool m_changedActivePlanets;

    public InGameState()
    {
    }

    public void Init()
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

    protected override void onEnter()
    {
        GameManager.GM.m_InGameRoot.SetActive(true);
        GameManager.GM.m_InGame = true;

    }

    protected override void onExit()
    {
        GameManager.GM.m_InGameRoot.SetActive(false);
        GameManager.GM.m_InGame = false;
    }

    override public void Update(float deltaTime)
    {
        if (m_active)
        {
            if (m_changedActivePlanets == true)
            {
                ChangedActivePlanets();
            }

            if (Input.GetKeyDown("s"))
            {
                Serialize();
                Debug.Log("We Attempted to save the game");
            }

            if (Input.GetKeyDown("escape"))
            {
                GameManager.GM.PopState();
            }

            m_activePlanet.Update(deltaTime);

            GameManager.GM.m_incomeMineralsText.text = "Minerals Income = " + m_activePlanet.CalculateMineralIncome();
            GameManager.GM.m_incomeEnergyText.text = "Energy Income = " + m_activePlanet.CalculatePowerIncome();
            GameManager.GM.m_incomeFoodText.text = "Food Income = " + m_activePlanet.CalculateFoodIncome();

            GameManager.GM.m_reaserIncomeText.text = "Reaserch Income = " + m_activePlanet.CalculateReaserchIncome();

            GameManager.GM.m_planetSpaceText.text = "Space = " + m_activePlanet.m_usedSpace + "/" + m_activePlanet.m_maxSpace;
            GameManager.GM.m_planetHealthText.text = "Health = " + m_activePlanet.m_health;
            GameManager.GM.m_planetHappynessText.text = "Happyness = " + m_activePlanet.m_happiness;
        }
    }

    private void ChangedActivePlanets()
    {
        m_changedActivePlanets = false;

        GameManager.GM.m_activePlanet = m_activePlanet;

        GameManager.GM.m_baseMineralsText.text = "Base Minerals = " + m_activePlanet.m_baseMinerals;
        GameManager.GM.m_baseEnergyText.text = "Base Energy = " + m_activePlanet.m_baseEnergy;
        GameManager.GM.m_baseFoodText.text = "Base Food = " + m_activePlanet.m_baseFood;

        GameManager.GM.m_relicText.text = "Relics = " + m_activePlanet.m_relics;

        List<SpecialResources> used = new List<SpecialResources>();

        int count = 0;

        int textNum = 0;

        foreach (SpecialResources sp in m_activePlanet.m_spList)
        {
            if (CheckIfUsed(sp, used) == false)
            {
                foreach (SpecialResources Special in m_activePlanet.m_spList)
                {
                    if (sp.m_type == Special.m_type && CheckIfUsed(Special, used) == false)
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

    public void Serialize()
    {
        XmlSerializer mySerializer = new XmlSerializer(typeof(InGameState));

        FileStream FS = File.Open("SavedGame.xml", FileMode.Open);
        FS.SetLength(0);
        FS.Close();

        System.IO.Directory.CreateDirectory(Application.dataPath + "/Saves");

        StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/Saves/" + m_saveName + ".xml");

        ConvertDicToList();
        
        mySerializer.Serialize(streamWriter, this);

        streamWriter.Close();
    }

    public static InGameState Deserialize(string name)
    {
        XmlSerializer mySerializer = new XmlSerializer(typeof(InGameState));

        StreamReader SR = new StreamReader(Application.dataPath + "/Saves/" + name + ".xml");

        InGameState p = mySerializer.Deserialize(SR) as InGameState;
        
        SetUpContainers(p);

        SR.Close();

        return p;
    }

    private static void SetUpContainers(InGameState p)
    {
        ConvertListToDic(p);

        GatherPlayerOwned(p);

        p.m_activeSystem.Clear();
        p.m_activeSystem = p.m_Systems[p.m_activeSytemName];

        GatherActivePlanet(p);

        SetUsedIDs(p);
    }

    private static void SetUsedIDs(InGameState p)
    {

        GameManager.GM.m_usedID.Clear();

        foreach (string name in p.m_systemNames)
        {
            foreach (Orbital o in p.m_Systems[name])
            {
                GameManager.GM.m_usedID.Add(o.ID);
            }
        }

    }

    private static void GatherActivePlanet(InGameState p)
    {
        Orbital activePlanet = p.m_activePlanet;
        p.m_activePlanet = null;

        foreach (string name in p.m_systemNames)
        {
            foreach (Orbital check in p.m_Systems[name])
            {
                if (activePlanet.ID == check.ID)
                {
                    p.m_activePlanet = check;
                    return;
                }
            }
        }

    }

    private static void GatherPlayerOwned(InGameState p)
    {
        List<Orbital> playerOwned = new List<Orbital>();

        foreach (Orbital O in p.m_playerOwned)
        {
            foreach (string name in p.m_systemNames)
            {
                foreach (Orbital check in p.m_Systems[name])
                {
                    if (O.ID == check.ID)
                    {
                        if (playerOwned.Count > 0)
                        {
                            int count = 0;
                            foreach (Orbital var in playerOwned)
                            {
                                if (check.ID == var.ID)
                                {
                                    count++;
                                    break;
                                }
                            }
                            if (count == 0)
                            {
                                playerOwned.Add(check);
                                break;
                            }
                        }
                        else
                        {
                            playerOwned.Add(check);
                            break;
                        }

                    }
                }
            }
        }
        
        p.m_playerOwned.Clear();
        p.m_playerOwned = playerOwned;
    }

    private static void ConvertListToDic(InGameState p)
    {
        p.m_Systems.Clear();
        foreach (InGameState.OrbitalDicToList I in p.ToSave)
        {
            p.m_Systems.Add(I.key, I.value);
        }
        p.ToSave.Clear();
    }

    private void ConvertDicToList()
    {
        ToSave.Clear();
        foreach (string name in m_systemNames)
        {
            ToSave.Add(new OrbitalDicToList(name, m_Systems[name]));
        }
    }
}
