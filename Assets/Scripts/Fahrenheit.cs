using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fahrenheit : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Temp", 1);
    }
}
