using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    public WeaponConfig WeaponConfigs;
    [SerializeField] private WeaponEffects _weaponEffects;

    [Header("Ammo")]
    [SerializeField] private int AmmoCount;
    [SerializeField] private int MaxAmmoCount;
    [SerializeField] private WeaponRecoil _weaponRecoil;

    public int MagCount;

    private void Awake()
    {
        MaxAmmoCount = WeaponConfigs.MagSize;
        AmmoCount = MaxAmmoCount;
    }

    public bool Shot()
    {
        if (AmmoCount <= 0)
        {
            _weaponEffects.PlaySound(WeaponConfigs.SoundType, WeaponConfigs.NoAmmoSoundName);
            return false;
        }

        _weaponRecoil.TriggerRecoil();
        _weaponEffects.PlaySound(WeaponConfigs.SoundType, WeaponConfigs.ShotSoundName);
        _weaponEffects.PlayVFX();
        AmmoCount--;
        return true;
    }

    public void Reload()
    {
        if (CanReload() == true)
        {
            _weaponEffects.PlaySound(WeaponConfigs.SoundType, WeaponConfigs.ReloadSoundName);
            AmmoCount = MaxAmmoCount;
            MagCount--;
        }
    }

    public bool CanReload()
    {
        if (AmmoCount == MaxAmmoCount)
        {
            return false;
        }

        if (MagCount <= 0)
        {
            return false;
        }

        return true;
    }

}
