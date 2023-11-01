using System;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest2Dlg : MonoBehaviour
{
    [SerializeField] DelegateItem2[] m_items = null;
    [SerializeField] Button m_BtnOk = null;
    [SerializeField] Button m_BtnClear = null;
    [SerializeField] Text m_txtResult = null;
    DelegateItem2 m_SelectedItem = null;
    void Start()
    {
        for (int i = 0; i < m_items.Length; i++)
        {
            m_items[i].OnAddListner(OnCallback_TextItem);
        }
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
    }

    public void Initialize()
    {
    }
    private void OnClicked_Ok()
    {
        if (m_SelectedItem == null)
            m_txtResult.text = $"선택한 도시가 없습니다";
        else
            m_txtResult.text = $"선택한 도시는 {m_SelectedItem.m_txtName.text}입니다.";
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = "결과";
        ClearAllSelectitem();
    }

    void OnCallback_TextItem(DelegateItem2 kItem, bool bSelect)
    {
        ClearAllSelectitem();
        if (bSelect)
        {
            m_SelectedItem = kItem;
            m_txtResult.text = kItem.m_txtName.text;
            kItem.m_imgImage.color = Color.green;
        }

    }

    private void ClearAllSelectitem()
    {
        m_SelectedItem = null;
        for (int i = 0; i < m_items.Length; i++)
        {
            m_items[i].m_imgImage.color = Color.white;
        }
    }
}
