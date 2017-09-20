﻿using System.Collections;
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

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicPowerPlant()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICPOWER, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentPowerPlant()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTPOWER, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedPowerPlant()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDPOWER, GameManager.GM.m_activePlanet);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicFarm()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICFARM, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentFarm()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTFARM, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedFarm()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDFARM, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicLab()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICREASERCH, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentLab()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTREASERCH, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedLab()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDREASERCH, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicPark()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICPARK, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentPark()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTPARK, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedPark()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDPARK, GameManager.GM.m_activePlanet);
    }
}
