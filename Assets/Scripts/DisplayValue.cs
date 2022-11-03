using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayValue : MonoBehaviour
{
    float sensorValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Text>().text = "Luxmeter value: ";
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Luxmeter value: " + sensorValue.ToString();
    }

    public void GetSensorValue(Slider slider)
    {
        sensorValue = slider.value;
    }
}
