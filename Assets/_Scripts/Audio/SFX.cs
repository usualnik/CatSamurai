using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class SFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] _meleeAttackSounds;
    [SerializeField] private AudioClip _mageFireball;
    [SerializeField] private AudioClip _addSushi;
    [SerializeField] private AudioClip _levelUp;
    [SerializeField] private AudioClip _heal;
    [SerializeField] private AudioClip _gridAnimation;
    [SerializeField] private AudioClip _error;

   // private float _defaultVolume = 0.1f;
    public static SFX Instance{ get; private set; }

    private AudioSource _audioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one instance of UISound");
        }

        _audioSource = GetComponent<AudioSource>();

    }

    public void PlayRandomMeleeAttackSound()
    {
        int randomIndex = Random.Range(0, _meleeAttackSounds.Length);
        _audioSource.PlayOneShot(_meleeAttackSounds[randomIndex]);
    }
    public void PlayMageFireballSound()
    {
        _audioSource.PlayOneShot(_mageFireball);
    }
    public void PlayAddSushiSound()
    {
        _audioSource.PlayOneShot(_addSushi);
    }
    public void PlayLevelUpSound()
    {
        _audioSource.PlayOneShot(_levelUp);
    }
   
    public void PlayHealSound()
    {
        _audioSource.PlayOneShot(_heal);
    }
    public void PlayGridAnimationSound()
    {
        
        _audioSource.PlayOneShot(_gridAnimation,20f);
    }
    public void PlayErrorSound()
    {
        
        _audioSource.PlayOneShot(_error);
    }
}