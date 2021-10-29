using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float motionSpeed = 5f; //Vitesse de déplacement par seconde

    private CharacterController m_CharacterController;
    private float m_RotationSensitivity; //Vitesse de rotation
    private float m_RotationX; //Rotation autour de l'axe X (vertical)
    private float m_RotationY; //Rotation autour de l'axe Y (horizontal)
    private float m_RotationXMax = 70; //Angle maximal de rotation verticale en degré
    private Vector3 m_Motion; //Vecteur de déplacement
    private Camera m_Camera; //Main Camera
    private Vector2 m_LastMousePosition;


    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = this.gameObject.GetComponent<CharacterController>();
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Translations 
        m_Motion = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        m_Motion = Vector3.ClampMagnitude(m_Motion, 1f) * motionSpeed * Time.deltaTime;
        m_Motion = transform.rotation * m_Motion;
        m_CharacterController.Move(m_Motion);

        //Adaptation de la vitesse de rotation
        if (DataHolder.dataHolder.GetAPanelIsOpen()) m_RotationSensitivity = 0f; //Lorsqu'un panneau de commande est ouvert, on bloque la rotation de la caméra
        else
        {
            if (!IsMouseOutScreen()) m_RotationSensitivity = 3f;
            else
            {
                if (IsMouseGoingToCenter()) m_RotationSensitivity = 0f;
                else m_RotationSensitivity = 5f;
            }
        }
        

        //Rotation verticale -appliquée juste à la caméra pour ne pas dépasser le player
        m_RotationX -= Input.GetAxis("Mouse Y") * m_RotationSensitivity;
        m_RotationX = Mathf.Clamp(m_RotationX, -m_RotationXMax, m_RotationXMax);
        m_Camera.transform.localRotation = Quaternion.Euler(m_RotationX, 0, 0);

        //Rotation horizontale
        m_RotationY = Input.GetAxis("Mouse X") * m_RotationSensitivity;
        transform.Rotate(0, m_RotationY, 0);
        m_LastMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private bool IsMouseOutScreen()
    {
        if (Input.mousePosition.x <= 2 || Input.mousePosition.y <= 2 || Input.mousePosition.x >= Screen.width || Input.mousePosition.y >= Screen.height)
        {
            return true;
        }

        return false;
    }

    private bool IsMouseGoingToCenter()
    {
        Vector2 directionToNewPosition = new Vector2(Input.mousePosition.x - m_LastMousePosition.x, Input.mousePosition.y - m_LastMousePosition.y);
        Vector2 directionToCenter = new Vector2(Screen.width / 2 - m_LastMousePosition.x, Screen.height / 2 - m_LastMousePosition.y);
        if (Vector2.Dot(directionToNewPosition, directionToCenter) >= 0) return true;
        else return false;
    }
}
