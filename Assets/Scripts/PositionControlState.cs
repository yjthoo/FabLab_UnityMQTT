using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControlState : BaseState
{
    private GameStateMachine _sm;
    private GameObject myRobot;

    public PositionControlState(GameStateMachine stateMachine) : base("Position Control State", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        myRobot = Object.Instantiate(_sm.robot);
        myRobot.transform.localScale = new Vector3(10f, 10f, 10f);
        myRobot.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        _sm.checkBox.SetActive(true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        switch (_sm.GetUserCommand())
        {
            case GameStateMachine.UserCommand.SetIdle:
                _sm.ChangeState(_sm.idleState);
                _sm.SetUserCommandToNone();
                break;
            case GameStateMachine.UserCommand.SetMaterialChange:
                _sm.ChangeState(_sm.changeMaterialState);
                _sm.SetUserCommandToNone();
                break;
            case GameStateMachine.UserCommand.SetPositionControl:
                _sm.ChangeState(_sm.positionControlState);
                _sm.SetUserCommandToNone();
                break;
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        /*if (!(_sm.GetSliderValue() > 0f))
        {
            return;
        }

        float value = _sm.GetSliderValue()/1000f;*/

        float value = _sm.GetLuxValue() / 50000f;

        if (_sm.GetDirectionValue())
            myRobot.transform.position += new Vector3(0f, 0f, value);
        else
            myRobot.transform.position -= new Vector3(0f, 0f, value);
    }

    public override void Exit()
    {
        base.Exit();
        Object.Destroy(myRobot);

        _sm.checkBox.SetActive(false);
    }
}
