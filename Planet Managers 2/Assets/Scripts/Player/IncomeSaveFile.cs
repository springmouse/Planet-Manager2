using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;

[Serializable]
public class IncomeSaveFile
{

    [Serializable]
    public class IncomeDicToList
    {
        public eResouceType key;

        public float value;

        public IncomeDicToList()
        {
        }

        public IncomeDicToList(eResouceType k, float v)
        {
            key = k;
            value = v;
        }
    }

    [XmlArray(("All_Special_Resouces")), XmlArrayItem(typeof(IncomeDicToList), ElementName = "Special_Resouces")]
    public List<IncomeDicToList> m_specialResoucesGathered = new List<IncomeDicToList>();

    public float m_minerals;
    public float m_energy;
    public float m_food;
    public float m_reaserch;

    public IncomeSaveFile()
    {
        m_specialResoucesGathered = new List<IncomeDicToList>();

        m_minerals = 0;
        m_energy = 0;
        m_food = 0;
        m_reaserch = 0;
    }

    public void IncomeSerizalization()
    {
        m_specialResoucesGathered.Clear();
        m_specialResoucesGathered.Add(new IncomeDicToList(eResouceType.NULL, Income.Instance.m_specialResouces[eResouceType.NULL]));
        m_specialResoucesGathered.Add(new IncomeDicToList(eResouceType.HEALTHSTONE, Income.Instance.m_specialResouces[eResouceType.HEALTHSTONE]));
        m_specialResoucesGathered.Add(new IncomeDicToList(eResouceType.HAPPYSTONE, Income.Instance.m_specialResouces[eResouceType.HAPPYSTONE]));
        m_specialResoucesGathered.Add(new IncomeDicToList(eResouceType.TERRAFORMINGSTONE, Income.Instance.m_specialResouces[eResouceType.TERRAFORMINGSTONE]));

        m_minerals = Income.Instance.m_minerals;
        m_energy = Income.Instance.m_energy;
        m_food = Income.Instance.m_food;
        m_reaserch = Income.Instance.m_reaserch;
    }

    public void IncomeDeserialization()
    {
        Income.Instance.m_specialResouces.Clear();

        foreach (IncomeDicToList item in m_specialResoucesGathered)
        {
            Income.Instance.m_specialResouces.Add(item.key, item.value);
        }

        m_specialResoucesGathered.Clear();

        Income.Instance.m_minerals = m_minerals;
        Income.Instance.m_energy = m_energy;
        Income.Instance.m_food = m_food;
        Income.Instance.m_reaserch = m_reaserch;
    }

}
