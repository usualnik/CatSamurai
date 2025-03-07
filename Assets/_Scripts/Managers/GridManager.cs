using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    
    [SerializeField] private GridCell[] _cellsArray;
    
    private Color _notAvailableColor = Color.black;
   
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

    public void ShowGridUpdated()
    {
        foreach (var gridCell in _cellsArray)             
        {
            if (!gridCell.ThisGridCellIsAvailable)
            {
                Image image = gridCell.gameObject.GetComponent<Image>();
                
                image.color = _notAvailableColor;
                image.raycastTarget = false;

            }
        }
    }

    public GridCell[] GetCellsArray()
    {
        return _cellsArray;
    }
    
}
