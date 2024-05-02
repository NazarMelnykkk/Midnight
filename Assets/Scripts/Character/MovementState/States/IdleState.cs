public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateController movement)
    {

    }

    public override void UpdateState(MovementStateController movement)
    {
        if(movement.Direction.magnitude > 0.1) 
        {
            if(movement.IsRunning == true)
            {
                movement.SwitchState(movement.Run);
            }
            else
            {
                movement.SwitchState(movement.Walk);
            }
        }
        if (movement.IsJumping == true)
        {
            movement.SwitchState(movement.Jump);
        }
    }
}
