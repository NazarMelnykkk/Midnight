using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public static PlayerInputActions InputActions;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InputActions = new PlayerInputActions(); 
        InputActions.Enable();
    }

    private void OnEnable()
    {
        InputActions.Enable();

        InputActions.Character.Move.performed += MoveStarted;
        InputActions.Character.Move.canceled += MoveCanceled;


        InputActions.Character.Run.performed += RunStarted;
        InputActions.Character.Run.canceled += RunCanceled;


        InputActions.Character.Jump.performed += JumpStarted;
        InputActions.Character.Jump.canceled += JumpCanceled;

        InputActions.Character.Fire.performed += FireStarted;
        InputActions.Character.Fire.canceled += FireCanceled;
        InputActions.Character.Reload.performed += Reload;

        InputActions.Character.Weapon_1.performed += Weapon1;
        InputActions.Character.Weapon_2.performed += Weapon2;
        InputActions.Character.Weapon_3.performed += Weapon3;

        InputActions.Character.Menu.started += Menu;

    }

    private void OnDisable()
    {
        InputActions.Disable();

        InputActions.Character.Move.performed -= MoveStarted;
        InputActions.Character.Move.canceled -= MoveCanceled;

        InputActions.Character.Run.performed -= RunStarted;
        InputActions.Character.Run.canceled -= RunCanceled;

        InputActions.Character.Jump.performed -= JumpStarted;
        InputActions.Character.Jump.canceled -= JumpCanceled;

        InputActions.Character.Fire.started -= FireStarted;
        InputActions.Character.Fire.canceled -= FireCanceled;

        InputActions.Character.Reload.performed -= Reload;

        InputActions.Character.Weapon_1.performed -= Weapon1;
        InputActions.Character.Weapon_2.performed -= Weapon2;
        InputActions.Character.Weapon_3.performed -= Weapon3;

        InputActions.Character.Menu.started -= Menu;

    }

    public event Action<Vector2> OnMoveEventPerformed;


    #region Move
    private void MoveStarted(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();

        OnMoveEventPerformed?.Invoke(value);
    }

    public event Action<Vector2> OnMoveEventCanceled;
    private void MoveCanceled(InputAction.CallbackContext context)
    {
        Vector2 value = Vector2.zero;

        OnMoveEventCanceled?.Invoke(value);
    }

    #endregion

    #region Run
    public event Action<bool> OnRunEventPerformed;
    private void RunStarted(InputAction.CallbackContext context)
    {
        OnRunEventPerformed?.Invoke(true);
    }

    public event Action<bool> OnRunEventCanceled;
    private void RunCanceled(InputAction.CallbackContext context)
    {
        OnRunEventCanceled?.Invoke(false);
    }

    #endregion

    #region Jump
    public event Action<bool> OnJumpEventPerformed;
    private void JumpStarted(InputAction.CallbackContext context)
    {
        OnJumpEventPerformed?.Invoke(true);
    }

    public event Action<bool> OnJumpEventCanceled;
    private void JumpCanceled(InputAction.CallbackContext context)
    {
        OnJumpEventCanceled?.Invoke(false);
    }

    #endregion

    #region Fire

    public event Action<bool> OnFireEventPerformed;
    private void FireStarted(InputAction.CallbackContext context)
    {
        bool Isfire = true;
        OnFireEventPerformed?.Invoke(Isfire);
    }

    public event Action<bool> OnFireEventCanceled;
    private void FireCanceled(InputAction.CallbackContext context)
    {
        bool Isfire = false;
        OnFireEventCanceled?.Invoke(Isfire);
    }

    #endregion

    #region Reload

    public event Action OnReloadEventPerformed;
    private void Reload(InputAction.CallbackContext context)
    {
        OnReloadEventPerformed?.Invoke();
    }

    #endregion

    #region SwitchWeapon

    public event Action<int> OnWeapon_1EventPerformed;
    private void Weapon1(InputAction.CallbackContext context)
    {
        int weaponIndex = 1;
        OnWeapon_1EventPerformed?.Invoke(weaponIndex);
    }

    public event Action<int> OnWeapon_2EventPerformed;
    private void Weapon2(InputAction.CallbackContext context)
    {
        int weaponIndex = 2;
        OnWeapon_2EventPerformed?.Invoke(weaponIndex);
    }

    public event Action<int> OnWeapon_3EventPerformed;
    private void Weapon3(InputAction.CallbackContext context)
    {
        int weaponIndex = 3;
        OnWeapon_3EventPerformed?.Invoke(weaponIndex);
    }


    #endregion

    #region Actions
    public event Action OnMenuEventStarted;
    private void Menu(InputAction.CallbackContext context)
    {
        OnMenuEventStarted?.Invoke();
    }

    #endregion
}