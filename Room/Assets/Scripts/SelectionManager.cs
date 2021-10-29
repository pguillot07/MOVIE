using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material m_SelectedMaterial;

    #region Private Properties
    private Material m_DefaultMaterial;
    private GameObject m_SelectedObject;
    #endregion

    void Update()
    {
        if (m_SelectedObject != null)
        {
            m_SelectedObject.GetComponent<Renderer>().material = m_DefaultMaterial;
            m_SelectedObject = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            DataHolder.dataHolder.SetMouseOnTarget(true);
            GameObject selection = hit.transform.gameObject; //Save the current focused item without changing the current saved
            if (selection.CompareTag("Light") || selection.CompareTag("Item"))
            {
                Renderer selectionRenderer = selection.GetComponent<Renderer>(); //Save the current Renderer
                if (selectionRenderer != null)
                {
                    m_DefaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = m_SelectedMaterial;
                }
                m_SelectedObject = selection;
                if (Input.GetMouseButtonDown(0)) //To selection a specific 
                {
                    DataHolder.dataHolder.SetMouseOnTarget(true);
                    DataHolder.dataHolder.SetSelectedItem(m_SelectedObject);
                    Debug.Log("Selected object : " + m_SelectedObject.name);
                    if (selection.CompareTag("Light")) DataHolder.dataHolder.SetSelectedLight(m_SelectedObject.GetComponentInChildren<Light>());
                    if (selection.CompareTag("Item")) DataHolder.dataHolder.SetSelectedLight(null);
                }
            }
        }
        else
        {
            DataHolder.dataHolder.SetMouseOnTarget(false);
        }
    }  
}
