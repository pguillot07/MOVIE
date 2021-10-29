using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelController : MonoBehaviour
{
    #region User Interactions
    public GameObject menuPanel;
    public Button btVirginScene;
    public Button btNewScene;
    public Dropdown ddNewScene;
    public Button btNewSceneLauncher;
    public Button btLoadScene;
    public Dropdown ddLoadScene;
    public Button btLoadSceneLauncher;
    public GameObject grpNewScene;
    public GameObject grpLoadScene;
    #endregion

    #region Private elements
    private bool m_MenuPanelIsShown = true;
    #endregion

    #region Unity Functions
    void Start()
    {
        if (btVirginScene != null) btVirginScene.onClick.AddListener(OnVirginSceneClickListener);
        if (btNewScene != null) btNewScene.onClick.AddListener(OnNewSceneClickListener);
        if (btLoadScene != null) btLoadScene.onClick.AddListener(OnLoadSceneClickListener);
        if (btNewSceneLauncher != null) btNewSceneLauncher.onClick.AddListener(OnNewSceneLauncherClickListener);
        if (btLoadSceneLauncher != null) btLoadSceneLauncher.onClick.AddListener(OnLoadSceneLauncherClickListener);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_MenuPanelIsShown = !m_MenuPanelIsShown;
            menuPanel.SetActive(m_MenuPanelIsShown);
            DataHolder.dataHolder.SetMenuPanelIsOpen(m_MenuPanelIsShown);
        }
    }

    #endregion

    #region User Functions
    private void HideAll()
    {
        grpNewScene.SetActive(false);
        grpLoadScene.SetActive(false);
        menuPanel.SetActive(false);
        m_MenuPanelIsShown = false;
        DataHolder.dataHolder.SetMenuPanelIsOpen(false);
    }

    private void OnVirginSceneClickListener()
    {
        HideAll();
    }

    private void OnNewSceneClickListener()
    {
        grpNewScene.SetActive(true);
    }

    private void OnNewSceneLauncherClickListener()
    {
        HideAll();
    }

    private void OnLoadSceneClickListener()
    {
        grpLoadScene.SetActive(true);
    }

    private void OnLoadSceneLauncherClickListener()
    {
        HideAll();
    }

    #endregion
}
