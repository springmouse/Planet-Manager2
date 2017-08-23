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
                InGameState IGS = new InGameState();
                IGS.Init();
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
