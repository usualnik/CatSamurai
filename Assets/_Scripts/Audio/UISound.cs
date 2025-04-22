using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UISound : MonoBehaviour
{
   [SerializeField] private AudioClip _uiSound;

   public static UISound Instance{ get; private set; }

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

   public void PlayUISound()
   {
      _audioSource.PlayOneShot(_uiSound);
   }
   
}
