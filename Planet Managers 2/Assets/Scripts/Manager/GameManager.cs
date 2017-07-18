using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StateManager STM;

    public Orbital m_activePlanet;

    public Text m_totalRunTimeText;
    private float m_totalRunTime;

    #region UI

    public Text m_mineralText;
    public Text m_energyText;
    public Text m_FoodText;

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

    public Text m_planetSpaceText;
    public Text m_planetHealthText;
    public Text m_planetHappynessText;

    public Text[] m_specialResouces;
    #endregion

    #region Buildings

    public Text[] m_mines;
    public Text[] m_power;
    public Text[] m_farm;

    #endregion

    #endregion

    public static GameManager GM;

    void Start ()
    {
        if (GM == null)
        {
            GM = this;
        }

        STM = new StateManager();

        STM.RegisterState(Factory.Instance.CreatNewState(eGameStates.MENU));
        STM.RegisterState(Factory.Instance.CreatNewState(eGameStates.INGAME));

        STM.PushState(1);
	}
	
	void Update ()
    {
        if (STM.ActiveStateCount() > 0)
        { 

            STM.Update(Time.deltaTime);

            m_mineralText.text = "Minerals = " + Income.Instance.m_minerals;
            m_energyText.text = "Energy = " + Income.Instance.m_energy;
            m_FoodText.text = "Food = " + Income.Instance.m_food;

            m_NullStoneText.text = "NullStone = " + Income.Instance.GetSpecialResouce(SpecialResources.eResouceType.NULL);
            m_HappyStoneText.text = "HappyStone = " + Income.Instance.GetSpecialResouce(SpecialResources.eResouceType.HAPPYSTONE);
            m_HealthStoneText.text = "HealthStone = " + Income.Instance.GetSpecialResouce(SpecialResources.eResouceType.HEALTHSTONE);
            m_TerraformingStoneText.text = "TerraformingStone = " + Income.Instance.GetSpecialResouce(SpecialResources.eResouceType.TERRAFORMINGSTONE);

            m_totalRunTime += Time.deltaTime;

            UpdateBuildingsText();
        }

        m_totalRunTimeText.text = "Game Run time: " + m_totalRunTime;
    }

    private void UpdateBuildingsText()
    {
        m_mines[0].text = "Basic Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICMINE].Count);
        m_mines[1].text = "Decent Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.DECENTMINE].Count);
        m_mines[2].text = "Advanced Mine: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.ADVANCEDMINE].Count);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        m_power[0].text = "Basic Power: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICPOWER].Count);
        m_farm[0].text = "Basic Farm: " + (m_activePlanet.m_buildings.m_buildings[eBuildingTypes.BASICFARM].Count);
    }

    public void PushState()
    {
        STM.PushState(1);
    }

    public void PopState()
    {
        STM.PopState();
    }
}
