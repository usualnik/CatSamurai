using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Translator : MonoBehaviour
{
    [SerializeField] private string _ruText;
    [SerializeField] private string _enText;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    private void Start()
    {
        if (YG2.envir.language == "ru")
        {
            _text.text = _ruText;
        }
        else
        {
            _text.text = _enText;
        }
    }
}
