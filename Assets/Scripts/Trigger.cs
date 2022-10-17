using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject display;
    private bool hasAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        hasAction = true;
        display.SetActive(true);
    }

    private void OnMouseUp()
    {
        hasAction = false;
        StartCoroutine("DisplayOff");
    }

    IEnumerator DisplayOff()
    {
        if (!hasAction)
        {
            yield return new WaitForSeconds(15f);
            display.SetActive(false);
        }
    }
}
