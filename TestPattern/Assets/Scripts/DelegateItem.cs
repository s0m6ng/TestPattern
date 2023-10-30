using UnityEngine;
using UnityEngine.UI;

public class DelegateItem : MonoBehaviour
{
    public delegate void DelegateFunc(DelegateItem kItem, bool bSelect);
    public DelegateFunc OnSelectedFunc = null;

    [SerializeField] Text m_txtName = null;
    [SerializeField] Image m_imgImage = null;

    Button m_btnSelect = null;
    Color m_OriColor = Color.white;
    void Start()
    {

    }
    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }
}
