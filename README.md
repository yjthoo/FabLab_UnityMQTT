# FabLab - MQTT Client in Unity Demo

This Unity project contains a solution to the Unity part of the exercise of the ["Fabrication and prototyping in the LearningLab"](https://www.unifr.ch/timetable/fr/detail-du-cours.html?show=109456) course provided by the University of Fribourg. During this exercise, students were required to use MQTT to send the data from a VEML 7700 luxmeter to a Unity Client. The solution is heavily insipired by the [MQTT client tutorial](https://workshops.cetools.org/codelabs/CASA0019-unity-mqtt/index.html) which you should follow to gain a better understanding of the MQTT side of the project. 

## Contents

* **FabLabTutorial**: This scene connects to a broker from which it receives data from a VEML 7700 luxmeter to control either the color of an object or move a robot back and forth. Don't forget to connect to the network created from your Raspberry Pi and modify the credentials of the *MQTTReceiver* script attached to the *MQTT_Receiver* gameobject. 

* **MQTTDemo**: This scene is the scene created during the tutorial mentionned above and can be used to ensure you have managed to connect to the borker and retrieve the data from the luxmeter. 

## Unity Version

This project was created with Unity version 2020.3.19f1, however it should also work with future versions.

