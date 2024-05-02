using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Weapon", fileName = "WeaponConfig")]
public class WeaponConfig : ScriptableObject
{

    public string ID;

    public int Damage = 5;
    public float FireDistance = 5f;
    public AmmoType AmmoType;
    public int MagSize;
    public float FireRate;
    public float ReloadTime;
    public int ShotCount;

    public bool UseSpread;
    public float SpreadFactor = 1f;


    [Header("AUDIO")]
    public SoundType SoundType = SoundType.Sound;
    public string ShotSoundName;
    public string NoAmmoSoundName;
    public string ReloadSoundName;

    public void OnValidate()
    {
        if (ID == "")
        {
            ID = name;
        }
    }
}
