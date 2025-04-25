using UnityEngine;

public class Mute : MonoBehaviour
{
    public void MuteAllSound()
    {
        AudioSource[] allSound = GetComponentsInChildren<AudioSource>();

        foreach (var sound in allSound)
        {
            if (!sound.mute)
            {
                sound.mute = true;
            }
            else
            {
                sound.mute = false;
            }
           
        }
        
    }
}
