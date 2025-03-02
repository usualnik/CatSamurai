using UnityEngine;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private bool _thisGridCellIsAvailable = true;
   
    [SerializeField] private UI_ChooseCatMenu _uiChooseCatMenu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _uiChooseCatMenu = GameObject.Find("UI_ChooseCatMenu").GetComponent<UI_ChooseCatMenu>();
        _gameManager = GameObject.Find("[GameManager]").GetComponent<GameManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_uiChooseCatMenu.CurrentChosenCat != null)
        {
            _uiChooseCatMenu.CurrentChosenCat.transform.SetParent(transform);
            _uiChooseCatMenu.CurrentChosenCat.transform.position = transform.position;
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_uiChooseCatMenu.CurrentChosenCat != null)
        {
            _uiChooseCatMenu.CurrentChosenCat.transform.SetParent(null);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_uiChooseCatMenu.CurrentChosenCat != null && _thisGridCellIsAvailable)
        {
            _uiChooseCatMenu.CurrentChosenCat.GetComponent<BaseCat>().IsPlaced = true;
            _uiChooseCatMenu.CurrentChosenCat.layer = gameObject.layer; 
            _gameManager.SubtractSushi(_uiChooseCatMenu.CurrentChosenCat.GetComponent<BaseCat>().CatDataSo.CatPrice);
            _uiChooseCatMenu.CurrentChosenCat.transform.position = transform.position;
            _uiChooseCatMenu.OnCatSuccessfullyPlaced();
            
            _uiChooseCatMenu.CurrentChosenCat = null;
            _thisGridCellIsAvailable = false;
        }
        
    }
}
