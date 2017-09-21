using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

public enum eBuildingTypes
{
    //mines
    BASICMINE,
    DECENTMINE,
    ADVANCEDMINE,
    //power plants
    BASICPOWER,
    DECENTPOWER,
    ADVANCEDPOWER,
    //farms
    BASICFARM,
    DECENTFARM,
    ADVANCEDFARM,
    //reaserch
    BASICREASERCH,
    DECENTREASERCH,
    ADVANCEDREASERCH,
    //hospital
    BASICHOSPITAL,
    DECENTHOSPITAL,
    ADVANCEDHOSPITAL,
    //park
    BASICPARK,
    DECENTPARK,
    ADVANCEDPARK,
    //terraforming
    BASICTERRAFORMINGSTATION,
    DECENTTERRAFORMINGSTATION,
    ADVANCEDTERRAFORMINGSTATION,
    //nullStone Mine
    BASICNULLSTONEMINE,
    DECENTNULLSTONEMINE,
    ADVANCEDNULLSTONEMINE,
    //happyStone mine
    BASICHAPPYSTONEMINE,
    DECENTHAPPYSTONEMINE,
    ADVANCEDHAPPYSTONEMINE,
    //healthstone Mine
    BASICHEALTHSTONEMINE,
    DECENTHEALTHSTONEMINE,
    ADVANCEDHEALTHSTONEMINE,
    //terraformingStone Mine
    BASICTERRAFORMINGSTONEMINE,
    DECENTTERRAFORMINGSTONEMINE,
    ADVANCEDTERRAFORMINGSTONEMINE,

    END
}

[Serializable]
public class BuildingsManager
{
    [Serializable]
    public class BuildingDicToList
    {
        public eBuildingTypes key;

        [XmlArray(("All_Buildings_On_Planet")), XmlArrayItem(typeof(Buildings), ElementName = "Buildings")]
        public List<Buildings> value = new List<Buildings>();

        public BuildingDicToList()
        {
        }

        public BuildingDicToList(eBuildingTypes k, List<Buildings> v)
        {
            key = k;
            value = v;
        }
    }
    
    [XmlIgnore]
    public List<eBuildingTypes> m_buildingTypes = new List<eBuildingTypes>();

    [XmlIgnore]
    public Dictionary<eBuildingTypes, List<Buildings>> m_buildings = new Dictionary<eBuildingTypes, List<Buildings>>();

    [XmlArray("ListOfBuildings"), XmlArrayItem(typeof(BuildingDicToList), ElementName = "Buildings")]
    public List<BuildingDicToList> m_listOfBuildings = new List<BuildingDicToList>();

    public BuildingsManager()
    {
        SetListOfBuildingTypesUp();

        foreach (eBuildingTypes type in m_buildingTypes)
        {
            CreatNewDictonarEntery(type);
        }
    }

    public void ConvertDicToList()
    {
        m_listOfBuildings.Clear();
        
        foreach (eBuildingTypes type in m_buildingTypes)
        {
            m_listOfBuildings.Add(new BuildingDicToList(type, m_buildings[type]));
        }
    }

    public void ConvertListToDic(Orbital planet)
    {
        m_buildings.Clear();
        
        foreach (BuildingDicToList holder in m_listOfBuildings)
        {
            foreach (Buildings building in holder.value)
            {
                building.SetPlanet(planet);
            }
        }

        foreach (BuildingDicToList item in m_listOfBuildings)
        {
            m_buildings[item.key] = item.value;
        }

        m_listOfBuildings.Clear();
    }

    private void CreatNewDictonarEntery(eBuildingTypes type)
    {
        m_buildings.Add(type, new List<Buildings>());
    }

    public void Update(float deltaTime, Orbital planet)
    {
        foreach (eBuildingTypes type in m_buildingTypes)
        {
            UpdateBuildings(type, deltaTime);
        }
    }

    private void UpdateBuildings(eBuildingTypes type, float deltaTime)
    {
        foreach (Buildings b in m_buildings[type])
        {
            b.Update(deltaTime);
        }
    }

