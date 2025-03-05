using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIChooseCatMenu : MonoBehaviour
{
  public GameObject CurrentChosenCat { get; private set; }
  public CatDataSO CurrentChosenCatDataSo { get; private set; }
  
  [SerializeField] public List<CatDataSO> _catsData;
  [SerializeField] private GameObject[] _catsImages;
  [SerializeField] private GameManager _gameManager;


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
  
  public void RetriveCatData(List<CatDataSO> catData)
  {
    _catsData = catData;
    ShowCatData();
  }

  public void SetCurrentCat(GameObject currentChosenCat)
  {
    CurrentChosenCat = currentChosenCat;
  }
  
  
  
  public void SetCurrentCatDataSO(CatDataSO currentCatDataSo)
  {
    CurrentChosenCatDataSo = currentCatDataSo;
  }





  
}
