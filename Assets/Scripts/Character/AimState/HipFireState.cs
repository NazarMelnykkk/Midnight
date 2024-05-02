public class HipFireState : AimBaseState
{
    public override void EntryState(AimStateController aim)
    {
        aim.Animator.Aim(false);
        aim.CurrentFov = aim.HipFov;
    }

    public override void UpdateState(AimStateController aim)
    {
        if (aim.WeaponController.IsAiming == true)
        {
            aim.SwitchState(aim.Aim);
        }
    }
}
