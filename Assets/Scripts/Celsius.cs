using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celsius : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Temp", 0);
    }
}
