public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateController movement)
    {
        movement.Animator.Run(true);
        movement.CurrentMoveSpeed = movement.RunSpeed;
    }

    public override void UpdateState(MovementStateController movement)
    {
        if (movement.IsRunning == false)
        {
            ExitState(movement, movement.Walk);
        }
        else if (movement.Direction.magnitude < 0.1)
        {
            ExitState(movement, movement.Idle);
        }

    }

    private void ExitState(MovementStateController movement, MovementBaseState state)
    {
        movement.Animator.Run(false);

        movement.SwitchState(state);
    }
}
