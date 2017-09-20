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


    public void BuildBasicHospital()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICHOSPITAL, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentHospital()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTHOSPITAL, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedHospital()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDHOSPITAL, GameManager.GM.m_activePlanet);
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

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicTerraformer()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICTERRAFORMINGSTATION, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentTerraformer()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTTERRAFORMINGSTATION, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedTerraformer()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDTERRAFORMINGSTATION, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicNullMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICNULLSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentNullMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTNULLSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedNullMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDNULLSTONEMINE, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicHappyMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICHAPPYSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentHappyMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTHAPPYSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedHappyMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDHAPPYSTONEMINE, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicHealthMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICHEALTHSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentHealthMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTHEALTHSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedhealthMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDHEALTHSTONEMINE, GameManager.GM.m_activePlanet);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BuildBasicTerraformingMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.BASICTERRAFORMINGSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildDecentTerraformingMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.DECENTTERRAFORMINGSTONEMINE, GameManager.GM.m_activePlanet);
    }

    public void BuildAdvancedTerraformingMine()
    {
        GameManager.GM.m_activePlanet.m_buildings.SetBuilding(eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE, GameManager.GM.m_activePlanet);
    }
}
