
public class DefaultState : ActionBaseState
{
    public override void EnterState(ActionStateController action)
    {
        action.RHandAim.weight = 1;
        action.LHandIK.weight = 1;
    }

    public override void UpdateState(ActionStateController action)
    {
        if (action.WeaponController.IsReloading == true)
        {
            action.SwitchState(action.ReloadState);
        }
    }
}
