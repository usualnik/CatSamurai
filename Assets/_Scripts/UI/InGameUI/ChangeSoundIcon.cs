using UnityEngine;
using UnityEngine.UI;

public class ChangeSoundIcon : MonoBehaviour
{
    [SerializeField] private Image _soundIcon;
    
    [SerializeField] private Sprite _sound;
    [SerializeField] private Sprite _muteSound;

    public void ChangeSoundSprite()
    {
        if (_soundIcon.sprite == _sound)
        {
            _soundIcon.sprite = _muteSound;
        }
        else
        {
            _soundIcon.sprite = _sound;
        }
    }

}
