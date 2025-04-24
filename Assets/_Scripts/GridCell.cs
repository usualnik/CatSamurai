using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public bool ThisGridCellIsAvailable { get; private set; } = true;
    public BaseCat CatOnThisCell { get; private set; }
    public event EventHandler OnCatPlaced;

    private UIChooseCatMenu _uiChooseCatMenu;
  

    private void Start()
    {
        _uiChooseCatMenu = GameObject.Find("UI_ChooseCatMenu").GetComponent<UIChooseCatMenu>();
    }

    public void OnPointerEnter(PointerEventData eventData) // Just a visual representation
     {
         if (_uiChooseCatMenu.CurrentChosenCat != null)
         {
             _uiChooseCatMenu.CurrentChosenCat.transform.SetParent(gameObject.transform);
             _uiChooseCatMenu.CurrentChosenCat.transform.position = transform.position;
         }
     }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }

        if (_uiChooseCatMenu.CurrentChosenCat != null && ThisGridCellIsAvailable)
        {
            CatOnThisCell = _uiChooseCatMenu.CurrentChosenCat;
            
            CatOnThisCell.SetGridCell(this);
            CatOnThisCell.OnCatDeath += OnCatDeath;
          
            SushiManager.Instance.SubtractSushi(CatOnThisCell.CatDataSo.CatPrice);
            OnCatPlaced?.Invoke(this, EventArgs.Empty);
            
            ThisGridCellIsAvailable = false;
            GridManager.Instance.UpdateGrid();
            
            GridManager.Instance.MaximizePlacedCatsAlpha();
        }
        
    }

    private void OnCatDeath(object sender, EventArgs e)
    {
        ThisGridCellIsAvailable = true;
        GridManager.Instance.UpdateGrid();
        CatOnThisCell.OnCatDeath -= OnCatDeath;
    }

    public void FreeThisCell()
    {
        ThisGridCellIsAvailable = true;
        GridManager.Instance.UpdateGrid();
    }
    
}
