using UnityEngine;
using UnityEngine.UI;

public class DelegateItem2 : MonoBehaviour
{
    public delegate void DelegateFunc(DelegateItem2 kItem, bool bSelect);
    public DelegateFunc OnSelectedFunc = null;

    public Text m_txtName = null;
    public Image m_imgImage = null;

    Button m_btnSelect = null;
    Color m_OriColor = Color.white;
    private void Awake()
    {
        m_imgImage = GetComponent<Image>();
        m_btnSelect = GetComponent<Button>();
    }
    void Start()
    {
        m_btnSelect.onClick.AddListener(OnClicked_Select);
    }
    public void OnClicked_Select()
    {
        if (OnSelectedFunc != null)
        {
            OnSelectedFunc(this, true);
        }
    }
    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }
}
