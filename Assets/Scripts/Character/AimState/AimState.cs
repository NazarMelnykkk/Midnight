public class AimState : AimBaseState
{
    public override void EntryState(AimStateController aim)
    {
        aim.Animator.Aim(true);
        aim.CurrentFov = aim.AdsFov;
    }

    public override void UpdateState(AimStateController aim)
    {
        if (aim.WeaponController.IsAiming == false)
        {
            aim.SwitchState(aim.Hip);
        }
    }
}
