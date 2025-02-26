using UnityEngine;
using UnityEngine.EventSystems;


public class UI_ChooseCatCell : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] public CatDataSO Cat;
   [SerializeField] private RectTransform _canvasTransform;
   [SerializeField] private GameManager _gameManager;
   
   
   private UI_ChooseCatMenu _uiChooseCatMenu;
   
   private GameObject _catPrefab;


   private void Start()
   {
      _uiChooseCatMenu = GetComponentInParent<UI_ChooseCatMenu>();
   }


   public void OnPointerClick(PointerEventData eventData)
   {
      if (!_catPrefab)
      {
         if (_gameManager.Sushi >= Cat.CatPrice)
         {
            _uiChooseCatMenu.CurrentChosenCat = Instantiate(Cat.CatPrefab, Vector3.zero - new Vector3(500, 0, 0), Quaternion.identity, _canvasTransform);
            _uiChooseCatMenu.CurrentUIChooseCatCell = this.gameObject;
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
