using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech : MonoBehaviour
{
    #region PlanetBuildingUI
    public GameObject m_decentMine;
    public GameObject m_advancedMine;
    public bool m_reaserchedDecentMine = false;
    public bool m_reaserchedAdvancedMine = false;

    public GameObject m_decentPower;
    public GameObject m_advancedPower;
    public bool m_reaserchedDecentPower = false;
    public bool m_reaserchedAdvancedPower = false;

    public GameObject m_decentFarm;
    public GameObject m_advancedFarm;
    public bool m_reaserchedDecentFarm = false;
    public bool m_reaserchedAdvancedFarm = false;

    public GameObject m_decentLab;
    public GameObject m_advancedLab;
    public bool m_reaserchedDecentLab = false;
    public bool m_reaserchedAdvancedLab = false;

    public GameObject m_decentPark;
    public GameObject m_AdvancedPark;
    public bool m_reaserchedDecentPark = false;
    public bool m_reaserchedAdvancedPark = false;

    public GameObject m_decentClinic;
    public GameObject m_advancedClinic;
    public bool m_reaserchedDecentClinic = false;
    public bool m_reaserchedAdvancedClinic = false;

    public GameObject m_decentTerraformingStation;
    public GameObject m_advancedTerraformingStation;
    public bool m_reaserchedDecentTerraformingStation = false;
    public bool m_reaserchedAdvancedTerraformingStation = false;

    public GameObject m_decentNullMine;
    public GameObject m_advancedNullMine;
    public bool m_reaserchedDecentNullMine = false;
    public bool m_reaserchedAdvancedNullMine = false;

    public GameObject m_decentHealthStoneMine;
    public GameObject m_advancedHealthStoneMine;
    public bool m_reaserchedDecentHealthMine = false;
    public bool m_reaserchedAdvancedHealthMine = false;

    public GameObject m_decentHappyStoneMine;
    public GameObject m_advancedHappyStoneMine;
    public bool m_reaserchedDecentHappyMine = false;
    public bool m_reaserchedAdvancedHappyMine = false;

    public GameObject m_decentTerraformingStoneMine;
    public GameObject m_advancedTerraformingStoneMine;
    public bool m_reaserchedDecentTerraformingStoneMine = false;
    public bool m_reaserchedAdvancedTerraformingStoneMine = false;
    #endregion

    #region reaserchpanle

    public GameObject m_reaserchDecentMineOBJ;
    public GameObject m_reaserchAdvancedMineOBJ;

    public GameObject m_reaserchedDecentPowerOBJ;
    public GameObject m_reaserchAdvancedPowerOBJ;

    public GameObject m_reaserchDecentFarmOBJ;
    public GameObject m_reaserchAdvancedFarmOBJ;

    public GameObject m_reaserchDecentLabOBJ;
    public GameObject m_reaserchAdvancedLabOBJ;

    public GameObject m_reaserchDecentParkOBJ;
    public GameObject m_reaserchAdvancedParkOBJ;

    public GameObject m_reaserchDecentClinicOBJ;
    public GameObject m_reaserchAdvancedClinicOBJ;

    public GameObject m_reaserchDecentTerraformingStationOBJ;
    public GameObject m_reaserchAdvancedTerraformingStationOBJ;

    public GameObject m_reaserchDecentNullMineOBJ;
    public GameObject m_reaserchAdvancedNullMine;

    public GameObject m_reaserchDecentHealthStoneMineOBJ;
    public GameObject m_reaserchAdvancedHealthStoneMineOBG;

    public GameObject m_reaserchDecentHappyMineOBJ;
    public GameObject m_reaserchAdvancedHappyStoneMineOBJ;

    public GameObject m_reaserchDecentTerraformingStoneMineOBJ;
    public GameObject m_reaserchAdvancedTerraformingStoneMineOBJ;

    #endregion

    private void Start()
    {
        SetUpActive();
    }

    public void SetUpActive()
    {
        //////////////////////////////////////////////
        //////////////////////////////////////////////

        if (m_reaserchedDecentMine == false)
        {
            m_decentMine.SetActive(false);
            m_reaserchDecentMineOBJ.SetActive(true);
        }
        else
        {
            m_decentMine.SetActive(true);
            m_reaserchDecentMineOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedMine == false)
        {
            m_advancedMine.SetActive(false);
            m_reaserchAdvancedMineOBJ.SetActive(true);
        }
        else
        {
            m_advancedMine.SetActive(true);
            m_reaserchAdvancedMineOBJ.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentPower == false)
        {
            m_decentPower.SetActive(false);
            m_reaserchedDecentPowerOBJ.SetActive(true);
        }
        else
        {
            m_decentPower.SetActive(true);
            m_reaserchedDecentPowerOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedPower == false)
        {
            m_advancedPower.SetActive(false);
            m_reaserchAdvancedPowerOBJ.SetActive(true);
        }
        else
        {
            m_advancedPower.SetActive(true);
            m_reaserchAdvancedPowerOBJ.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentFarm == false)
        {
            m_decentFarm.SetActive(false);
            m_reaserchDecentFarmOBJ.SetActive(true);
        }
        else
        {
            m_decentFarm.SetActive(false);
            m_reaserchDecentFarmOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedFarm == false)
        {
            m_advancedFarm.SetActive(false);
            m_reaserchAdvancedFarmOBJ.SetActive(true);
        }
        else
        {
            m_advancedFarm.SetActive(true);
            m_reaserchAdvancedFarmOBJ.SetActive(false);
        }

        //////////////////////////////////////////////
        //////////////////////////////////////////////

        if (m_reaserchedDecentLab == false)
        {
            m_decentLab.SetActive(false);
            m_reaserchDecentLabOBJ.SetActive(true);
        }
        else
        {
            m_decentLab.SetActive(true);
            m_reaserchDecentLabOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedLab == false)
        {
            m_advancedLab.SetActive(false);
            m_reaserchAdvancedLabOBJ.SetActive(true);
        }
        else
        {
            m_advancedLab.SetActive(true);
            m_reaserchAdvancedLabOBJ.SetActive(false);
        }

        //////////////////////////////////////////////
        //////////////////////////////////////////////

        if (m_reaserchedDecentPark == false)
        {
            m_decentPark.SetActive(false);
            m_reaserchDecentParkOBJ.SetActive(true);
        }
        else
        {
            m_decentPark.SetActive(true);
            m_reaserchDecentParkOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedPark == false)
        {
            m_AdvancedPark.SetActive(false);
            m_reaserchAdvancedParkOBJ.SetActive(true);
        }
        else
        {
            m_AdvancedPark.SetActive(true);
            m_reaserchAdvancedParkOBJ.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentClinic == false)
        {
            m_decentClinic.SetActive(false);
            m_reaserchDecentClinicOBJ.SetActive(true);
        }
        else
        {
            m_decentClinic.SetActive(true);
            m_reaserchDecentClinicOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedClinic == false)
        {
            m_advancedClinic.SetActive(false);
            m_reaserchAdvancedClinicOBJ.SetActive(true);
        }
        else
        {
            m_advancedClinic.SetActive(true);
            m_reaserchAdvancedClinicOBJ.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentTerraformingStation == false)
        {
            m_decentTerraformingStation.SetActive(false);
            m_reaserchDecentTerraformingStationOBJ.SetActive(true);
        }
        else
        {
            m_decentTerraformingStation.SetActive(true);
            m_reaserchDecentTerraformingStationOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedTerraformingStation == false)
        {
            m_advancedTerraformingStation.SetActive(false);
            m_reaserchAdvancedTerraformingStationOBJ.SetActive(true);
        }
        else
        {
            m_advancedTerraformingStation.SetActive(true);
            m_reaserchAdvancedTerraformingStationOBJ.SetActive(false);
        }

        //////////////////////////////////////////////
        //////////////////////////////////////////////

        if (m_reaserchedDecentNullMine == false)
        {
            m_decentNullMine.SetActive(false);
            m_reaserchDecentNullMineOBJ.SetActive(true);
        }
        else
        {
            m_decentNullMine.SetActive(true);
            m_reaserchDecentNullMineOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedNullMine == false)
        {
            m_advancedNullMine.SetActive(false);
            m_reaserchAdvancedNullMine.SetActive(true);
        }
        else
        {
            m_advancedNullMine.SetActive(true);
            m_reaserchAdvancedNullMine.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentHealthMine == false)
        {
            m_decentHealthStoneMine.SetActive(false);
            m_reaserchDecentHealthStoneMineOBJ.SetActive(true);
        }
        else
        {
            m_decentHealthStoneMine.SetActive(true);
            m_reaserchDecentHealthStoneMineOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedHealthMine == false)
        {
            m_advancedHealthStoneMine.SetActive(false);
            m_reaserchAdvancedHealthStoneMineOBG.SetActive(true);
        }
        else
        {
            m_advancedHealthStoneMine.SetActive(true);
            m_reaserchAdvancedHealthStoneMineOBG.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentHappyMine == false)
        {
            m_decentHappyStoneMine.SetActive(false);
            m_reaserchDecentHappyMineOBJ.SetActive(true);
        }
        else
        {
            m_decentHappyStoneMine.SetActive(true);
            m_reaserchDecentHappyMineOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedHappyMine == false)
        {
            m_advancedHappyStoneMine.SetActive(false);
            m_reaserchAdvancedHappyStoneMineOBJ.SetActive(true);
        }
        else
        {
            m_advancedHappyStoneMine.SetActive(true);
            m_reaserchAdvancedHappyStoneMineOBJ.SetActive(false);
        }

        //////////////////////////////////////////////

        if (m_reaserchedDecentTerraformingStoneMine == false)
        {
            m_decentTerraformingStoneMine.SetActive(false);
            m_reaserchDecentTerraformingStoneMineOBJ.SetActive(true);
        }
        else
        {
            m_decentTerraformingStoneMine.SetActive(true);
            m_reaserchDecentTerraformingStoneMineOBJ.SetActive(false);
        }

        if (m_reaserchedAdvancedTerraformingStoneMine == false)
        {
            m_advancedTerraformingStoneMine.SetActive(false);
            m_reaserchAdvancedTerraformingStoneMineOBJ.SetActive(true);
        }
        else
        {
            m_advancedTerraformingStoneMine.SetActive(true);
            m_reaserchAdvancedTerraformingStoneMineOBJ.SetActive(false);
        }

    }

    public void ReaserchDecentMine()
    {
        if (Income.Instance.m_reaserch >= 500)
        {
            Income.Instance.m_reaserch -= 500;
            m_reaserchedDecentMine = true;
            SetUpActive();
        }
    }
}