    private void SetListOfBuildingTypesUp()
    {
        m_buildingTypes.Add(eBuildingTypes.BASICMINE);

        m_buildingTypes.Add(eBuildingTypes.DECENTMINE);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDMINE);

        m_buildingTypes.Add(eBuildingTypes.BASICPOWER);

        m_buildingTypes.Add(eBuildingTypes.DECENTPOWER);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDPOWER);

        m_buildingTypes.Add(eBuildingTypes.BASICFARM);

        m_buildingTypes.Add(eBuildingTypes.DECENTFARM);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDFARM);

        m_buildingTypes.Add(eBuildingTypes.BASICREASERCH);

        m_buildingTypes.Add(eBuildingTypes.DECENTREASERCH);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDREASERCH);

        m_buildingTypes.Add(eBuildingTypes.BASICHOSPITAL);

        m_buildingTypes.Add(eBuildingTypes.DECENTHOSPITAL);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDHOSPITAL);

        m_buildingTypes.Add(eBuildingTypes.BASICPARK);

        m_buildingTypes.Add(eBuildingTypes.DECENTPARK);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDPARK);

        m_buildingTypes.Add(eBuildingTypes.BASICTERRAFORMINGSTATION);

        m_buildingTypes.Add(eBuildingTypes.DECENTTERRAFORMINGSTATION);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDTERRAFORMINGSTATION);

        m_buildingTypes.Add(eBuildingTypes.BASICHEALTHSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.DECENTHEALTHSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDHEALTHSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.BASICHAPPYSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.DECENTHAPPYSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDHAPPYSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.BASICTERRAFORMINGSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.DECENTTERRAFORMINGSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.BASICNULLSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.DECENTNULLSTONEMINE);

        m_buildingTypes.Add(eBuildingTypes.ADVANCEDNULLSTONEMINE);
    }

    public void SetBuilding(eBuildingTypes type, Orbital planet)
    {
        switch (type)
        {

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICMINE:
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTMINE:
                if (Income.Instance.m_minerals >= 40 && m_buildings[eBuildingTypes.BASICMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;
            case eBuildingTypes.ADVANCEDMINE:
                if (Income.Instance.m_minerals >= 80 && m_buildings[eBuildingTypes.DECENTMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICPOWER:
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTPOWER:
                if (Income.Instance.m_minerals >= 40 && m_buildings[eBuildingTypes.BASICPOWER].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICPOWER].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDPOWER:
                if (Income.Instance.m_minerals >= 80 && m_buildings[eBuildingTypes.DECENTPOWER].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTPOWER].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICFARM:
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTFARM:
                if (Income.Instance.m_minerals >= 40 && m_buildings[eBuildingTypes.BASICFARM].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICFARM].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDFARM:
                if (Income.Instance.m_minerals >= 80 && m_buildings[eBuildingTypes.DECENTFARM].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTFARM].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICREASERCH:
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTREASERCH:
                if (Income.Instance.m_minerals >= 40 && m_buildings[eBuildingTypes.BASICREASERCH].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICREASERCH].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDREASERCH:
                if (Income.Instance.m_minerals >= 80 && m_buildings[eBuildingTypes.DECENTREASERCH].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTREASERCH].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHOSPITAL:
                if (Income.Instance.m_minerals >= 30 && Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] >= 1 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTHOSPITAL:
                if (Income.Instance.m_minerals >= 60 && Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] >= 2 && m_buildings[eBuildingTypes.BASICHOSPITAL].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICHOSPITAL].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDHOSPITAL:
                if (Income.Instance.m_minerals >= 120 && Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] >= 4 && m_buildings[eBuildingTypes.DECENTHOSPITAL].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTHOSPITAL].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICPARK:
                if (Income.Instance.m_minerals >= 30 && Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] >= 1 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTPARK:
                if (Income.Instance.m_minerals >= 60 && Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] >= 2 && m_buildings[eBuildingTypes.BASICPARK].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICREASERCH].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDPARK:
                if (Income.Instance.m_minerals >= 120 && Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] >= 4 && m_buildings[eBuildingTypes.DECENTPARK].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTREASERCH].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTATION:
                if (Income.Instance.m_minerals >= 30 && Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] >= 1)
                {
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTTERRAFORMINGSTATION:
                if (Income.Instance.m_minerals >= 60 && Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] >= 2)
                {
                    m_buildings[eBuildingTypes.BASICTERRAFORMINGSTATION].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTATION:
                if (Income.Instance.m_minerals >= 120 && Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] >= 4)
                {
                    m_buildings[eBuildingTypes.DECENTTERRAFORMINGSTATION].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICNULLSTONEMINE:
                if (Income.Instance.m_minerals >= 30 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTNULLSTONEMINE:
                if (Income.Instance.m_minerals >= 60 && m_buildings[eBuildingTypes.BASICNULLSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICNULLSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDNULLSTONEMINE:
                if (Income.Instance.m_minerals >= 120 && m_buildings[eBuildingTypes.DECENTNULLSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTNULLSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHAPPYSTONEMINE:
                if (Income.Instance.m_minerals >= 30 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTHAPPYSTONEMINE:
                if (Income.Instance.m_minerals >= 60 && m_buildings[eBuildingTypes.BASICHAPPYSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICHAPPYSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDHAPPYSTONEMINE:
                if (Income.Instance.m_minerals >= 120 && m_buildings[eBuildingTypes.DECENTHAPPYSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTHAPPYSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHEALTHSTONEMINE:
                if (Income.Instance.m_minerals >= 30 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTHEALTHSTONEMINE:
                if (Income.Instance.m_minerals >= 60 && m_buildings[eBuildingTypes.BASICHEALTHSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICHEALTHSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDHEALTHSTONEMINE:
                if (Income.Instance.m_minerals >= 120 && m_buildings[eBuildingTypes.DECENTHEALTHSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTHEALTHSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTONEMINE:
                if (Income.Instance.m_minerals >= 30 && (planet.m_usedSpace + 1) <= planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTTERRAFORMINGSTONEMINE:
                if (Income.Instance.m_minerals >= 60 && m_buildings[eBuildingTypes.BASICTERRAFORMINGSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.BASICTERRAFORMINGSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE:
                if (Income.Instance.m_minerals >= 120 && m_buildings[eBuildingTypes.DECENTTERRAFORMINGSTONEMINE].Count >= 2)
                {
                    planet.m_usedSpace += -1;
                    m_buildings[eBuildingTypes.DECENTTERRAFORMINGSTONEMINE].RemoveRange(0, 2);
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.END:
                Debug.LogError("INVALID BUILDING TYPE PASSED (BUILD MANAGER)");
                break;
        }
    }
}

//////////////////////////////////////////////////////////////////////////////
[Serializable]
[XmlInclude(typeof(Mine))]
[XmlInclude(typeof(BasicMine))]
[XmlInclude(typeof(DecentMine))]
[XmlInclude(typeof(AdvancedMine))]
[XmlInclude(typeof(Power))]
[XmlInclude(typeof(BasicPower))]
[XmlInclude(typeof(DecentPower))]
[XmlInclude(typeof(AdvancedPower))]
[XmlInclude(typeof(Farm))]
[XmlInclude(typeof(BasicFarm))]
[XmlInclude(typeof(DecentFarm))]
[XmlInclude(typeof(AdvancedFarm))]
[XmlInclude(typeof(Lab))]
[XmlInclude(typeof(BasicLab))]
[XmlInclude(typeof(DecentLab))]
[XmlInclude(typeof(AdvancedLab))]
[XmlInclude(typeof(Park))]
[XmlInclude(typeof(BasicPark))]
[XmlInclude(typeof(DecentPark))]
[XmlInclude(typeof(AdvancedPark))]
[XmlInclude(typeof(Hospital))]
[XmlInclude(typeof(BasicHospital))]
[XmlInclude(typeof(DecentHospital))]
[XmlInclude(typeof(AdvancedHospital))]
[XmlInclude(typeof(TerraformingStation))]
[XmlInclude(typeof(BasicTerraformingStation))]
[XmlInclude(typeof(DecentTerraformingStation))]
[XmlInclude(typeof(AdvancedTerraformingStation))]
[XmlInclude(typeof(NullStoneMine))]
[XmlInclude(typeof(BasicNullStoneMine))]
[XmlInclude(typeof(DecentNullStoneMine))]
[XmlInclude(typeof(AdvancedNullStoneMine))]
[XmlInclude(typeof(HappyStoneMine))]
[XmlInclude(typeof(BasicHappyStoneMine))]
[XmlInclude(typeof(DecentHappyStoneMine))]
[XmlInclude(typeof(AdvancedHappyStoneMine))]
[XmlInclude(typeof(HealthStoneMine))]
[XmlInclude(typeof(BasicHealthStoneMine))]
[XmlInclude(typeof(DecentHealthStoneMine))]
[XmlInclude(typeof(AdvancedHealthStoneMine))]
[XmlInclude(typeof(TerraformingStoneMine))]
[XmlInclude(typeof(BasicTerraformingStoneMine))]
[XmlInclude(typeof(DecentTerraformingStoneMine))]
[XmlInclude(typeof(AdvancedTerraformingStoneMine))]
public class Buildings
{
    protected float m_basicBuildTime = 20;
    protected float m_decentBuildTime = 40;
    protected float m_advancedBuildTime = 60;

    protected float m_specialbasicBuildTime = 40;
    protected float m_specialdecentBuildTime = 80;
    protected float m_specialadvancedBuildTime = 160;

    public float m_timer;

    protected float m_basicCost = 20;
    protected float m_decentCost = 40;
    protected float m_advancedCost = 80;

    protected float m_specialBasicCost = 30;
    protected float m_specialDecentCost = 60;
    protected float m_specialAdvancedCost = 120;

    public int m_mulitpliyer;

    public int m_energyMaintanince;
    public int m_foodMaintanince;

    public int m_healthCost;
    public int m_happynessCost;

    public int m_addPlanetSpace;

    public bool m_isbuilding = true;

    [XmlIgnore]
    protected Orbital m_planet;

    public Buildings()
    {
        m_timer = 0;

        m_planet = null;

        m_mulitpliyer = 0;

        m_energyMaintanince = 0;
        m_foodMaintanince = 0;

        m_happynessCost = 0;
        m_healthCost = 0;

        m_addPlanetSpace = 0;
    }

    public virtual void Update(float deltaTime)
    {
        if (m_isbuilding)
        {
            m_timer -= deltaTime;

            if (m_timer <= 0)
            {
                IncomeType();
                SpecialResourceIncome();

                m_planet.m_energyIncome += -m_energyMaintanince;
                m_planet.m_foodIncome += -m_foodMaintanince;

                m_planet.m_happiness += -m_happynessCost;
                m_planet.m_health += -m_healthCost;

                m_planet.m_maxSpace += m_addPlanetSpace;

                m_isbuilding = false;
            }
        }
    }

    public void SetPlanet(Orbital planet)
    {
        m_planet = planet;
    } 

    protected virtual void IncomeType() { }
    protected virtual void CleanUp() { }

    protected virtual void SpecialResourceIncome() { }
    protected virtual void CleanUpSpecialResource() { }

    ~Buildings()
    {
        if (m_isbuilding == false)
        {
            CleanUp();
            CleanUpSpecialResource();

            m_planet.m_energyIncome += m_energyMaintanince;
            m_planet.m_foodIncome += m_foodMaintanince;

            m_planet.m_health += m_healthCost;
            m_planet.m_happiness += m_happynessCost;

            m_planet.m_maxSpace -= m_addPlanetSpace;
        }
    }

}

//////////////////////////////////////////////////////////////////////////////

public class Mine : Buildings
{
    public Mine() { }

    protected override void IncomeType()
    {
        m_planet.m_mineralIncome += m_planet.m_baseMinerals * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_mineralIncome -= m_planet.m_baseMinerals * m_mulitpliyer;
    }
}

public class BasicMine : Mine
{
    public BasicMine() { }

    public BasicMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 3;
        m_foodMaintanince = 3;

        m_happynessCost = 2;
        m_healthCost = 3;
    }
}

public class DecentMine : Mine
{
    public DecentMine() { }
    
    public DecentMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_decentCost;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 4;
        m_foodMaintanince = 4;
        
        m_happynessCost = 2;
        m_healthCost = 3;
    }
}

public class AdvancedMine : Mine
{
    public AdvancedMine() { }

    public AdvancedMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_advancedCost;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;


        m_happynessCost = 2;
        m_healthCost = 4;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class Power : Buildings
{
    public Power() { }
    
    protected override void IncomeType()
    {
        m_planet.m_energyIncome += m_planet.m_baseEnergy * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_energyIncome -= m_planet.m_baseEnergy * m_mulitpliyer;
    }
}

public class BasicPower : Power
{
    public BasicPower() { }

    public BasicPower(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 0;
        m_foodMaintanince = 3;
        
        m_happynessCost = 2;
        m_healthCost = 3;
    }
}

public class DecentPower : Power
{
    public DecentPower() { }

    public DecentPower(Orbital planet)
    {
        Income.Instance.m_minerals -= m_decentCost;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 0;
        m_foodMaintanince = 4;
        
        m_happynessCost = 2;
        m_healthCost = 3;
    }
}

public class AdvancedPower : Power
{
    public AdvancedPower() { }

    public AdvancedPower(Orbital planet)
    {
        Income.Instance.m_minerals -= m_advancedCost;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 0;
        m_foodMaintanince = 6;
        
        m_happynessCost = 2;
        m_healthCost = 4;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class Farm : Buildings
{
    public Farm() { }

    protected override void IncomeType()
    {
        m_planet.m_foodIncome += m_planet.m_baseFood * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_foodIncome -= m_planet.m_baseFood * m_mulitpliyer;
    }
}

public class BasicFarm : Farm
{
    public BasicFarm() { }

    public BasicFarm(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 3;
        m_foodMaintanince = 0;


        m_happynessCost = 3;
        m_healthCost = 2;
    }
}

public class DecentFarm : Farm
{
    public DecentFarm() { }

    public DecentFarm(Orbital planet)
    {
        Income.Instance.m_minerals -= m_decentCost;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 4;
        m_foodMaintanince = 0;

        m_happynessCost = 3;
        m_healthCost = 2;
    }
}

public class AdvancedFarm : Farm
{
    public AdvancedFarm() { }

    public AdvancedFarm(Orbital planet)
    {
        Income.Instance.m_minerals -= m_advancedCost;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 6;
        m_foodMaintanince = 0;

        m_happynessCost = 4;
        m_healthCost = 2;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class Lab : Buildings
{
    public Lab() { }

    protected override void IncomeType()
    {
        m_planet.m_reaserchIncome += m_planet.m_relics * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_reaserchIncome -= m_planet.m_relics * m_mulitpliyer;
    }
}

public class BasicLab : Lab
{
    public BasicLab() { }

    public BasicLab(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 6;
        m_foodMaintanince = 3;

        m_happynessCost = 3;
        m_healthCost = 3;
    }
}

public class DecentLab : Lab
{
    public DecentLab() { }

    public DecentLab(Orbital planet)
    {
        Income.Instance.m_minerals -= m_decentCost;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 8;
        m_foodMaintanince = 4;

        m_happynessCost = 4;
        m_healthCost = 4;
    }
}

public class AdvancedLab : Lab
{
    public AdvancedLab() { }

    public AdvancedLab(Orbital planet)
    {
        Income.Instance.m_minerals -= m_advancedCost;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 12;
        m_foodMaintanince = 6;

        m_happynessCost = 6;
        m_healthCost = 6;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class Park : Buildings
{
    public Park() { }

    protected override void IncomeType()
    {
    }

    protected override void CleanUp()
    {
    }
}

public class BasicPark : Park
{
    public BasicPark() { }

    public BasicPark(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;
        Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] -= 1;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 2;
        m_foodMaintanince = 4;


        m_happynessCost = -12;
        m_healthCost = 0;
    }
}

public class DecentPark : Park
{
    public DecentPark() { }

    public DecentPark(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;
        Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] -= 2;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 2;
        m_foodMaintanince = 5;


        m_happynessCost = -24;
        m_healthCost = 0;
    }
}

public class AdvancedPark : Park
{
    public AdvancedPark() { }

    public AdvancedPark(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;
        Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE] -= 4;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 2;
        m_foodMaintanince = 6;
        
        m_happynessCost = -48;
        m_healthCost = 0;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class Hospital : Buildings
{
    public Hospital() { }

    protected override void IncomeType()
    {
    }

    protected override void CleanUp()
    {
    }
}

public class BasicHospital : Hospital
{
    public BasicHospital() { }

    public BasicHospital(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;
        Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] -= 1;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 4;
        m_foodMaintanince = 2;


        m_happynessCost = 0;
        m_healthCost = -12;
    }
}

public class DecentHospital : Hospital
{
    public DecentHospital() { }

    public DecentHospital(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;
        Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] -= 2;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 5;
        m_foodMaintanince = 3;


        m_happynessCost = 0;
        m_healthCost = -24;
    }
}

public class AdvancedHospital : Hospital
{
    public AdvancedHospital() { }

    public AdvancedHospital(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;
        Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE] -= 4;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 6;
        m_foodMaintanince = 4;

        m_happynessCost = 0;
        m_healthCost = -48;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class TerraformingStation : Buildings
{
    public TerraformingStation() { }

    protected override void IncomeType()
    {
    }

    protected override void CleanUp()
    {
    }
}

public class BasicTerraformingStation : Hospital
{
    public BasicTerraformingStation() { }

    public BasicTerraformingStation(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;
        Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] -= 1;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 6;
        m_foodMaintanince = 3;


        m_happynessCost = 0;
        m_healthCost = 0;

        m_addPlanetSpace = 5;
    }
}

public class DecentTerraformingStation : Hospital
{
    public DecentTerraformingStation() { }

    public DecentTerraformingStation(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;
        Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] -= 2;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 8;
        m_foodMaintanince = 4;


        m_happynessCost = 0;
        m_healthCost = 0;

        m_addPlanetSpace = 10;
    }
}

public class AdvancedTerraformingStation : Hospital
{
    public AdvancedTerraformingStation() { }

    public AdvancedTerraformingStation(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;
        Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE] -= 4;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 0;

        m_energyMaintanince = 10;
        m_foodMaintanince = 5;

        m_happynessCost = 0;
        m_healthCost = 0;

        m_addPlanetSpace = 20;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class NullStoneMine : Buildings
{
    public NullStoneMine() { }

    protected override void SpecialResourceIncome()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(NullStone))
            {
                sp.IncreaseGatherAmount(m_mulitpliyer);
            }
        }
    }

    protected override void CleanUpSpecialResource()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(NullStone))
            {
                sp.IncreaseGatherAmount(-m_mulitpliyer);
            }
        }
    }
}

public class BasicNullStoneMine : NullStoneMine
{
    public BasicNullStoneMine() { }

    public BasicNullStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;

        m_timer = m_specialbasicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;


        m_happynessCost = 4;
        m_healthCost = 4;
    }
}

public class DecentNullStoneMine : NullStoneMine
{
    public DecentNullStoneMine() { }

    public DecentNullStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;

        m_timer = m_specialdecentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 8;
        m_foodMaintanince = 8;


        m_happynessCost = 6;
        m_healthCost = 6;
    }
}

public class AdvancedNullStoneMine : NullStoneMine
{
    public AdvancedNullStoneMine() { }

    public AdvancedNullStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;

        m_timer = m_specialadvancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 10;
        m_foodMaintanince = 10;

        m_happynessCost = 8;
        m_healthCost = 8;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class HappyStoneMine : Buildings
{
    public HappyStoneMine() { }

    protected override void SpecialResourceIncome()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(HappyStone))
            {
                sp.IncreaseGatherAmount(m_mulitpliyer);
            }
        }
    }

    protected override void CleanUpSpecialResource()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(HappyStone))
            {
                sp.IncreaseGatherAmount(-m_mulitpliyer);
            }
        }
    }
}

public class BasicHappyStoneMine : HappyStoneMine
{
    public BasicHappyStoneMine() { }

    public BasicHappyStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;

        m_timer = m_specialbasicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;


        m_happynessCost = 4;
        m_healthCost = 4;
    }
}

public class DecentHappyStoneMine : HappyStoneMine
{
    public DecentHappyStoneMine() { }

    public DecentHappyStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;

        m_timer = m_specialdecentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 8;
        m_foodMaintanince = 8;


        m_happynessCost = 6;
        m_healthCost = 6;
    }
}

public class AdvancedHappyStoneMine : HappyStoneMine
{
    public AdvancedHappyStoneMine() { }

    public AdvancedHappyStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;

        m_timer = m_specialadvancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 10;
        m_foodMaintanince = 10;

        m_happynessCost = 8;
        m_healthCost = 8;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class HealthStoneMine : Buildings
{
    public HealthStoneMine() { }

    protected override void SpecialResourceIncome()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(HealthStone))
            {
                sp.IncreaseGatherAmount(m_mulitpliyer);
            }
        }
    }

    protected override void CleanUpSpecialResource()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(HealthStone))
            {
                sp.IncreaseGatherAmount(-m_mulitpliyer);
            }
        }
    }
}

