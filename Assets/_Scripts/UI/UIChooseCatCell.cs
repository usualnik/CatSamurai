using UnityEngine;
using UnityEngine.EventSystems;


public class UIChooseCatCell : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] public CatDataSO Cat;
   [SerializeField] private GameManager _gameManager;
   
   private UIChooseCatMenu _uiChooseCatMenu;
   private GameObject _catPrefab;

   private void Start()
   {
      _uiChooseCatMenu = GetComponentInParent<UIChooseCatMenu>();
   }


   public void OnPointerClick(PointerEventData eventData)
   {
      if (!_catPrefab)
      {
         if (_gameManager.Sushi >= Cat.CatPrice)
         {
            GameObject currentCat = Instantiate(Cat.CatPrefab, Vector3.zero, Quaternion.identity);
            _uiChooseCatMenu.SetCurrentCat(currentCat);
         }
         else
         {
            Debug.Log("You need more money for that");
         }
         
      }
      else
      { 
         Debug.Log("There is already one copy of this prefab"); // ???????????
      }
      
   }   

}
