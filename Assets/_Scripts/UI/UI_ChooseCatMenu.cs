using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseCatMenu : MonoBehaviour
{
  public GameObject CurrentChosenCat;
  public GameObject CurrentUIChooseCatCell;
  

  [SerializeField] public List<CatDataSO> _catsData;

  [SerializeField] private GameObject[] _catsImages;

  [SerializeField] private GameManager _gameManager;

  private float _catChooseCooldownTime = 2f;
  private bool _isOnCoolDown;
  
  public void RetriveCatData(List<CatDataSO> catData)
  {
    _catsData = catData;
    ShowCatData();
  }

  public void OnCatSuccessfullyPlaced()
  {
    StartCoroutine(PlaceCatCooldown());
  }

  private IEnumerator PlaceCatCooldown()
  {
    CurrentUIChooseCatCell.SetActive(false);
    yield return new WaitForSeconds(_catChooseCooldownTime);
    CurrentUIChooseCatCell.SetActive(true);
  }
  

  private void ShowCatData()
  {
    for (int i = 0; i < _catsImages.Length; i++)
    {
      if (i < _catsData.Count)
      {
         _catsImages[i].GetComponent<Image>().sprite = _catsData[i].UISprite;
         _catsImages[i].GetComponent<UI_ChooseCatCell>().Cat = _catsData[i];

         _catsImages[i].GetComponentInChildren<TextMeshProUGUI>().text = _catsData[i].CatPrice.ToString();
      }
    }
  }

  
  
  
  
}
