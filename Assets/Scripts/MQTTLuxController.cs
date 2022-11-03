using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTTLuxController : MonoBehaviour
{
    public string node = "LuxMeter_Controller";
    public string tagOfTheMQTTReceiver = "mqtt_receiver";
    private MQTTReceiver _eventSender;
    private float luxValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<MQTTReceiver>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        luxValue = float.Parse(newMsg);
    }

    public float GetLuxValue()
    {
        return luxValue;
    }
}
