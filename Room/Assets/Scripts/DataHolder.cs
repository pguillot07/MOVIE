using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public static DataHolder dataHolder; // Instance de classe qui permet de sauvegarder des objets globaux
    public Camera playerCamera;
    public Text currentScene;

    #region Private Properties
    private GameObject m_SelectedItem;
    private Light m_SelectedLight;
    private bool m_MouseOnTarget;
    private bool m_APanelIsOpen;
    private bool m_LightPanelIsOpen;
    private bool m_ItemPanelIsOpen;
    private bool m_MenuPanelIsOpen;
    private List<GameObject> m_Items;
    private Dictionary<string, List<GameObject>> m_ItemsDictionary; // Le nom de la scène, et la liste des GameObject associés
    private int m_ScenesCount; // Nombre total de scènes
    private string m_CurrentScene; //Nom de la scene actuellement ouverte
    #endregion

    #region Constructor
    private DataHolder()
    {
        this.m_APanelIsOpen = false;
        this.m_LightPanelIsOpen = false;
        this.m_ItemPanelIsOpen = false;
        this.m_MenuPanelIsOpen = true;
        this.m_MouseOnTarget = false;
        this.m_SelectedLight = null;
        this.m_SelectedItem = null;
        this.m_Items = new List<GameObject>();
    }
    #endregion

    #region Unity Functions
    private void Awake()
    {
        dataHolder = new DataHolder();
    }

    private void Update()
    {
        if (dataHolder.m_ItemPanelIsOpen || dataHolder.m_LightPanelIsOpen || dataHolder.m_MenuPanelIsOpen) dataHolder.m_APanelIsOpen = true;
        else dataHolder.m_APanelIsOpen = false;
    }
    #endregion

    #region Communication Functions between Scripts
    public GameObject GetSelectedItem()
    {
        return m_SelectedItem;
    }

    public void SetSelectedItem(GameObject go)
    {
        this.m_SelectedItem = go;
    }

    public Light GetSelectedLight()
    {
        return m_SelectedLight;
    }

    public void SetSelectedLight(Light light)
    {
        this.m_SelectedLight = light;
    }

    public bool GetMouseOnTarget()
    {
        return m_MouseOnTarget;
    }

    public void SetMouseOnTarget(bool b)
    {
        this.m_MouseOnTarget = b;
    }

    public bool GetAPanelIsOpen()
    {
        return m_APanelIsOpen;
    }

    public void SetLightPanelIsOpen(bool b)
    {
        this.m_LightPanelIsOpen = b;
    }

    public void SetItemPanelIsOpen(bool b)
    {
        this.m_ItemPanelIsOpen = b;
    }

    public void SetMenuPanelIsOpen(bool b)
    {
        this.m_MenuPanelIsOpen = b;
    }

    public List<GameObject> GetItems()
    {
        return this.m_Items;
    }

    public Dictionary<string, List<GameObject>> GetItemsDictionary()
    {
        return m_ItemsDictionary;
    }

    public int GetScenesCount()
    {
        return m_ScenesCount;
    }

    public string GetCurrentScene()
    {
        return m_CurrentScene;
    }
    #endregion
}
