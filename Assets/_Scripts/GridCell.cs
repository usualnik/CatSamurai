using UnityEngine;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private bool _thisGridCellIsAvailable = true;
    [SerializeField] private UIChooseCatMenu _uiChooseCatMenu;
    [SerializeField] private GameManager _gameManager;
    
    private void Start()
    {
        _uiChooseCatMenu = GameObject.Find("UI_ChooseCatMenu").GetComponent<UIChooseCatMenu>();
        _gameManager = GameObject.Find("[GameManager]").GetComponent<GameManager>();
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
        
        if (_uiChooseCatMenu.CurrentChosenCat != null && _thisGridCellIsAvailable)
        {
            _uiChooseCatMenu.CurrentChosenCat.GetComponent<BaseCat>().SetPlaced(true);
            _uiChooseCatMenu.CurrentChosenCat.layer = gameObject.layer;
            
            // HERE IS NEEDS TO BE SOME KIND OF COOLDOWN LOGIC
            
            _gameManager.SubtractSushi(_uiChooseCatMenu.CurrentChosenCat.GetComponent<BaseCat>().CatDataSo.CatPrice);

            _uiChooseCatMenu.SetCurrentCat(null);
            _thisGridCellIsAvailable = false;
        }
        
    }
}
