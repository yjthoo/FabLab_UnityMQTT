using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateMachine : StateMachine
{
    [HideInInspector]
    public IdleState idleState;

    [HideInInspector]
    public ChangeMaterialState changeMaterialState;

    [HideInInspector]
    public PositionControlState positionControlState;

    [HideInInspector]
    public enum UserCommand
    {
        None, 
        SetIdle, 
        SetMaterialChange,
        SetPositionControl
    }

    private UserCommand userInput;
    private float sliderValue;
    private bool goBackwards = true;

    public GameObject robot;
    public GameObject checkBox;

    private void Awake()
    {
        idleState = new IdleState(this);
        changeMaterialState = new ChangeMaterialState(this);
        positionControlState = new PositionControlState(this);

        userInput = UserCommand.None;
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void SetIdleState()
    {
        userInput = UserCommand.SetIdle;
    }

    public void SetChangeMaterialState()
    {
        userInput = UserCommand.SetMaterialChange;
    }

    public void SetPositionControlState()
    {
        userInput = UserCommand.SetPositionControl;
    }

    public UserCommand GetUserCommand()
    {
        return userInput;
    }

    public void SetUserCommandToNone()
    {
        userInput = UserCommand.None;
    }

    public void SetSliderValue(Slider slider)
    {
        sliderValue = slider.value;
    }

    public float GetSliderValue()
    {
        return sliderValue;
    }

    public void SetDirectionValue()
    {
        goBackwards = !goBackwards;
    }

    public bool GetDirectionValue()
    {
        return goBackwards;
    }

    public float GetLuxValue()
    {
        return this.GetComponent<MQTTLuxController>().GetLuxValue();
    }
}
