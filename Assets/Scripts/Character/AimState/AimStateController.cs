using Cinemachine;
using System.Collections;
using UnityEngine;

public class AimStateController : MonoBehaviour
{
    [Header("Components")]
    public WeaponController WeaponController;

    public CharacterAnimationController Animator;
    public CinemachineVirtualCamera VCam;
    [SerializeField] private WeaponRaycastHandler _weaponRaycastHandler;

    [Header("Camera")]
    [SerializeField] private Transform _cameraFollow;
    [SerializeField] private float _mouseSense = 1f;

    [HideInInspector] public float CurrentFov = 40;
    [HideInInspector] public float AdsFov = 40;
    [HideInInspector] public float HipFov;

    private float FovSmoothSpeed = 10f;

    private float _axisStateX, _axisStateY;

    [Header("State")]
    private AimBaseState _currentState;

    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    private bool _canAim = true;

    private void Start()
    {
        HipFov = VCam.m_Lens.FieldOfView;

        SwitchState(Hip);
    }

    private void Update()
    {
        _axisStateX += Input.GetAxisRaw("Mouse X") * _mouseSense;
        _axisStateY -= Input.GetAxisRaw("Mouse Y") * _mouseSense;
        _axisStateY = Mathf.Clamp(_axisStateY, -80, 80);

        VCam.m_Lens.FieldOfView = Mathf.Lerp(VCam.m_Lens.FieldOfView, CurrentFov, FovSmoothSpeed * Time.deltaTime);

        _currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        _cameraFollow.localEulerAngles = new Vector3(_axisStateY, _cameraFollow.localEulerAngles.y, _cameraFollow.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _axisStateX, transform.eulerAngles.z);
    }

    public void PerformAttack(bool isAiming)
    {
        WeaponController.IsAiming = isAiming;

        if (_canAim == false)
        {
            return;
        }

        if (WeaponController.IsReloading == true)
        {
            return;
        }

        if (WeaponController.IsAiming == true)
        {
            if (WeaponController.CurrentWeapon.Shot() == true)
            {
                for (int i = 0; i < WeaponController.Config.ShotCount; i++)
                {
                    _weaponRaycastHandler.PerformRaycast(WeaponController.Config);
                }
                _canAim = false;
                StartCoroutine(FireCoroutine());
            }
/*            else
            {
                WeaponController.PlaySound(WeaponController.Config.NoAmmoSoundName);
            }*/
        }
    }

    public void SwitchState(AimBaseState state)
    {
        _currentState = state;
        _currentState.EntryState(this);
    }

    private IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(WeaponController.Config.FireRate);

        _canAim = true;
        PerformAttack(WeaponController.IsAiming);
    }

}
