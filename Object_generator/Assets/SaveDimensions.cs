using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDimensions : MonoBehaviour
{

    public InputField inputWidth;
    public InputField inputLength;
    public InputField inputHeight;
    private string WidthText;
    private string LengthText;
    private string HeightText;

    private void Start()
    {
        WidthText = PlayerPrefs.GetString("WidthFile");
        inputWidth.text = WidthText;
        LengthText = PlayerPrefs.GetString("LengthFile");
        inputLength.text = LengthText;
        HeightText = PlayerPrefs.GetString("HeightFile");
        inputHeight.text = HeightText;
    }

    public void SaveInfo()
    {
        WidthText = inputWidth.text;
        PlayerPrefs.SetString("WidthFile", WidthText);
        LengthText = inputLength.text;
        PlayerPrefs.SetString("LengthFile", LengthText);
        HeightText = inputHeight.text;
        PlayerPrefs.SetString("HeightFile", HeightText);
    }
}
