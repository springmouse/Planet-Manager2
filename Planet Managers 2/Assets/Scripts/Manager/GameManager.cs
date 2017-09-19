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

                m_NullStoneText.text = "NullStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.NULL);
                m_HappyStoneText.text = "HappyStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.HAPPYSTONE);
                m_HealthStoneText.text = "HealthStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.HEALTHSTONE);
                m_TerraformingStoneText.text = "TerraformingStone = " + (int)Income.Instance.GetSpecialResouce(eResouceType.TERRAFORMINGSTONE);

                m_reaserchTimer.text = "Reaserch in: " + (int)m_activePlanet.GetReaserchTimerRemaining();
                m_incomeTimer.text = "Income in: " + (int)m_activePlanet.GetResourceTimerRemaining();

                m_totalRunTime += Time.deltaTime;

                UpdateBuildingsText();
            }
        }

        m_totalRunTimeText.text = "Game Run time: " + m_totalRunTime;
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
