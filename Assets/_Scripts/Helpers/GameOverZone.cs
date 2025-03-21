using System;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public static GameOverZone Instance { get; private set; }

    public event EventHandler<GameOverMessageEventArgs> OnRacoonEnterGameOverZone;
    
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseRacoon>())
        {
            
            OnRacoonEnterGameOverZone?.Invoke(this, new GameOverMessageEventArgs(){GameOverMessage = "Еноты украли всю вашу рыбу!"});
        }
    }
}
