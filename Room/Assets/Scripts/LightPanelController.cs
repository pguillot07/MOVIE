using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPanelController : MonoBehaviour
{
    #region User interaction
    public GameObject lightPanel;
    public Slider sliderRange;
    public Slider sliderAngle;
    public Slider sliderIntensity;
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    #endregion

    #region Private informations
    private Light m_SelectedLight;
    private bool m_LightPanelShown;
    #endregion

    #region Unity Functions
    void Start()
    {
        if (sliderRange != null) sliderRange.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        if (sliderAngle != null) sliderAngle.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        if (sliderIntensity != null) sliderIntensity.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        if (sliderRed != null) sliderRed.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        if (sliderGreen != null) sliderGreen.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        if (sliderBlue != null) sliderBlue.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
    }

    void Update()
    {
        //Update the selected light saved in the DataHolder and obtained in SelectionManager
        if (DataHolder.dataHolder.GetSelectedLight() != null)
        {
            m_SelectedLight = DataHolder.dataHolder.GetSelectedLight();

            //if the panel is open and L is down, close the panel
            if (Input.GetKeyDown(KeyCode.L))
            {
                lightPanel.GetComponentInChildren<Text>().text = m_SelectedLight.name;
                m_LightPanelShown = !m_LightPanelShown;
                lightPanel.SetActive(m_LightPanelShown);
            }
        }
        else {
            m_LightPanelShown = false;
            lightPanel.SetActive(m_LightPanelShown);
        }

        //MAJ du dataHolder
        DataHolder.dataHolder.SetLightPanelIsOpen(m_LightPanelShown);
    }
    #endregion

    #region UserInterface
    void OnSliderValueChange()
    {
        m_SelectedLight.range = sliderRange.value;
        m_SelectedLight.spotAngle = sliderAngle.value;
        m_SelectedLight.intensity = sliderIntensity.value;
        m_SelectedLight.color = new Color(sliderRed.value, sliderGreen.value, sliderBlue.value);
    }
    #endregion
}
