using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string SoundName;
    public AudioClip AudioClip;
    [Range(-3, 3)] public float MinPitch = 1f;
    [Range(-3, 3)] public float MaxPitch = 1f;
}

public enum SoundType
{
    Sound,
    Music,
    Ambient,
    SFX
}

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;

    [SerializeField] private Sound[] _sounds;
    [SerializeField] private Sound[] _musics;
    [SerializeField] private Sound[] _SFX;
    [SerializeField] private Sound[] _ambients;

    [SerializeField] private AudioSource _soundAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _SFXAudioSource;
    [SerializeField] private AudioSource _ambientAudioSource;

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
    }

    private void SetRandomPithcValue(AudioSource audioSource, Sound sound)
    {
        audioSource.pitch = UnityEngine.Random.Range(sound.MinPitch, sound.MaxPitch);
    }

    private Sound GetSoundByType(SoundType type, string soundName)
    {
        Sound[] soundsArray = GetSoundsArrayByType(type);
        if (soundsArray == null)
        {
            Debug.Log($"Sounds of type {type} not found");
            return null;
        }

        return Array.Find(soundsArray, currentSound => currentSound.SoundName == soundName);
    }

    private Sound[] GetSoundsArrayByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.Sound:
                return _sounds;
            case SoundType.Music:
                return _musics;
            case SoundType.Ambient:
                return _ambients;
            case SoundType.SFX:
                return _SFX;
            default:
                Debug.Log($"Unknown sound type {type}");
                return null;
        }
    }

    public void PlaySound(SoundType type, string soundName)
    {
        Sound currentSound = GetSoundByType(type, soundName);
        if (currentSound == null)
        {
            Debug.Log($"Sound {soundName} of type {type} not found");
            return;
        }

        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
        {
            SetRandomPithcValue(audioSource, currentSound);
            audioSource.PlayOneShot(currentSound.AudioClip);
        }
    }

    public void ToggleSound(SoundType type)
    {
        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
            audioSource.mute = !audioSource.mute;
    }

    public void SetVolume(SoundType type, float volume)
    {
        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
            audioSource.volume = volume;
    }

    private AudioSource GetAudioSourceByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.Sound:
                return _soundAudioSource;
            case SoundType.Music:
                return _musicAudioSource;
            case SoundType.Ambient:
                return _ambientAudioSource;
            case SoundType.SFX:
                return _SFXAudioSource;
            default:
                Debug.Log($"Unknown sound type {type}");
                return null;
        }
    }

    public float GetVolume(SoundType type)
    {
        AudioSource audioSource = GetAudioSourceByType(type);
        if (audioSource != null)
            return audioSource.volume;

        return 0f;
    }

   
}