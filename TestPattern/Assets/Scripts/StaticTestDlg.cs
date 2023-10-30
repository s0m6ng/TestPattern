using UnityEngine;
using UnityEngine.UI;

public class StaticTestDlg : MonoBehaviour
{
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Text m_txtResult = null;
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }
    void Initialize()
    {
        m_txtResult.text = string.Empty;
        StaticTestScore.m_Total = 0;
    }

    private void OnClicked_Ok()
    {
        Initialize();
        m_txtResult.text = string.Empty;
        StaticTestScore kim = new StaticTestScore(90);
        PrintScore(kim);
        StaticTestScore park = new StaticTestScore(80);
        PrintScore(park);
        StaticTestScore moon = new StaticTestScore(95);
        PrintScore(moon);
    }
    private void PrintScore(StaticTestScore user)
    {
        m_txtResult.text += $"Score = {user.m_Score}, Total = {StaticTestScore.m_Total}\n";
    }

    private void OnClicked_Clear()
    {
        Initialize();
    }
}
public class StaticTestScore
{
    public int m_Score = 0;
    public static int m_Total = 0;
    public StaticTestScore(int score)
    {
        m_Score = score;
        m_Total += score;
    }
}
