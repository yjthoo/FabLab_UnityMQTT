using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MQTTController : MonoBehaviour
{
    public string node = "LuxMeter_Controller";
    public string tagOfTheMQTTReceiver = "mqtt_receiver";
    private MQTTReceiver _eventSender;

    void Start()
    {
        _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<MQTTReceiver>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        this.GetComponent<TextMeshPro>().text = newMsg;
        Debug.Log("Event Fired. The message, from node " + node + " is = " + newMsg);
    }
}
