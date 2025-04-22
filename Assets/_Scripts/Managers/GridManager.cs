using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    
    [SerializeField] private GameObject _grid;
    [SerializeField] private GridCell[] _cellsArray;
    
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
        GameManager.Instance.OnGamePlayStarted += GameManager_OnGamePlayStarted;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGamePlayStarted -= GameManager_OnGamePlayStarted;
    }
    
    private void GameManager_OnGamePlayStarted(object sender, EventArgs e)
    {
        ShowGrid();
    }

    public void UpdateGrid()
    {
        foreach (var gridCell in _cellsArray)             
        {
            if (!gridCell.ThisGridCellIsAvailable)
            {
                Image image = gridCell.gameObject.GetComponent<Image>();
                image.raycastTarget = false;
            }
            else
            {
                Image image = gridCell.gameObject.GetComponent<Image>();
                image.raycastTarget = true;
            }
        }
    }

    private void ShowGrid()
    {
        SFX.Instance.PlayGridAnimationSound();
        _grid.SetActive(true);
    }
    private void HideGrid()
    {
        _grid.SetActive(false);
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

    public void MinimizePlacedCatsAlpha()
    {
        foreach (var gridCell in _cellsArray)             
        {
            if (!gridCell.ThisGridCellIsAvailable)
            {
                Image catImage = gridCell.CatOnThisCell.gameObject.GetComponent<Image>();
                if (catImage != null) 
                {
                    Color currentColor = catImage.color; 
                    currentColor.a = 0.5f; 
                    catImage.color = currentColor; 
                }
            }
        }
    }
    public void MaximazePlacedCatsAlpha()
    {
        foreach (var gridCell in _cellsArray)             
        {
            if (!gridCell.ThisGridCellIsAvailable)
            {
                Image catImage = gridCell.CatOnThisCell.gameObject.GetComponent<Image>();
                if (catImage != null) 
                {
                    Color currentColor = catImage.color; 
                    currentColor.a = 255f; 
                    catImage.color = currentColor; 
                }
            }
        }
    }
    
}
