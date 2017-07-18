﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialResources
{
    public enum eResouceType
    {
        NULL,
        HEALTHSTONE,
        TERRAFORMINGSTONE,
        HAPPYSTONE,
        END
    }

    public virtual void Update(float deltaTime)
    {
        m_timeSpentGathering += deltaTime;

        if (m_timeSpentGathering >= m_gatherTime)
        {
            Income.Instance.AddSpecialResouce(m_type, m_amountGathered);
            m_timeSpentGathering = 0;
        }
    }

    public eResouceType GetRosuceType()
    {
        return m_type;
    }

    public string m_name;

    protected eResouceType m_type = eResouceType.NULL;
    protected float m_gatherTime = 0;
    protected float m_timeSpentGathering = 0;
    protected float m_amountGathered = 0;
}

public class NullStone : SpecialResources
{
    public NullStone()
    {
        m_name = "NullStone";
        m_type = eResouceType.NULL;
        m_gatherTime = 300;
        m_amountGathered = 1;
    }
}

public class HealthStone : SpecialResources
{
    public HealthStone()
    {
        m_name = "HealthStone";
        m_type = eResouceType.HEALTHSTONE;
        m_gatherTime = 60;
        m_amountGathered = 1;
    }
}

public class TerraFormingStone : SpecialResources
{
    public TerraFormingStone()
    {
        m_name = "TerraFormingStone";
        m_type = eResouceType.TERRAFORMINGSTONE;
        m_gatherTime = 90;
        m_amountGathered = 1;
    }
}

public class HappyStone : SpecialResources
{
    public HappyStone()
    {
        m_name = "HappyStone";
        m_type = eResouceType.HAPPYSTONE;
        m_gatherTime = 45;
        m_amountGathered = 1;
    }
}