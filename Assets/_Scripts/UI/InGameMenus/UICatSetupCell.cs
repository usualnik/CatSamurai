using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICatSetupCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool _isCatAvalibleToChoose = true;
    [SerializeField] private CatDataSO _catDataSo;
    
    private UICatSetupMenu _catSetupMenu;
    private Image _image;
    private readonly Vector3 _selectedScale = new Vector3(0.1f,0.1f,0);

    private void Awake()
    {
        _image = GetComponent<Image>();
        
    }

    private void Start()
    {
        _catSetupMenu = GetComponentInParent<UICatSetupMenu>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }
        
        if (_isCatAvalibleToChoose && _catSetupMenu.GetAvailableCats() > 0)
        {
            _image.rectTransform.localScale += _selectedScale;
            _catSetupMenu.AddCatData(_catDataSo); // add this cat to list of chosen cats
            _isCatAvalibleToChoose = false;
            _catSetupMenu.SetCatToSetup();
        }
        else if (!_isCatAvalibleToChoose)
        {
            _image.rectTransform.localScale -= new Vector3(0.1f,0.1f,0);
            _catSetupMenu.RemoveCatData(_catDataSo); // remove this cat from list of chosen cats
            _isCatAvalibleToChoose = true;
            _catSetupMenu.RemoveCatFromSetup();
        }
        
    }
}
