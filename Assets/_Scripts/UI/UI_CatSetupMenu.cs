using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CatSetupMenu : MonoBehaviour
{
   [SerializeField] private List<CatDataSO> _chosenCatsData;
   [SerializeField] private TextMeshProUGUI _catsAvailableText;
   [SerializeField] private UI_ChooseCatMenu _chooseCatMenu;
   
   private int _maxCatsAvailable = 3;
   private int _chosenCats;
   
   public void SetCatToSetup()
   {
      if (_chosenCats <= _maxCatsAvailable)
      {
         _chosenCats++;
      }else if (_chosenCats >= 0)
      {
         _chosenCats--;
      }

      _catsAvailableText.text = "Котов доступно : " + (_maxCatsAvailable - _chosenCats);
   }

   private void SendCatData()
   {
      if (_chosenCats == _maxCatsAvailable)
      {
         _chooseCatMenu.RetriveCatData(_chosenCatsData);
         HideMenu();
      }
      else
      {
         Debug.Log("Выберите всех котов");
      }
   }

   public void AddCatData(CatDataSO catDataSo)
   {
      _chosenCatsData.Add(catDataSo);
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
