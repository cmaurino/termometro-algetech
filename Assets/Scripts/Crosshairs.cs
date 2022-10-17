using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshairs : MonoBehaviour
{
    public Transform cameraTransform;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, 5, LayerMask.GetMask("Pressable")))
        {
            ActiveCrosshair("Click");
        }
        else if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, 5, LayerMask.GetMask("Pickable")))
        {
            ActiveCrosshair("Pick");
        }
        else
        {
            ActiveCrosshair("Dot");
        }
    }

    void ActiveCrosshair(string crossHairName)
    {
        GameObject[] crss = GameObject.FindGameObjectsWithTag("Crosshair");

        for (int i = 0; i < crss.Length; i++)
        {
            if (crss[i].name == crossHairName)
                crss[i].GetComponent<Image>().enabled = true;
            else
                crss[i].GetComponent<Image>().enabled = false;
        }
    }
}
