public class ReloadState : ActionBaseState
{
    public override void EnterState(ActionStateController action)
    {
        action.RHandAim.weight = 0;
        action.LHandIK.weight = 0;
        action.Animator.Reload();
    }

    public override void UpdateState(ActionStateController action)
    {
        
    }

}
