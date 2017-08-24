using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavioursMenu : MonoBehaviour {

    MenuState MS;

    public GameObject m_menu;
    public GameObject m_startNewGame;
    public GameObject m_loadGame;

    public Text m_gameName;
    public Text m_notValidName;

    public float m_InvalidTimer;

	// Use this for initialization
	void Start ()
    {
        m_menu.SetActive(true);
        m_startNewGame.SetActive(false);
        m_loadGame.SetActive(false);
        m_InvalidTimer = 6;
    }

    public void Update()
    {
        m_InvalidTimer += Time.deltaTime;

        if (m_InvalidTimer <= 5)
        {
            m_notValidName.gameObject.SetActive(true);
        }
        else
        {
            m_notValidName.gameObject.SetActive(false);
        }
    }

    public void SetMenuState(MenuState ms)
    {
        MS = ms;
    }


    public void StartNewGame()
    {
        m_menu.SetActive(false);
        m_startNewGame.SetActive(true);
        m_loadGame.SetActive(false);
    }

    public void LoadGame()
    {
        m_menu.SetActive(false);
        m_startNewGame.SetActive(false);
        m_loadGame.SetActive(true);
    }

    public void EnterGameName()
    {
        string newName = m_gameName.text;

        foreach (string name in MS.m_saveNames)
        {
            if (name == newName)
            {
                m_InvalidTimer = 0;
                return;
            }
        }

        if (newName.Length <= 0)
        {
            m_InvalidTimer = 0;
            return;
        }

        InGameState IGS = new InGameState();
        IGS.Init(newName);

        GameManager.GM.RegisterInGameState(IGS);

        GameManager.GM.PushState();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
