using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDMINE, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicPowerPlant()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICPOWER, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicFarm()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICFARM, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
