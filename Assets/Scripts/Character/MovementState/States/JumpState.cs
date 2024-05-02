public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateController movement)
    {
        movement.Animator.Jump(true);
    }

    public override void UpdateState(MovementStateController movement)
    {
/*        if(movement.IsJumping == true)
        {
            return;
        }*/

        if (movement.IsRunning == true)
        {
            ExitState(movement, movement.Run);
        }

        if (movement.Direction.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }
        else
        {
            ExitState(movement, movement.Walk);
        }
    }

    private void ExitState(MovementStateController movement, MovementBaseState state)
    {
        movement.IsJumping = false;
        movement.Animator.Jump(false);

        movement.SwitchState(state);
    }
}
