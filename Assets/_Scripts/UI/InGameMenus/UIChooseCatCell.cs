using UnityEngine;
using UnityEngine.EventSystems;

public class UIChooseCatCell : MonoBehaviour, IPointerClickHandler
{
   public CatDataSO Cat;
   
   [SerializeField] private Transform _uiChooseCatMenuTransform;

   private UIChooseCatMenu _uiChooseCatMenu;
   
   private float _cooldownTime = 10f;
   private bool _isOnCooldown;

   private const float MAX_COOLDOWN_TIME = 10f;

   private void Update()
   {
      if (_isOnCooldown)
      {
         gameObject.transform.SetParent(null); // Hide the Object
         
         _cooldownTime -= Time.deltaTime;
         if (_cooldownTime <= 0)
         {
            gameObject.transform.SetParent(_uiChooseCatMenuTransform); // Show the object
            _isOnCooldown = false;
            _cooldownTime = MAX_COOLDOWN_TIME;
         }
      }
   }

   private void Start()
   {
      _uiChooseCatMenu = GetComponentInParent<UIChooseCatMenu>();
   }
   
   public void OnPointerClick(PointerEventData eventData)
   {
      if (SushiManager.Instance.GetSushiAmount() >= Cat.CatPrice && !UIChooseCatMenu.Instance.CurrentChosenCat)
      {
         GameObject currentCat = Instantiate(Cat.CatPrefab, Vector3.zero, Quaternion.identity);
         _uiChooseCatMenu.SetCurrentUIChooseCatCell(this);
         _uiChooseCatMenu.SetCurrentCat(currentCat.GetComponent<BaseCat>());
         
         GridManager.Instance.UpdateGrid();
         GridManager.Instance.MinimizePlacedCatsAlpha();
      }
      
   }

   public void SetCellOnCooldown(bool isOnCooldown)
   {
      _isOnCooldown = isOnCooldown;
   }
}
