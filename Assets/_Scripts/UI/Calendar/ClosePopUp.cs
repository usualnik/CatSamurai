using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            _popup.SetActive(false);
        }
    }
}
