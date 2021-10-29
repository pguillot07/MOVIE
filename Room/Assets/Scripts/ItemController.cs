using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    #region Private Properties
    private float m_ZPosition;
    private Vector3 m_Offset;
    private bool m_Dragging;
    #endregion

    #region Inspector Variables
    public Camera MainCamera;
    [SerializeField] private UnityEvent m_OnBeginDrag;
    [SerializeField] private UnityEvent m_OnEndDrag;
    #endregion

    #region Unity Functions
    private void Start()
    {
        DataHolder.dataHolder.GetItems().Add(gameObject);
    }

    void Update()
    {
        if (m_Dragging)
        {
            m_ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 position = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, m_ZPosition);

            Vector3 nextPosition = MainCamera.ScreenToWorldPoint(position +
                new Vector3(m_Offset.x, m_Offset.y));
            Vector3 delta = nextPosition - MainCamera.transform.position;
            if (delta.magnitude < 10f) transform.position = nextPosition;
            else transform.position = MainCamera.transform.position+delta.normalized * 10f;
        }
    }

    private void OnMouseDown()
    {
        if (!m_Dragging)
        {
            BeginDrag();
        }
    }

    private void OnMouseUp()
    {
        if (m_Dragging)
        {
            EndDrag();
        }
    }
    #endregion

    #region UserInterface
    void BeginDrag()
    {
        m_OnBeginDrag.Invoke();
        m_Dragging = true;
        m_Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    void EndDrag()
    {
        m_OnEndDrag.Invoke();
        m_Dragging = false;
    }
    #endregion
}
