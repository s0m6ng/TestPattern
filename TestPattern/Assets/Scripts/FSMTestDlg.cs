using UnityEngine;
using UnityEngine.UI;

public class FSMTestDlg : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Button m_btnAttack = null;
    [Header("Text")]
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtHp = null;
    [SerializeField] Text m_txtTime = null;

    int m_Mode = 0;
    int m_MonsterHp = 0;
    float m_curTime = 0;
    float m_Timer = 0;
    bool m_IsStart = false;
    void Start()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_btnAttack.onClick.AddListener(OnClicked_Attack);
    }
    void Initialize()
    {
        m_Mode = 0;
        m_MonsterHp = 100;
        m_curTime = 10;
        m_txtResult.text = "State Result";
    }
    private void Update()
    {
        if (m_IsStart)
        {
            m_txtHp.text = $"Monster HP : {m_MonsterHp}";
            m_txtTime.text = $"Time : {m_curTime:0.0}";
            if (m_Mode == 0)
            {
                m_txtResult.text = "Ready";
                m_Timer += Time.deltaTime;
                if (m_Timer > 1)
                {
                    m_Mode = 1;
                    m_Timer = 0;
                }
            }
            if (m_Mode == 1)
            {
                m_txtResult.text = "Game";
                m_curTime = Mathf.Max(m_curTime - Time.deltaTime, 0);
                if (m_curTime <= 0)
                {
                    m_Mode = 2;
                }
            }

            if (m_Mode == 2)
            {
                if (m_curTime > 0)
                {
                    m_txtResult.text = "Result (½Â¸®)";
                }
                else
                {
                    m_txtResult.text = "Result (ÆÐ¹è)";
                }
            }
        }
    }

    private void OnClicked_Start()
    {
        m_IsStart = true;
        Initialize();
    }

    private void OnClicked_Stop()
    {
        m_IsStart = false;
        Initialize();
    }

    private void OnClicked_Attack()
    {
        if (m_Mode == 1 && m_IsStart)
        {
            m_MonsterHp -= 1;
            if (m_MonsterHp <= 0)
            {
                m_Mode = 2;
            }
        }
    }
}
