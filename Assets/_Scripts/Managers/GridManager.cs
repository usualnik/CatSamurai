using System.Collections.Generic;
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
            else
            {
                Image image = gridCell.gameObject.GetComponent<Image>();
                
                image.color = Color.white;
                image.raycastTarget = true;
            }
        }
    }
    public GridCell[] GetAllCellsArray()
    {
        return _cellsArray;
    }
    public List<GridCell> GetAvailableCellsList()
    {
        List<GridCell> availableCellsList = new List<GridCell>();
        
        foreach (var gridCell in _cellsArray)             
        {
            if (gridCell.ThisGridCellIsAvailable)
            {
                availableCellsList.Add(gridCell);
            }
        }

        return availableCellsList;
    }
    public List<GridCell> GetUnAvailableCellsList()
    {
        List<GridCell> unAvailableCellsList = new List<GridCell>();
        
        foreach (var gridCell in _cellsArray)             
        {
            if (!gridCell.ThisGridCellIsAvailable)
            {
                unAvailableCellsList.Add(gridCell);
            }
        }
        
        return unAvailableCellsList;
    }

    public BaseCat GetRandomCatFromGrid()
    {
        int randomCatIndex = Random.Range(0, GetUnAvailableCellsList().Count);
        return GetUnAvailableCellsList()[randomCatIndex].CatOnThisCell;
    }
    
}
