using Unity.VisualScripting;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateController movement)
    {
        movement.Animator.Walk(true);
        movement.CurrentMoveSpeed = movement.WalkSpeed;
    }

    public override void UpdateState(MovementStateController movement)
    {
        if (movement.IsRunning == true)
        {
            ExitState(movement, movement.Run);
        }
        else if(movement.IsJumping == true)
        {
            ExitState(movement, movement.Jump);
        }
        else if(movement.Direction.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }

       
    }

    private void ExitState(MovementStateController movement, MovementBaseState state)
    {
        movement.Animator.Walk(false);

        movement.SwitchState(state);
    }
}
