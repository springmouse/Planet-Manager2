using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class BuildingsManager
{
    public Dictionary<eBuildingTypes, List<Buildings>> m_buildings = new Dictionary<eBuildingTypes, List<Buildings>>();
    private List<eBuildingTypes> m_buildingTypes = new List<eBuildingTypes>();
    public BuildingsManager()
    {
        SetListOfBuildingTypesUp();

        foreach (eBuildingTypes type in m_buildingTypes)
        {
            CreatNewDictonarEntery(type);
        }
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
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) < planet.m_maxSpace)
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
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) < planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTPOWER:
                break;

            case eBuildingTypes.ADVANCEDPOWER:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICFARM:
                if (Income.Instance.m_minerals >= 20 && (planet.m_usedSpace + 1) < planet.m_maxSpace)
                {
                    planet.m_usedSpace += 1;
                    m_buildings[type].Add(Factory.Instance.CreatNewBuilding(type, planet));
                }
                break;

            case eBuildingTypes.DECENTFARM:
                break;

            case eBuildingTypes.ADVANCEDFARM:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICREASERCH:
                break;

            case eBuildingTypes.DECENTREASERCH:
                break;

            case eBuildingTypes.ADVANCEDREASERCH:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHOSPITAL:
                break;

            case eBuildingTypes.DECENTHOSPITAL:
                break;

            case eBuildingTypes.ADVANCEDHOSPITAL:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICPARK:
                break;

            case eBuildingTypes.DECENTPARK:
                break;

            case eBuildingTypes.ADVANCEDPARK:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTATION:
                break;

            case eBuildingTypes.DECENTTERRAFORMINGSTATION:
                break;

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTATION:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICNULLSTONEMINE:
                break;

            case eBuildingTypes.DECENTNULLSTONEMINE:
                break;

            case eBuildingTypes.ADVANCEDNULLSTONEMINE:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHAPPYSTONEMINE:
                break;

            case eBuildingTypes.DECENTHAPPYSTONEMINE:
                break;

            case eBuildingTypes.ADVANCEDHAPPYSTONEMINE:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHEALTHSTONEMINE:
                break;

            case eBuildingTypes.DECENTHEALTHSTONEMINE:
                break;

            case eBuildingTypes.ADVANCEDHEALTHSTONEMINE:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTONEMINE:
                break;

            case eBuildingTypes.DECENTTERRAFORMINGSTONEMINE:
                break;

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE:
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.END:
                Debug.LogError("INVALID BUILDING TYPE PASSED (BUILD MANAGER)");
                break;
        }
    }
}

public class Buildings
{
    protected float m_basicBuildTime = 20;
    protected float m_decentBuildTime = 40;
    protected float m_advancedBuildTime = 60;

    protected float m_timer;

    protected float m_basicCost = 20;
    protected float m_decentCost = 40;
    protected float m_advancedCost = 80;

    protected int m_mulitpliyer;

    protected int m_energyMaintanince;
    protected int m_foodMaintanince;

    protected bool m_isbuilding = true;

    protected Orbital m_planet;

    public virtual void Update(float deltaTime)
    {
        if (m_isbuilding)
        {
            m_timer -= deltaTime;

            if (m_timer <= 0)
            {
                IncomeType();

                m_planet.m_energyIncome += -m_energyMaintanince;
                m_planet.m_foodIncome += -m_foodMaintanince;

                m_isbuilding = false;
            }
        }
    }

    protected virtual void IncomeType() { }


    ~Buildings()
    {
        if (m_isbuilding == false)
        {
            CleanUp();
            m_planet.m_energyIncome += m_energyMaintanince;
            m_planet.m_foodIncome += m_foodMaintanince;
        }
    }

    protected virtual void CleanUp() {}
}

public class BasicMine : Buildings
{
    public BasicMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 3;
        m_foodMaintanince = 3;
    }

    protected override void IncomeType()
    {
        m_planet.m_mineralIncome += m_planet.m_baseMinerals * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_mineralIncome -= m_planet.m_baseMinerals * m_mulitpliyer;
    }
}

public class DecentMine : Buildings
{
    public DecentMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_decentCost;

        m_timer = m_decentBuildTime;

        m_planet = planet;

        m_mulitpliyer = 2;

        m_energyMaintanince = 4;
        m_foodMaintanince = 4;
    }
    
    protected override void IncomeType()
    {
        m_planet.m_mineralIncome += m_planet.m_baseMinerals * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_mineralIncome -= m_planet.m_baseMinerals * m_mulitpliyer;
    }

}

public class AdvancedMine : Buildings
{
    public AdvancedMine(Orbital planet)
    {
        Income.Instance.m_minerals -= m_advancedCost;

        m_timer = m_advancedBuildTime;

        m_planet = planet;

        m_mulitpliyer = 4;

        m_energyMaintanince = 6;
        m_foodMaintanince = 6;
    }
    
    protected override void IncomeType()
    {
        m_planet.m_mineralIncome += m_planet.m_baseMinerals * m_mulitpliyer;
    }
    
    protected override void CleanUp()
    {
        m_planet.m_mineralIncome -= m_planet.m_baseMinerals * m_mulitpliyer;
    }

}

public class BasicPower : Buildings
{
    public BasicPower(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 0;
        m_foodMaintanince = 3;
    }

    protected override void IncomeType()
    {
        m_planet.m_energyIncome += m_planet.m_baseEnergy * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_energyIncome -= m_planet.m_baseEnergy * m_mulitpliyer;
    }
}

public class BasicFarm : Buildings
{
    public BasicFarm(Orbital planet)
    {
        Income.Instance.m_minerals -= m_basicCost;

        m_timer = m_basicBuildTime;

        m_planet = planet;

        m_mulitpliyer = 1;

        m_energyMaintanince = 3;
        m_foodMaintanince = 0;
    }

    protected override void IncomeType()
    {
        m_planet.m_foodIncome += m_planet.m_baseFood * m_mulitpliyer;
    }

    protected override void CleanUp()
    {
        m_planet.m_foodIncome -= m_planet.m_baseFood * m_mulitpliyer;
    }
}