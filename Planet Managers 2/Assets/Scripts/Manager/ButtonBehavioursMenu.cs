using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavioursMenu : MonoBehaviour {

    MenuState MS;

    public GameObject m_menu;
    public GameObject m_startNewGame;
    public GameObject m_loadGame;

    public Button m_loadButtonPrefab;

    List<Button> m_loadGameButtons = new List<Button>();

    public Text m_gameName;
    public Text m_notValidName;

    public float m_InvalidTimer;

   
	void Start ()
    {
        Menu();
        m_InvalidTimer = 6;
    }

    public void LoadGameButtonFunction()
    {
        Debug.Log(gameObject.name);
    }

    public void Update()
    {
        m_InvalidTimer += Time.deltaTime;

        LoadGameButtons();

        foreach (Button btn in m_loadGameButtons)
        {
            if (btn.gameObject.transform.localPosition.y > 230 || btn.gameObject.transform.localPosition.y < -230)
            {
                btn.gameObject.SetActive(false);
            }
            else
            {
                btn.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Menu();
        }

        if (m_InvalidTimer <= 5)
        {
            m_notValidName.gameObject.SetActive(true);
        }
        else
        {
            m_notValidName.gameObject.SetActive(false);
        }
    }

    void LoadGameButtons()
    {
        if (MS != null)
        {
            if (MS.m_nameListCreated == false)
            {
                int count = 50;
                Vector2 holder = new Vector3(-10, 230, 0);

                foreach (Button btn in m_loadGameButtons)
                {
                    Destroy(btn.gameObject);
                }

                m_loadGameButtons.Clear();

                foreach (string _name in MS.m_saveNames)
                {
                    Button btn = Button.Instantiate(m_loadButtonPrefab, holder, Quaternion.identity, m_loadGame.transform);

                    btn.gameObject.transform.localPosition = holder;

                    btn.onClick.AddListener(() =>
                    {
                        GameManager.GM.RegisterInGameState(InGameState.Deserialize(_name));
                        GameManager.GM.PushState();
                    });

                    btn.name = _name;

                    Text textholder = btn.GetComponentInChildren<Text>();

                    textholder.text = _name;

                    m_loadGameButtons.Add(btn);

                    holder.y -= count;
                }

                MS.m_nameListCreated = true;
            }

        }
    }

    public void SetMenuState(MenuState ms)
    {
        MS = ms;
    }

    public void Menu()
    {
        m_menu.SetActive(true);
        m_startNewGame.SetActive(false);
        m_loadGame.SetActive(false);
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

        Income.Instance.Init();

        GameManager.GM.m_usedID.Clear();

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
