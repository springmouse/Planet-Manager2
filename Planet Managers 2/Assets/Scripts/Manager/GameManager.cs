using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject m_InGameRoot;
    public bool m_InGame = false;

    public GameObject m_mainMenu;

    public StateManager STM;

    public Orbital m_activePlanet;

    public Text m_totalRunTimeText;
    private float m_totalRunTime;

    #region UI

    public Text m_mineralText;
    public Text m_energyText;
    public Text m_FoodText;
    public Text m_reaserchText;

    public Text m_NullStoneText;
    public Text m_HappyStoneText;
    public Text m_HealthStoneText;
    public Text m_TerraformingStoneText;

    #region planetUI            
    public Text m_baseMineralsText;
    public Text m_baseEnergyText;
    public Text m_baseFoodText;

    public Text m_incomeMineralsText;
    public Text m_incomeEnergyText;
    public Text m_incomeFoodText;

    public Text m_relicText;
    public Text m_reaserIncomeText;

    public Text m_planetSpaceText;
    public Text m_planetHealthText;
    public Text m_planetHappynessText;

    public Text m_incomeTimer;
    public Text m_reaserchTimer;

    public Text[] m_specialResouces;
    #endregion

    #region Buildings

    public Text[] m_mines;
    public Text[] m_power;
    public Text[] m_farm;

    public Text[] m_reaserch;

    public Text[] m_park;
    public Text[] m_clinic;
    public Text[] m_Terraformer;

    public Text[] m_nullStoneMine;
    public Text[] m_happyStoneMine;
    public Text[] m_healthStoneMine;
    public Text[] m_terraformingStoneMine;

    public GameObject m_nullMineHolder;
    public GameObject m_happyMineHolder;
    public GameObject m_healthMineHolder;
    public GameObject m_TerraformingMineHolder;

    #endregion

    #endregion

    public List<int> m_usedID = new List<int>();

    public static GameManager GM;

    void Start ()
    {
        if (GM == null)
        {
            GM = this;
        }

        STM = new StateManager();

        MenuState ms = (MenuState)Factory.Instance.CreatNewState(eGameStates.MENU);
        STM.RegisterState(ms);

        STM.PushState(0);

        gameObject.GetComponent<ButtonBehavioursMenu>().SetMenuState(ms);

        Application.runInBackground = true;
	}


    public void RegisterInGameState(States IGS)
    {
        STM.RegisterState(IGS);
    }
	
	void Update ()
    {
        if (STM.ActiveStateCount() > 0)
        {
            STM.Update(Time.deltaTime);

            if (m_InGame)
            {
                m_mineralText.text = "Minerals = " + (int)Income.Instance.m_minerals;
                m_energyText.text = "Energy = " + (int)Income.Instance.m_energy;
                m_FoodText.text = "Food = " + (int)Income.Instance.m_food;
                m_reaserchText.text = "Reaserch = " + (int)Income.Instance.m_reaserch;

                m_NullStoneText.text = "NullStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.NULL) + " + " + GatherAmount(eResouceType.NULL).ToString();
                m_HappyStoneText.text = "HappyStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.HAPPYSTONE) + " + " + GatherAmount(eResouceType.HAPPYSTONE).ToString();
                m_HealthStoneText.text = "HealthStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.HEALTHSTONE) + " + " + GatherAmount(eResouceType.HEALTHSTONE).ToString();
                m_TerraformingStoneText.text = "TerraformingStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.TERRAFORMINGSTONE) + " + " + GatherAmount(eResouceType.TERRAFORMINGSTONE).ToString();

                m_reaserchTimer.text = "Reaserch in: " + (int)m_activePlanet.GetReaserchTimerRemaining();
                m_incomeTimer.text = "Income in: " + (int)m_activePlanet.GetResourceTimerRemaining();
                
                m_incomeMineralsText.text = "Minerals Income = " + m_activePlanet.CalculateMineralIncome();
                m_incomeEnergyText.text = "Energy Income = " + m_activePlanet.CalculatePowerIncome();
                m_incomeFoodText.text = "Food Income = " + m_activePlanet.CalculateFoodIncome();

                m_reaserIncomeText.text = "Reaserch Income = " + m_activePlanet.CalculateReaserchIncome();

                m_planetSpaceText.text = "Space = " + m_activePlanet.m_usedSpace + "/" + m_activePlanet.m_maxSpace;
                m_planetHealthText.text = "Health = " + m_activePlanet.m_health;
                m_planetHappynessText.text = "Happyness = " + m_activePlanet.m_happiness;

                m_totalRunTime += Time.deltaTime;

                UpdateBuildingsText();
            }
        }

        m_totalRunTimeText.text = "Game Run time: " + m_totalRunTime;
    }

    private float GatherAmount(eResouceType type)
    {
        float holder = 0;

        switch (type)
        {
            case eResouceType.NULL:
                foreach (SpecialResources sp in m_activePlanet.m_spList)
                {
                    if (sp.GetType() == typeof(NullStone))
                    {
                        holder += sp.m_amountGathered;
                    }
                }
                break;

            case eResouceType.HEALTHSTONE:
                foreach (SpecialResources sp in m_activePlanet.m_spList)
                {
                    if (sp.GetType() == typeof(HealthStone))
                    {
                        holder += sp.m_amountGathered;
                    }
                }
                break;
            case eResouceType.TERRAFORMINGSTONE:
                foreach (SpecialResources sp in m_activePlanet.m_spList)
                {
                    if (sp.GetType() == typeof(TerraFormingStone))
                    {
                        holder += sp.m_amountGathered;
                    }
                }
                break;
            case eResouceType.HAPPYSTONE:
                foreach (SpecialResources sp in m_activePlanet.m_spList)
                {
                    if (sp.GetType() == typeof(HappyStone))
                    {
                        holder += sp.m_amountGathered;
                    }
                }
                break;
            case eResouceType.END:
                break;
            default:
                break;
        }

        return holder;
    }

    private void UpdateBuildingsText()
    {
        m_mines[0].text = "Basic Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICMINE].Count);
        m_mines[1].text = "Decent Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTMINE].Count);
        m_mines[2].text = "Advanced Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDMINE].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_power[0].text = "Basic Power: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICPOWER].Count);
        m_power[1].text = "Decent Power: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTPOWER].Count);
        m_power[2].text = "Advanced Power: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDPOWER].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_farm[0].text = "Basic Farm: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICFARM].Count);
        m_farm[1].text = "Decent Farm: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTFARM].Count);
        m_farm[2].text = "Advanced Farm: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDFARM].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_reaserch[0].text = "Basic Lab: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICREASERCH].Count);
        m_reaserch[1].text = "Decent Lab: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTREASERCH].Count);
        m_reaserch[2].text = "Advanced Lab: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDREASERCH].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_clinic[0].text = "Basic Clinic: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICHOSPITAL].Count);
        m_clinic[1].text = "Decent Clinic: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTHOSPITAL].Count);
        m_clinic[2].text = "Advanced Clinic: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDHOSPITAL].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_park[0].text = "Basic Park: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICPARK].Count);
        m_park[1].text = "Decent Park: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTPARK].Count);
        m_park[2].text = "Advanced Park: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDPARK].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_Terraformer[0].text = "Basic Terraformer: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICTERRAFORMINGSTATION].Count);
        m_Terraformer[1].text = "Decent Terraformer: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTTERRAFORMINGSTATION].Count);
        m_Terraformer[2].text = "Advanced Terraformer: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDTERRAFORMINGSTATION].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_nullStoneMine[0].text = "Basic Null Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICNULLSTONEMINE].Count);
        m_nullStoneMine[1].text = "Decent Null Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTNULLSTONEMINE].Count);
        m_nullStoneMine[2].text = "Advanced Null Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDNULLSTONEMINE].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_happyStoneMine[0].text = "Basic Happy Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICHAPPYSTONEMINE].Count);
        m_happyStoneMine[1].text = "Decent Happy Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTHAPPYSTONEMINE].Count);
        m_happyStoneMine[2].text = "Advanced Happy Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDHAPPYSTONEMINE].Count);
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_healthStoneMine[0].text = "Basic Health Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICHEALTHSTONEMINE].Count);
        m_healthStoneMine[1].text = "Decent Health Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTHEALTHSTONEMINE].Count);
        m_healthStoneMine[2].text = "Advanced Health Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDHEALTHSTONEMINE].Count);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_terraformingStoneMine[0].text = "Basic Terraforming Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICTERRAFORMINGSTONEMINE].Count);
        m_terraformingStoneMine[1].text = "Decent Terraforming Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTTERRAFORMINGSTONEMINE].Count);
        m_terraformingStoneMine[2].text = "Advanced Terraforming Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDTERRAFORMINGSTONEMINE].Count);

    }

    public void PushState()
    {
        STM.PushState(1);
    }

    public void PopState()
    {
        STM.PopState();
    }

    public void RemoveInGameState(InGameState IGS)
    {

        STM.RemoveRegisteredState(IGS);

    }
}
