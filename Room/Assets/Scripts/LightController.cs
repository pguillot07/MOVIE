using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private bool m_RendererState = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            m_RendererState = !m_RendererState;
            this.GetComponent<MeshRenderer>().enabled = m_RendererState;
        }
    }
}
