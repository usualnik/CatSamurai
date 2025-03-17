using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICatSetupMenu : MonoBehaviour
{
   public static UICatSetupMenu Instance { get; private set; }
   public event EventHandler OnCatSetupApproved;
   public int _catsAvailable { get; private set; }= 5;
   
   [SerializeField] private List<CatDataSO> _chosenCatsData;
   [SerializeField] private TextMeshProUGUI _catsAvailableText;
   [SerializeField] private UIChooseCatMenu _chooseCatMenu;
   
   private const int MAXCatsAvailable = 5;

   private void Awake()
   {
      Instance = this;
   }

   public void SetCatToSetup()
   {
      _catsAvailable--;
      _catsAvailableText.text = "Котов доступно : " + _catsAvailable;
   }
   
   public void RemoveCatFromSetup()
   {
      _catsAvailable++;
      _catsAvailableText.text = "Котов доступно : " + _catsAvailable;
   }

   private void SendCatData()
   {
      if (_catsAvailable == 0)
      {
         _chooseCatMenu.RetrieveCatData(_chosenCatsData);
         HideMenu();
         OnCatSetupApproved?.Invoke(this, EventArgs.Empty);
      }
      else
      {
         Debug.Log("Выберите всех котов");
      }
   }

   public void AddCatData(CatDataSO catDataSo)
   {
      if (_chosenCatsData.Count < MAXCatsAvailable)
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
}
