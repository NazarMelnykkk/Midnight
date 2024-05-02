using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private Weapon[] _weapons;

    [Header("Components")]
    [HideInInspector] public WeaponConfig Config;
    [HideInInspector] public Weapon CurrentWeapon;

    [SerializeField] private AimStateController _aimStateController;
    [SerializeField] private ActionStateController _actionStateController;

    [Header("AIM")]
    public bool IsAiming = false;


    [Header("Actions")]
    public bool IsReloading = false;

    private void Start()
    {
        foreach (Weapon weapon in _weapons)
        {
            if (weapon != null && weapon.gameObject.activeSelf == true)
            {
                Config = weapon.WeaponConfigs;
                CurrentWeapon = weapon;
                return;
            }
        }
    }

    public void SwitchWeapon(int weaponIndex)
    {
        if (IsReloading == true)
        {
            return;
        }

        weaponIndex--;

        foreach (Weapon weapon in _weapons)
        {
            if (weapon != null)
            {
                weapon.gameObject.SetActive(false);
            }
        }

        _weapons[weaponIndex].gameObject.SetActive(true);

        Config = _weapons[weaponIndex].WeaponConfigs;
        CurrentWeapon = _weapons[weaponIndex];

    }


}
