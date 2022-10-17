using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunsen : MonoBehaviour
{
    public Transform regulator;
    public ParticleSystem fire;
    private bool isOn;
    private bool canUse;
    void Start()
    {
        isOn = false;
        canUse = true;
    }

    private void OnMouseDown()
    {
        if(canUse)
        {
            StartCoroutine("RotateRegulator");
        }
    }

    IEnumerator RotateRegulator()
    {
        canUse = false;
        if (!isOn)
        {
            isOn = true;
            fire.Play();
            regulator.Rotate(new Vector3(0, -90, 0));
        }
        else
        {
            isOn = false;
            fire.Stop();
            regulator.Rotate(new Vector3(0, 90, 0));
        }

        yield return new WaitForSeconds(3);
        canUse = true;
    }

}
