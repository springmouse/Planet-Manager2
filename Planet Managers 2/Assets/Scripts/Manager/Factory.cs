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
        StarterPlanet SP = new StarterPlanet();
        SP.Init();
        return SP;
    }

    public Orbital CreatNewOrbital(eOrbital h)
    {
        switch (h)
        {
            case eOrbital.TERRESTRIALEARTHLIKE:
                TerrestrialEarchLike TE = new TerrestrialEarchLike();
                TE.Init();
                return TE;

            case eOrbital.TERRESTRIALROCKY:
                TerrestrialRocky TR = new TerrestrialRocky();
                return TR;

            case eOrbital.ASTROIDBELT:
                AstroidBelt AB = new AstroidBelt();
                AB.Init();
                return AB;

            case eOrbital.GASGAINT:
                GasGaint GG = new GasGaint();
                GG.Init();
                return GG;

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
                TerrestrialEarchLike TE = new TerrestrialEarchLike();
                TE.Init();
                return TE;

            case eOrbital.TERRESTRIALROCKY:
                TerrestrialRocky TR = new TerrestrialRocky();
                TR.Init();
                return TR;

            case eOrbital.ASTROIDBELT:
                AstroidBelt AB = new AstroidBelt();
                AB.Init();
                return AB;

            case eOrbital.GASGAINT:
                GasGaint GG = new GasGaint();
                GG.Init();
                return GG;

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
        eResouceType type = RandomResource();

        switch (type)
        {
            case eResouceType.NULL:
                return new NullStone();

            case eResouceType.HEALTHSTONE:
                return new HealthStone();

            case eResouceType.TERRAFORMINGSTONE:
                return new TerraFormingStone();

            case eResouceType.HAPPYSTONE:
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
                InGameState IGS = InGameState.Deserialize("tester");
                //InGameState IGS = new InGameState();
                //IGS.Init();
                return IGS;

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
                return new DecentPower(planet);

            case eBuildingTypes.ADVANCEDPOWER:
                return new AdvancedPower(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICFARM:
                return new BasicFarm(planet);

            case eBuildingTypes.DECENTFARM:
                return new DecentFarm(planet);

            case eBuildingTypes.ADVANCEDFARM:
                return new AdvancedFarm(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICREASERCH:
                return new BasicLab(planet);

            case eBuildingTypes.DECENTREASERCH:
                return new DecentLab(planet);

            case eBuildingTypes.ADVANCEDREASERCH:
                return new AdvancedLab(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHOSPITAL:
                return new BasicHospital(planet);

            case eBuildingTypes.DECENTHOSPITAL:
                return new DecentHospital(planet);

            case eBuildingTypes.ADVANCEDHOSPITAL:
                return new AdvancedHospital(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICPARK:
                return new BasicPark(planet);

            case eBuildingTypes.DECENTPARK:
                return new DecentPark(planet);

            case eBuildingTypes.ADVANCEDPARK:
                return new AdvancedPark(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTATION:
                return new BasicTerraformingStation(planet);

            case eBuildingTypes.DECENTTERRAFORMINGSTATION:
                return new DecentTerraformingStation(planet);

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTATION:
                return new AdvancedTerraformingStation(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICNULLSTONEMINE:
                return new BasicNullStoneMine(planet);

            case eBuildingTypes.DECENTNULLSTONEMINE:
                return new DecentNullStoneMine(planet);

            case eBuildingTypes.ADVANCEDNULLSTONEMINE:
                return new AdvancedNullStoneMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHAPPYSTONEMINE:
                return new BasicHappyStoneMine(planet);

            case eBuildingTypes.DECENTHAPPYSTONEMINE:
                return new DecentHappyStoneMine(planet);

            case eBuildingTypes.ADVANCEDHAPPYSTONEMINE:
                return new AdvancedHappyStoneMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICHEALTHSTONEMINE:
                return new BasicHealthStoneMine(planet);

            case eBuildingTypes.DECENTHEALTHSTONEMINE:
                return new DecentHealthStoneMine(planet);

            case eBuildingTypes.ADVANCEDHEALTHSTONEMINE:
                return new AdvancedHealthStoneMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.BASICTERRAFORMINGSTONEMINE:
                return new BasicTerraformingStoneMine(planet);

            case eBuildingTypes.DECENTTERRAFORMINGSTONEMINE:
                return new DecentTerraformingStoneMine(planet);

            case eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE:
                return new AdvancedTerraformingStoneMine(planet);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            case eBuildingTypes.END:
                Debug.LogError("INVALID BUILDING TYPE PASSED (FACTORY)");
                break;
        }

        Debug.LogError("INVALID BUILDING TYPE PASSED (FACTORY)");
        return null;
    }

    private eResouceType RandomResource()
    {
        int r = Random.Range(0, 150);

        if (r <= 25)
        {
            return eResouceType.HEALTHSTONE;
        }

        if (r <= 50)
        {
            return eResouceType.TERRAFORMINGSTONE;
        }

        if (r <= 75)
        {
            return eResouceType.HAPPYSTONE;
        }

        return eResouceType.NULL;
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
