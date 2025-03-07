using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int Sushi { get; private set; } = 10000;
    
    [SerializeField] private TextMeshProUGUI _sushiText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one instance of Game Manager");
        }
    }
    
    private void Start()
    {
        _sushiText.text = "SUSHI: " + Sushi;
    }

    public void SubtractSushi(int value)
    {
        Sushi -= value;
        _sushiText.text = "SUSHI: " + Sushi;
    }

}
