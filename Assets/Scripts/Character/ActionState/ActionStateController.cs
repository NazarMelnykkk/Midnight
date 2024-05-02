using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateController : MonoBehaviour
{
    [Header("Components")]
    public WeaponController WeaponController;
    public CharacterAnimationController Animator;

    private ActionBaseState _currentState;

    public ReloadState ReloadState = new ReloadState();
    public DefaultState DefaultState = new DefaultState();

    public MultiAimConstraint RHandAim;
    public TwoBoneIKConstraint LHandIK;


    private void Start()
    {
        SwitchState(DefaultState);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }


    public void Reload()
    {
        if (WeaponController.IsReloading == true && WeaponController.CurrentWeapon.CanReload() == false)
        {
            return;
        }

        WeaponController.IsReloading = true;
        WeaponController.CurrentWeapon.Reload();
        StartCoroutine(ReloadCoroutine());
    }

    public void SwitchState(ActionBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(WeaponController.Config.ReloadTime);

        WeaponController.IsReloading = false;
        SwitchState(DefaultState);
    }
}
