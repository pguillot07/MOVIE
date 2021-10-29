using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPanelController : MonoBehaviour
{
    #region User interaction
    public GameObject itemPanel;
    public MyButton translationXPositive;
    public Button translationXNegative;
    public Button translationYPositive;
    public Button translationYNegative;
    public Button translationZPositive;
    public Button translationZNegative;
    public Button rotationXPositive;
    public Button rotationXNegative;
    public Button rotationYPositive;
    public Button rotationYNegative;
    public Button rotationZPositive;
    public Button rotationZNegative;
    #endregion

    #region Private informations
    private GameObject m_SelectedItem;
    private bool m_ItemPanelShown;
    #endregion

    #region Unity Functions
    void Start()
    {
        //Add listeners on buttons for rotations
        if (rotationXPositive != null) rotationXPositive.onClick.AddListener(OnClickRotationXPositive);
        if (rotationXNegative != null) rotationXNegative.onClick.AddListener(OnClickRotationXNegative);
        if (rotationYPositive != null) rotationYPositive.onClick.AddListener(OnClickRotationYPositive);
        if (rotationYNegative != null) rotationYNegative.onClick.AddListener(OnClickRotationYNegative);
        if (rotationZPositive != null) rotationZPositive.onClick.AddListener(OnClickRotationZPositive);
        if (rotationZNegative != null) rotationZNegative.onClick.AddListener(OnClickRotationZNegative);

        //Add listeners on buttons for translations
        //if (translationXPositive != null) translationXPositive.onClick.AddListener(OnClickTranslationXPositive);
        if (translationXNegative != null) translationXNegative.onClick.AddListener(OnClickTranslationXNegative);
        if (translationYPositive != null) translationYPositive.onClick.AddListener(OnClickTranslationYPositive);
        if (translationYNegative != null) translationYNegative.onClick.AddListener(OnClickTranslationYNegative);
        if (translationZPositive != null) translationZPositive.onClick.AddListener(OnClickTranslationZPositive);
        if (translationZNegative != null) translationZNegative.onClick.AddListener(OnClickTranslationZNegative);
    }

    void Update()
    { 
        //Update the selected item saved in the DataHolder and obtained in SelectionManager
        if (DataHolder.dataHolder.GetSelectedItem() != null)
        {
            m_SelectedItem = DataHolder.dataHolder.GetSelectedItem();
            itemPanel.GetComponentInChildren<Text>().text = m_SelectedItem.name;

            //if the panel is open and F is down, close the panel
            if (Input.GetKeyDown(KeyCode.F))
            {
                m_ItemPanelShown = !m_ItemPanelShown;
                itemPanel.SetActive(m_ItemPanelShown);

                //MAJ du dataHolder
                DataHolder.dataHolder.SetItemPanelIsOpen(m_ItemPanelShown);
            }
        }

        //if (translationXPositive.GetButtonIsPressed()) MakeTranslationXPositive();
    }
    #endregion

    #region Overriding Button functions


    #endregion

    #region UserInterface
    void OnClickTranslationXPositive()
    {
        MakeTranslationXPositive();
    }
    void OnClickTranslationXNegative()
    {
        MakeTranslationXNegative();
    }

    void MakeTranslationXPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(0.1f, 0, 0);
    }

    void MakeTranslationXNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(-0.1f, 0, 0);
    }

    void OnClickTranslationYPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(0, 0.1f, 0);
    }
    void OnClickTranslationYNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(0, -0.1f, 0);
    }
    void OnClickTranslationZPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(0, 0, 0.1f);
    }
    void OnClickTranslationZNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Translate(0, 0, -0.1f);
    }

    void OnClickRotationXPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(5, 0, 0);
    }
    void OnClickRotationXNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(-5, 0, 0);
    }
    void OnClickRotationYPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(0, 5, 0);
    }
    void OnClickRotationYNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(0, -5, 0);
    }
    void OnClickRotationZPositive()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(0, 0, 5);
    }
    void OnClickRotationZNegative()
    {
        if (m_SelectedItem != null) m_SelectedItem.transform.Rotate(0, 0, -5);
    }
    #endregion
    
}

