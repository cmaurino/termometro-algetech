using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    public Transform selectedPosition;
    private bool isSelected;
    private bool isMoving;
    private Vector3 initialPoint;
    void Start()
    {
        initialPoint = transform.position;
        isSelected = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!isMoving)
        {
            if (!isSelected)
            {
                StartCoroutine(MoveThermometer(initialPoint, selectedPosition.position));
                isSelected = true;
            }
            else
            {
                StartCoroutine(MoveThermometer(selectedPosition.position, initialPoint));
                isSelected = false;
            }
        }
    }

    IEnumerator MoveThermometer(Vector3 aPoint, Vector3 bPoint)
    {
        isMoving = true;
        Vector3 rotateVector;
        float rate = 1.5f / Vector3.Distance(aPoint, bPoint) * 3;
        float t = 0.0f;
        print(aPoint + bPoint);

        if (!isSelected)
        {
            rotateVector = new Vector3(-96f, 0, 0);
        }
        else
        {
            rotateVector = new Vector3(96f, 0, 0);
        }

        while (t < 2.0f)
        {
            t += Time.deltaTime * rate;
            transform.Rotate(rotateVector * Time.deltaTime);
            transform.position = Vector3.MoveTowards(aPoint, bPoint, t);
            yield return null;
        }
        isMoving = false;
    }
}
