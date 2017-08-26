using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private List<States> m_pushedStates = new List<States>(); /*the states to be pushed onto m_stateStack*/

    private List<States> m_stateStack = new List<States> (); /*holds all states currently in use*/
    private List<States> m_registeredStates = new List<States> (); /*holds all states that can be used*/

    private bool m_pop;

    public void RegisterState(States state) { m_registeredStates.Add(state); }

    public void PushState(int id)
    {
        m_pushedStates.Add(m_registeredStates[id]);
    }

    public void RemoveRegisteredState(States S)
    {
        bool check = false;
        foreach (States item in m_registeredStates)
        {
            if (S == item)
            {
                check = true;
            }
        }

        if (check == true)
        {
            m_registeredStates.Remove(S);
            Debug.Log("removed state");
        }
    }

    public void PopState() { m_pop = true; }
    
    public int ActiveStateCount() { return (m_stateStack.Count + m_pushedStates.Count); }
    
    States GetState(int id) { return m_registeredStates[id]; }

    public void Update (float deltaTime)
    {
        //checks if we need to pop a state off
        while (m_pop)
        {
            m_pop = false;

            //runs the closing functions of the GameState
            m_stateStack[m_stateStack.Count - 1].exit();
            States temp = m_stateStack[m_stateStack.Count - 1];
            m_stateStack.Remove(temp);

            temp.onPopped();

            //runs the enter functions for the last elemeant in the list
            if (m_stateStack.Count > 0)
            {
                m_stateStack[m_stateStack.Count - 1].enter();
            }
        }

        //loops throught the sataes being held in m_pushedStates
        foreach (States state in m_pushedStates)
        {
            //runs the exit function on the last elemeant in m_stateStack
            if (m_stateStack.Count > 0)
            {
                m_stateStack[m_stateStack.Count - 1].exit();
            }

            //runs the opening functions for the state just added
            state.onPushed();
            m_stateStack.Add(state);
            m_stateStack[m_stateStack.Count - 1].enter();

        }

        //clears pushed states
        m_pushedStates.Clear();


        //goes through all the states in the list and runs there update functions
        foreach (States state in m_stateStack)
        {
            state.Update(deltaTime);
        }
    }

}
