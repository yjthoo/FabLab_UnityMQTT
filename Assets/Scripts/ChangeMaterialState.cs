using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialState : BaseState
{
    private GameStateMachine _sm;
    private GameObject capsule;

    private const float threshold = 50f;

    public ChangeMaterialState(GameStateMachine stateMachine) : base("Change Material", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(0f, 1f, 2.5f);
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

        /*float value = _sm.GetSliderValue();
        capsule.GetComponent<Renderer>().material.color = new Color(value/ 100f, value/ 100f, value / 100f);*/

        float value = _sm.GetLuxValue() / 1000f;
        capsule.GetComponent<Renderer>().material.color = new Color(value, value, value);
    }

    public override void Exit()
    {
        base.Exit();
        Object.Destroy(capsule);
    }
}
