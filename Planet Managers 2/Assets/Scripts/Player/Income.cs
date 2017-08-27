using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Income
{
    public Dictionary<eResouceType, float> m_specialResouces = new Dictionary<eResouceType, float>();

    public float m_minerals;
    public float m_energy;
    public float m_food;
    public float m_reaserch;

    #region Sintleton

    private Income()
    {
        Init();
    }

    public void Init()
    {
        m_specialResouces.Clear();

        m_specialResouces.Add(eResouceType.NULL, 0.0f);
        m_specialResouces.Add(eResouceType.HEALTHSTONE, 0.0f);
        m_specialResouces.Add(eResouceType.TERRAFORMINGSTONE, 0.0f);
        m_specialResouces.Add(eResouceType.HAPPYSTONE, 0.0f);

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
    
    public void AddSpecialResouce(eResouceType key, float amount)
    {
        if (key >= eResouceType.END)
        {
            Debug.LogError("INVALIDE SPECIAL RESOUCE");
            return;
        }

        m_specialResouces[key] += amount;
        Debug.Log(key + " " + m_specialResouces[key]);
    }

    public float GetSpecialResouce(eResouceType type)
    {
        return m_specialResouces[type];
    }

    public void AddReaserchIncome(float r)
    {
        m_reaserch += r;
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
