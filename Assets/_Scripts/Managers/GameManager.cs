using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Sushi { get; private set; } = 10000;
    
    [SerializeField] private TextMeshProUGUI _sushiText;
   

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
