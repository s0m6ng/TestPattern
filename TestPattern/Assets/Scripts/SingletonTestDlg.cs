using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonTestDlg : MonoBehaviour
{
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Text m_txtResult = null;

    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Ok()
    {
        GameManager.Inst().SetScore(200);
        m_txtResult.text = $"������ {GameManager.Inst().m_Score} �Դϴ�.";
        GameManager2.Inst.SetScore(1000);
        m_txtResult.text += $"������ {GameManager2.Inst.m_Score} �Դϴ�.";
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = string.Empty;
    }
}
