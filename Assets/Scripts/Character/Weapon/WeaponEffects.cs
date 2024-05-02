using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlaySound(SoundType type,string sound)
    {
        AudioHandler.Instance.PlaySound(type, sound);
    }

    public void PlayVFX()
    {
        _particleSystem.Play();
    }
}
