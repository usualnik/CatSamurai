using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIChooseCatMenu : MonoBehaviour
{
  public static UIChooseCatMenu Instance { get; private set; }

  public BaseCat CurrentChosenCat { get; private set; }
 
  [SerializeField] public List<CatDataSO> _catsData;
  [SerializeField] private GameObject[] _catsImages;
  [SerializeField] private GameObject _notEnoughSushiAnim;

  private UIChooseCatCell _uiChooseCatCell;
  private GridCell[] _gridCells;


  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    _gridCells = GridManager.Instance.GetAllCellsArray();
    foreach (var gridCell in _gridCells)
    {
      gridCell.OnCatPlaced += GridCellOnOnCatPlaced;
    }
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
    {
      DeleteCurrentCat();
    }
  }

  private void OnDestroy()
  {
    _gridCells = GridManager.Instance.GetAllCellsArray();
    foreach (var gridCell in _gridCells)
    {
      gridCell.OnCatPlaced -= GridCellOnOnCatPlaced;
    }
  }

  private void GridCellOnOnCatPlaced(object sender, EventArgs e)
  {
    GridCell gridCell = sender as GridCell;
    CurrentChosenCat.gameObject.layer = gridCell.gameObject.layer;
    CurrentChosenCat.GetComponent<BaseCat>().SetPlaced(true);
    StartUIChooseCatCellCooldown();
    SetCurrentCat(null);
  }

  private void ShowCatData()
  {
    for (int i = 0; i < _catsImages.Length; i++)
    {
      if (i < _catsData.Count)
      {
        _catsImages[i].GetComponent<Image>().sprite = _catsData[i].UISprite;
        _catsImages[i].GetComponent<UIChooseCatCell>().Cat = _catsData[i];

        _catsImages[i].GetComponentInChildren<TextMeshProUGUI>().text = _catsData[i].CatPrice.ToString();
      }
    }
  }
  
  public void RetrieveCatData(List<CatDataSO> catData)
  {
    _catsData = catData;
    ShowCatData();
  }

  public void SetCurrentCat(BaseCat currentChosenCat)
  {
    CurrentChosenCat = currentChosenCat;
  }
  
  public void SetCurrentUIChooseCatCell(UIChooseCatCell uiChooseCatCell)
  {
    _uiChooseCatCell = uiChooseCatCell;
  }

  private void StartUIChooseCatCellCooldown()
  {
    _uiChooseCatCell.SetCellOnCooldown(true);
  }

  public void DeleteCurrentCat()
  {
    Destroy(CurrentChosenCat?.gameObject);
    
  }

  public void NotEnoughSushiToBuyCat()
  {
    SFX.Instance.PlayErrorSound();
    _notEnoughSushiAnim.SetActive(true);
    StartCoroutine(WaitForNotEnoughSushiAnim());
  }

  private IEnumerator WaitForNotEnoughSushiAnim()
  {
    yield return new WaitForSeconds(0.2f);
    _notEnoughSushiAnim.SetActive(false);
  }
 
}
