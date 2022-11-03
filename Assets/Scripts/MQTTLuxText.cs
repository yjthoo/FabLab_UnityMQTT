using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MQTTLuxText : MonoBehaviour
{
    public string node = "LuxMeter_Text";
    public string tagOfTheMQTTReceiver = "mqtt_receiver";
    private MQTTReceiver _eventSender;

    // Start is called before the first frame update
    void Start()
    {
        _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<MQTTReceiver>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        this.GetComponent<Text>().text = "Luxmeter value: " +newMsg;
    }
}
