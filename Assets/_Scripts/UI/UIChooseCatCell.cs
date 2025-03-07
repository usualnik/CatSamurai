using UnityEngine;
using UnityEngine.EventSystems;

public class UIChooseCatCell : MonoBehaviour, IPointerClickHandler
{
   public CatDataSO Cat;
   
   [SerializeField] private Transform _uiChooseCatMenuTransform;

   private UIChooseCatMenu _uiChooseCatMenu;
   
   private float _cooldownTime = 5f;
   private bool _isOnCooldown;

   private void Update()
   {
      if (_isOnCooldown)
      {
         gameObject.transform.SetParent(null); // Hide the Object
         
         _cooldownTime -= Time.deltaTime;
         if ((_cooldownTime <= 0))
         {
            gameObject.transform.SetParent(_uiChooseCatMenuTransform); // Show the object
            _isOnCooldown = false;
            _cooldownTime = 2f;
         }
      }
   }

   private void Start()
   {
      _uiChooseCatMenu = GetComponentInParent<UIChooseCatMenu>();
   }
   
   public void OnPointerClick(PointerEventData eventData)
   {
      if (GameManager.Instance.Sushi >= Cat.CatPrice)
      {
         GameObject currentCat = Instantiate(Cat.CatPrefab, Vector3.zero, Quaternion.identity);
         _uiChooseCatMenu.SetCurrentUIChooseCatCell(this);
         _uiChooseCatMenu.SetCurrentCat(currentCat);
         
         GridManager.Instance.ShowGridUpdated();
      }
      else
      {
         Debug.Log("You need more money for that");
      }

   }

   public void SetCellOnCooldown(bool isOnCooldown)
   {
      _isOnCooldown = isOnCooldown;
   }
}
