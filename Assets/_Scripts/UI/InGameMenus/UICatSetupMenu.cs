using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class UICatSetupMenu : MonoBehaviour
{
   public static UICatSetupMenu Instance { get; private set; }
   public event EventHandler OnCatSetupApproved;
   
   [SerializeField] private List<CatDataSO> _chosenCatsData;
   [SerializeField] private TextMeshProUGUI _catsAvailableText;
   [SerializeField] private UIChooseCatMenu _chooseCatMenu;
   
   [SerializeField] private  int _maxCatsAvailable;
   private int _catsAvailable;

   private void Awake()
   {
      Instance = this;
      _catsAvailable = _maxCatsAvailable;
      if (YG2.envir.language == "ru")
      {
         _catsAvailableText.text = "КОТОВ ДОСТУПНО : " + _catsAvailable;
      }
      else
      {
         _catsAvailableText.text = "CATS AVAILABLE : " + _catsAvailable;
      }
      
   }

   public void SetCatToSetup()
   {
      _catsAvailable--;
      if (YG2.envir.language == "ru")
      {
         _catsAvailableText.text = "КОТОВ ДОСТУПНО : " + _catsAvailable;
      }
      else
      {
         _catsAvailableText.text = "CATS AVAILABLE : " + _catsAvailable;
      }
   }
   
   public void RemoveCatFromSetup()
   {
      _catsAvailable++;
      
      if (YG2.envir.language == "ru")
      {
         _catsAvailableText.text = "КОТОВ ДОСТУПНО : " + _catsAvailable;
      }
      else
      {
         _catsAvailableText.text = "CATS AVAILABLE : " + _catsAvailable;
      }
   }

   private void SendCatData()
   {
      if (_catsAvailable == 0)
      {
         _chooseCatMenu.RetrieveCatData(_chosenCatsData);
         HideMenu();
         OnCatSetupApproved?.Invoke(this, EventArgs.Empty);
      }
   }

   public void AddCatData(CatDataSO catDataSo)
   {
      if (_chosenCatsData.Count < _maxCatsAvailable)
      {
         _chosenCatsData.Add(catDataSo);
      }
      
   }
   public void RemoveCatData(CatDataSO catDataSo)
   {
      _chosenCatsData.Remove(catDataSo);
   }


   private void HideMenu()
   {
      gameObject.SetActive(false);
   }

   public int GetAvailableCats()
   {
      return _catsAvailable;
   }
}
