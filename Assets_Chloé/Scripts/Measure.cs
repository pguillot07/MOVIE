using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Measure : MonoBehaviour
{
    public GameObject measureCanvas;
    public GameObject button;

    public GameObject pointeurA;
    public GameObject pointeurB;
    private bool placedA = false;
    private bool placedB = false;

    public GameObject add1;
    public GameObject add2;
    public GameObject deplacer;
    public Text distanceText;


    Vector3 worldPosition;

    private bool measureEnabled;


    void Update()
    {
        //Affichage de l'outil de mesure avec la touche M
        if (Input.GetKeyDown(KeyCode.M)){
            measureEnabled = !measureEnabled;
            if (measureEnabled == true)
            {   
                measureCanvas.SetActive(true);
            }
            else {
                measureCanvas.SetActive(false);
            }
        }

        if (measureEnabled == true){
            if (Input.GetMouseButtonDown(0)){
                bool worked;
                worked = PlacePointerA();
                if (!worked){
                    PlacePointerB();
                }
            }
            if (placedA && placedB){
                Vector3 pointA = pointeurA.transform.position;
                Vector3 pointB = pointeurB.transform.position;
                double dist = Math.Round(Vector3.Distance(pointA, pointB),2);
                distanceText.text = dist.ToString() + " m";
            }
        }
    }

    public bool PlacePointerA(){
        bool worked = false;
        if (!placedA){
            Debug.Log("boutonA");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if(Physics.Raycast(ray, out hitData, 1000))
                {
                    worldPosition = hitData.point;
                    pointeurA.transform.position = worldPosition;
                    pointeurA.SetActive(true); 
                    placedA = true;
                    worked = true;
                    add1.SetActive(false);
                    add2.SetActive(true);
            }
        }
        return worked;
    }

    public void PlacePointerB(){
        if (!placedB && placedA){
            Debug.Log("boutonB");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if(Physics.Raycast(ray, out hitData, 1000))
                {
                    worldPosition = hitData.point;
                    pointeurB.transform.position = worldPosition;
                    pointeurB.SetActive(true); 
                    placedB = true;
                    add2.SetActive(false);
                    deplacer.SetActive(true);
            }
        }
    }   
        



    public void Reinitialise(){
        pointeurA.SetActive(false);
        pointeurB.SetActive(false);
        placedA = false;
        placedB = false;
        distanceText.text = null;
        deplacer.SetActive(false);
        add2.SetActive(false);
        add1.SetActive(true);

    }
   

}
