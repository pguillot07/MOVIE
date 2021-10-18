using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;


public class InstantiateManager : MonoBehaviour
{

    public Camera MainCamera;
    private float SafetyDistance = 10;

    public void Create()
    {
        //Créé une forme primitive (un cube) 
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //Importe les valeurs de Width, Length et Height
        float WidthValue = float.Parse(PlayerPrefs.GetString("WidthFile"), CultureInfo.InvariantCulture.NumberFormat);
        float LengthValue = float.Parse(PlayerPrefs.GetString("LengthFile"), CultureInfo.InvariantCulture.NumberFormat);
        float HeightValue = float.Parse(PlayerPrefs.GetString("HeightFile"), CultureInfo.InvariantCulture.NumberFormat);

        //Déplace la forme au point le plus adapté
        cube.transform.position = MainCamera.transform.position 
            + FindBestPosition() 
            + new Vector3(0, HeightValue/2 - transform.localScale.y, 0);

        //Transforme le cube selon les dimensions choisies
        Vector3 scale = new Vector3(WidthValue, HeightValue, LengthValue);
        cube.transform.localScale = scale;

        //Ajoute l'objet à l'inventaire
        

    }

    Vector3 FindBestPosition()
    {
        //Le vecteur direction indique la direction du regard. Il est normalisé
        Vector3 direction = MainCamera.transform.rotation * new Vector3(0, 0, 1);
        
        float WidthValue = float.Parse(PlayerPrefs.GetString("WidthFile"), CultureInfo.InvariantCulture.NumberFormat);
        float LengthValue = float.Parse(PlayerPrefs.GetString("LengthFile"), CultureInfo.InvariantCulture.NumberFormat);
        float distance = Mathf.Max(WidthValue, LengthValue, SafetyDistance);

        return distance * direction;
    }


}
