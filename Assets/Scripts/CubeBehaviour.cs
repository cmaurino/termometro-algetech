using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeBehaviour : MonoBehaviour
{
    public Transform selectedPosition;
    public ParticleSystem fire;
    public Text actualTemp;
    public Text maxTemp;
    public Text celsiusFahreinheit;
    private float maxNumberCelsius;
    private float maxNumberFahreinheit;
    public float temperature;
    private bool isSelected;
    private bool isMoving;
    private Vector3 initialPoint;
    void Start()
    {
        temperature = 25f;
        initialPoint = transform.position;
        isSelected = false;
        isMoving = false;
    }
    private void Update()
    {
        StartCoroutine("RefreshNumbers");
    }

    private void IncreaseTemperature()
    {
        //float initialTemp = temperature;
        //temperature = initialTemp + (200 - initialTemp) * (1 - 2.71f, Mathf.Pow(0.0025f, -1f) * initialTemp));
        if (temperature >= 25 && temperature < 200)
        {
            temperature += 0.1f;
        }

        if (PlayerPrefs.GetInt("Temp") == 1)
        {
            if (float.Parse(actualTemp.text) > maxNumberFahreinheit)
            {
                PlayerPrefs.SetFloat("maxTemp", float.Parse(actualTemp.text));
                maxTemp.text = "MAX " + PlayerPrefs.GetFloat("maxTemp");
            }
        }
        else
        {
            if (float.Parse(actualTemp.text) > maxNumberCelsius)
            {
                maxNumberCelsius = float.Parse(actualTemp.text);
                maxTemp.text = "MAX " + PlayerPrefs.GetFloat("maxTemp");
            }
        }

    }

    private void DecreaseTemperature()
    {
        if (temperature >= 25.1f)
        {
            temperature -= 0.1f;
        }
    }

    private void OnMouseDown()
    {
        if(!isMoving)
        {
            if (!isSelected && !GameObject.FindGameObjectWithTag("Using"))
            {
                StartCoroutine(MoveCube(initialPoint, selectedPosition.position));
                gameObject.tag = "Using";
                isSelected = true;
            }
            else if (isSelected)
            {
                StartCoroutine(MoveCube(selectedPosition.position, initialPoint));
                gameObject.tag = "Resting";
                isSelected = false;
            }
        }
    }

    IEnumerator MoveCube(Vector3 aPoint, Vector3 bPoint)
    {
        isMoving = true;
        float rate = 1.0f / Vector3.Distance(aPoint, bPoint) * 3;
        float t = 0.0f;
        while (t < 2.0f)
        {
            t += Time.deltaTime * rate;
            transform.position = Vector3.MoveTowards(aPoint, bPoint, t);
            yield return null;
        }
        isMoving = false;
    }

    IEnumerator RefreshNumbers()
    {
        yield return new WaitForSeconds(0.9f);
        if (isSelected & fire.isPlaying)
        {
            actualTemp.text = temperature.ToString();
            if (PlayerPrefs.GetInt("Temp") == 1)
            {
                actualTemp.text = (temperature * 9 / 5 + 32).ToString();
                celsiusFahreinheit.text = "ºF";
            }
            else
            {
                celsiusFahreinheit.text = "ºC";
            }
            IncreaseTemperature();
        }
        else
        {
            actualTemp.text = temperature.ToString();
            if (PlayerPrefs.GetInt("Temp") == 1)
            {
                actualTemp.text = (temperature * 9 / 5 + 32).ToString();
                celsiusFahreinheit.text = "ºF";
            }
            else
            {
                celsiusFahreinheit.text = "ºC";
            }
            DecreaseTemperature();
        }
    }
}
