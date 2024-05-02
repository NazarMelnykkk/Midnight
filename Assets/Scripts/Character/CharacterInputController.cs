using UnityEngine;

public class CharacterInputController : MonoBehaviour
{

    [SerializeField] private CommandHandler _commandHandler;

    [SerializeField] private AimStateController _aimHandler;
    [SerializeField] private ActionStateController _actionStateController;
    [SerializeField] private WeaponController _weaponContainer;
    [SerializeField] private MovementStateController _movementStateController;

    private void OnEnable()
    {
        InputController.Instance.OnMoveEventPerformed += MoveCommand;
        InputController.Instance.OnMoveEventCanceled += MoveCommand;

        InputController.Instance.OnFireEventPerformed += Fire;
        InputController.Instance.OnFireEventCanceled += Fire;

        InputController.Instance.OnWeapon_1EventPerformed += SwitchWeapon;
        InputController.Instance.OnWeapon_2EventPerformed += SwitchWeapon;
        InputController.Instance.OnWeapon_3EventPerformed += SwitchWeapon;

        InputController.Instance.OnRunEventPerformed += Run;
        InputController.Instance.OnRunEventCanceled += Run;

        InputController.Instance.OnJumpEventPerformed += Jump;
        InputController.Instance.OnJumpEventCanceled += Jump;

        InputController.Instance.OnReloadEventPerformed += Reload;
    }

    private void OnDisable()
    {
        InputController.Instance.OnMoveEventPerformed -= MoveCommand;
        InputController.Instance.OnMoveEventCanceled -= MoveCommand;

        InputController.Instance.OnFireEventPerformed -= Fire;
        InputController.Instance.OnFireEventCanceled -= Fire;

        InputController.Instance.OnWeapon_1EventPerformed -= SwitchWeapon;
        InputController.Instance.OnWeapon_2EventPerformed -= SwitchWeapon;
        InputController.Instance.OnWeapon_3EventPerformed -= SwitchWeapon;

        InputController.Instance.OnRunEventPerformed -= Run;
        InputController.Instance.OnRunEventCanceled -= Run;

        InputController.Instance.OnJumpEventPerformed -= Jump;
        InputController.Instance.OnJumpEventCanceled -= Jump;

        InputController.Instance.OnReloadEventPerformed -= Reload;
    }

    private void MoveCommand(Vector2 direction)
    {
        _commandHandler.SetCommand(new Command(CommandType.Move, direction));
    }

    private void Fire(bool isFire)
    {
        _aimHandler.PerformAttack(isFire);
    }

    private void SwitchWeapon(int weaponIndex)
    {
        _weaponContainer.SwitchWeapon(weaponIndex);
    }

    public void Run(bool value)
    {
        _movementStateController.IsRunning = value;
    }

    public void Jump(bool value)
    {
        _movementStateController.IsJumping = value;
    }

    public void Reload()
    {
        _actionStateController.Reload();
    }
}
