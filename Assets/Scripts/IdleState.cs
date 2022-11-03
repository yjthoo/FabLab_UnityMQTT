using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private GameStateMachine _sm;

    public IdleState (GameStateMachine stateMachine) : base("Idle", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
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
    }

    public override void Exit()
    {
        base.Exit();
    }
}
