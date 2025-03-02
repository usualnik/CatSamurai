using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CatSetupCell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool _isCatAvalibleToChoose = true;
    [SerializeField] private CatDataSO _catDataSo;
    
    private UI_CatSetupMenu _catSetupMenu;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        
    }

    private void Start()
    {
        _catSetupMenu = GetComponentInParent<UI_CatSetupMenu>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isCatAvalibleToChoose)
        {
            _image.rectTransform.localScale += new Vector3(0.1f,0.1f,0);
            _catSetupMenu.AddCatData(_catDataSo); // add this cat to list of chosen cats
            _isCatAvalibleToChoose = false;
            _catSetupMenu.SetCatToSetup();
        }
        else
        {
            _image.rectTransform.localScale -= new Vector3(0.1f,0.1f,0);
            _catSetupMenu.RemoveCatData(_catDataSo); // remove this cat from list of chosen cats
            _isCatAvalibleToChoose = true;
            _catSetupMenu.SetCatToSetup();
        }

    }
}
