using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Income
{
    Dictionary<SpecialResources.eResouceType, float> m_specialResouces = new Dictionary<SpecialResources.eResouceType, float>();

    public float m_minerals;
    public float m_energy;
    public float m_food;

    #region Sintleton

    private Income()
    {
        m_specialResouces.Add(SpecialResources.eResouceType.NULL, 0.0f);
        m_specialResouces.Add(SpecialResources.eResouceType.HEALTHSTONE, 0.0f);
        m_specialResouces.Add(SpecialResources.eResouceType.TERRAFORMINGSTONE, 0.0f);
        m_specialResouces.Add(SpecialResources.eResouceType.HAPPYSTONE, 0.0f);

        m_minerals = 100;
        m_energy = 100;
        m_food = 100;
    }

    private static Income income;

    public static Income Instance
    {
        get
        {
            if (income == null)
            {
                income = new Income();
            }
            return income;
        }
    }

    #endregion
    
    public void AddSpecialResouce(SpecialResources.eResouceType key, float amount)
    {
        if (key >= SpecialResources.eResouceType.END)
        {
            if (key >= SpecialResources.eResouceType.END)
            {
                Debug.LogError("INVALIDE SPECIAL RESOUCE");
            }
            return;
        }

        m_specialResouces[key] += amount;
        Debug.Log(key + " " + m_specialResouces[key]);
    }

    public float GetSpecialResouce(SpecialResources.eResouceType type)
    {
        return m_specialResouces[type];
    }

    public void AddOrDecreaseMinerals(float amount)
    {
        m_minerals += amount;
    }

    public void AddOrDecreaseEnergy(float amount)
    {
        m_energy += amount;
    }

    public void AddOrDecreaseFood(float amount)
    {
        m_food += amount;
    }

    public void AddResouceIncome(float m, float e, float f)
    {
        m_minerals += m;
        m_energy += e;
        m_food += f;
    }

    public void Update(float deltaTime)
    {

    }
}
