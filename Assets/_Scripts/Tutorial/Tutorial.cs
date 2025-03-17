using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public event EventHandler OnTutorialEnded;

    private int tutorialNum = 1;
    private Animator _animator;
    private const string CHANGE_TUTORIAL = "ChangeTutorial";
    private const int MAX_TUTORIALS_COUNT = 3;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger(CHANGE_TUTORIAL, tutorialNum);
    }

    private void ChangeTutorial()
    {
        tutorialNum++;
        if (tutorialNum <= MAX_TUTORIALS_COUNT)
        {
            _animator.SetInteger(CHANGE_TUTORIAL, tutorialNum);
        }
        else
        {
            OnTutorialEnded?.Invoke(this,EventArgs.Empty);
        }
        
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ChangeTutorial();
        }
    }
}
