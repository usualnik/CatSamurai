using UnityEngine;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   
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
        if (_uiChooseCatMenu.CurrentChosenCat != null)
        {
            _uiChooseCatMenu.CurrentChosenCat.GetComponent<Cat>().IsPlaced = true;
            _gameManager.SubtractSushi(_uiChooseCatMenu.CurrentChosenCat.GetComponent<Cat>().CatDataSo.CatPrice);
            _uiChooseCatMenu.CurrentChosenCat.transform.position = transform.position;
            _uiChooseCatMenu.OnCatSuccessfullyPlaced();
            
            _uiChooseCatMenu.CurrentChosenCat = null;
        }
        
    }
}
