using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveCatHandler : MonoBehaviour, IPointerClickHandler
{
    public bool IsRemoveCatMode { get; private set; }
    public static RemoveCatHandler Instance { get; private set; }
    
    
    private List<GridCell> gridCellsToRemoveCats;

    private void Awake()
    {
        Instance = this;
        gridCellsToRemoveCats = new List<GridCell>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }
        
        if (!IsRemoveCatMode)
        {
            RemoveCatModeOn();
        }
        else
        {
            RemoveCatModeOff();
        }
    }

    
    public void RemoveCatModeOff()
    {
        IsRemoveCatMode = false;
        HideRemovableCats(GridManager.Instance.GetUnAvailableCellsList());
    }
    
    private void HideRemovableCats(List<GridCell> unAvailableCells)
    {
        foreach (var gridCell in unAvailableCells)
        {
            gridCell.CatOnThisCell.GetComponent<BaseCat>().HideRemoveIcon();
        }
    }
    
    private void RemoveCatModeOn()
    {
        IsRemoveCatMode = true;
        gridCellsToRemoveCats = GridManager.Instance.GetUnAvailableCellsList();
        ShowRemovableCats(gridCellsToRemoveCats);
    }

    private void ShowRemovableCats(List<GridCell> unAvailableCells)
    {
        foreach (var gridCell in unAvailableCells)
        {
            gridCell.CatOnThisCell.GetComponent<BaseCat>().ShowRemoveIcon();
        }
    }

    public void RemoveCat(GridCell gridCell, BaseCat cat)
    {
        gridCell.FreeThisCell();
        cat.RemoveFromField();
    }
    
    
    
    
}