public class BasicHealthStoneMine : HealthStoneMine
{
    public BasicHealthStoneMine() { }

    public BasicHealthStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;

        m_timer = m_specialbasicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;


        m_happynessCost = 4;
        m_healthCost = 4;
    }
}

public class DecentHealthStoneMine : HealthStoneMine
{
    public DecentHealthStoneMine() { }

    public DecentHealthStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;

        m_timer = m_specialdecentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 8;
        m_foodMaintanince = 8;


        m_happynessCost = 6;
        m_healthCost = 6;
    }
}

public class AdvancedHealthStoneMine : HealthStoneMine
{
    public AdvancedHealthStoneMine() { }

    public AdvancedHealthStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;

        m_timer = m_specialadvancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 10;
        m_foodMaintanince = 10;

        m_happynessCost = 8;
        m_healthCost = 8;
    }
}

//////////////////////////////////////////////////////////////////////////////

public class TerraformingStoneMine : Buildings
{
    public TerraformingStoneMine() { }

    protected override void SpecialResourceIncome()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(TerraFormingStone))
            {
                sp.IncreaseGatherAmount(m_mulitpliyer);
            }
        }
    }

    protected override void CleanUpSpecialResource()
    {
        foreach (SpecialResources sp in m_planet.m_spList)
        {
            if (sp.GetType() == typeof(TerraFormingStone))
            {
                sp.IncreaseGatherAmount(-m_mulitpliyer);
            }
        }
    }
}

public class BasicTerraformingStoneMine : TerraformingStoneMine
{
    public BasicTerraformingStoneMine() { }

    public BasicTerraformingStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialBasicCost;

        m_timer = m_specialbasicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;


        m_happynessCost = 4;
        m_healthCost = 4;
    }
}

public class DecentTerraformingStoneMine : TerraformingStoneMine
{
    public DecentTerraformingStoneMine() { }

    public DecentTerraformingStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialDecentCost;

        m_timer = m_specialdecentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 8;
        m_foodMaintanince = 8;


        m_happynessCost = 6;
        m_healthCost = 6;
    }
}

public class AdvancedTerraformingStoneMine : TerraformingStoneMine
{
    public AdvancedTerraformingStoneMine() { }

    public AdvancedTerraformingStoneMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_specialAdvancedCost;

        m_timer = m_specialadvancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 10;
        m_foodMaintanince = 10;

        m_happynessCost = 8;
        m_healthCost = 8;
    }
}

