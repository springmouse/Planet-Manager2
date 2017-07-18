using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    private static Factory factory;
    private Factory() { }

    public static Factory Instance
    {
        get
        {
            if (factory == null)
            {
                factory = new Factory();
            }
            return factory;
        }
    }

    public Orbital CreatStarterPlanet()
    {
        return new StarterPlanet();
    }

    public Orbital CreatNewOrbital(eOrbital h)
    {
        switch (h)
        {
            case eOrbital.TERRESTRIALEARTHLIKE:
                return new TerrestrialEarchLike();

            case eOrbital.TERRESTRIALROCKY:
                return new TerrestrialRocky();

            case eOrbital.ASTROIDBELT:
                return new AStroidBelt();

            case eOrbital.GASGAINT:
                return new GasGaint();

            case eOrbital.END:
                return null;
        }

        return null;
    }

    private Orbital CreatNewOrbital()
    {
        eOrbital h = RandomOrbital();

        switch (h)
        {
            case eOrbital.TERRESTRIALEARTHLIKE:
                return new TerrestrialEarchLike();

            case eOrbital.TERRESTRIALROCKY:
                return new TerrestrialRocky();

            case eOrbital.ASTROIDBELT:
                return new AStroidBelt();

            case eOrbital.GASGAINT:
                return new GasGaint();

            case eOrbital.END:
                return null;
        }

        return null;
    }

    public string CreaSystemName()
    {
        return null;
    }

    public List<Orbital> CreatNewSystem()
    {
        int systemSize = Random.Range(1, 16);

        List<Orbital> newSystem = new List<Orbital>();

        for (int i = 0; i <= systemSize; i++)
        {
            newSystem.Add(CreatNewOrbital());
        }

        return newSystem;
    }

    public List<Orbital> CreatNewSystem(int min, int max)
    {
        int systemSize = Random.Range(min, max + 1);

        List<Orbital> newSystem = new List<Orbital>();

        for (int i = 0; i <= systemSize; i++)
        {
            newSystem.Add(CreatNewOrbital());
        }

        return newSystem;
    }

    public SpecialResources CreatNewSpecialResouces()
    {
        SpecialResources.eResouceType type = RandomResource();

        switch (type)
        {
            case SpecialResources.eResouceType.NULL:
                return new NullStone();

            case SpecialResources.eResouceType.HEALTHSTONE:
                return new HealthStone();

            case SpecialResources.eResouceType.TERRAFORMINGSTONE:
                return new TerraFormingStone();

            case SpecialResources.eResouceType.HAPPYSTONE:
                return new HappyStone();
        }

        return new NullStone();
    }

    public States CreatNewState(eGameStates type)
    {
        switch (type)
        {
            case eGameStates.MENU:
                return new MenuState();

            case eGameStates.INGAME:
                return new InGameState();

            default:
                Debug.LogError("INVALIDE STATE PASSED!!!");
                return null;

        }
    }

    public Buildings CreatNewBuilding(eBuildingTypes type, Orbital planet)
    {
        switch (type)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICMINE:
                return new BasicMine(planet);

            case eBuildingTypes.DECENTMINE:
                return new DecentMine(planet);

            case eBuildingTypes.ADVANCEDMINE:
                return new AdvancedMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICPOWER:
                return new BasicPower(planet);

            case eBuildingTypes.DECENTPOWER:
                return new DecentMine(planet);

            case eBuildingTypes.ADVANCEDPOWER:
                return new AdvancedMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICFARM:
                return new BasicFarm(planet);

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
                Debug.LogError("INVALID BUILDING TYPE PASSED (FACTORY)");
                break;
        }

        Debug.LogError("INVALID BUILDING TYPE PASSED (FACTORY)");
        return null;
    }

    private SpecialResources.eResouceType RandomResource()
    {
        int r = Random.Range(0, 150);

        if (r <= 25)
        {
            return SpecialResources.eResouceType.HEALTHSTONE;
        }

        if (r <= 50)
        {
            return SpecialResources.eResouceType.TERRAFORMINGSTONE;
        }

        if (r <= 75)
        {
            return SpecialResources.eResouceType.HAPPYSTONE;
        }

        return SpecialResources.eResouceType.NULL;
    }

    private eOrbital RandomOrbital()
    {
        int r = Random.Range(1, 201);

        if (r <= 25)
        {
            return eOrbital.TERRESTRIALEARTHLIKE;
        }

        if (r <= 100)
        {
            return eOrbital.TERRESTRIALROCKY;
        }

        if (r <= 125)
        {
            return eOrbital.ASTROIDBELT;
        }

        if (r <= 200)
        {
            return eOrbital.GASGAINT;
        }

        Debug.LogError("OUTSIDE OR RANDOM ORBITAL CREATION RANGE");
        return eOrbital.TERRESTRIALEARTHLIKE;
    }
}
