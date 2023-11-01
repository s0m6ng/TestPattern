using UnityEngine;
using UnityEngine.UI;

public class FSMTest2Dlg : MonoBehaviour
{
    public BattleFSM m_BattleFSM = new BattleFSM();

    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Button m_btnAttack = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtMonsterHP = null;
    [SerializeField] Text m_txtTime = null;
    float m_Timer = 0;
    int m_MonsterHP = 0;
    void Start()
    {
        m_BattleFSM.Initialize(Callback_kReady,
            Callback_kWave,
            Callback_kGame,
            Callback_kResult);
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_btnAttack.onClick.AddListener(OnClicked_Attack);
    }
    private void Update()
    {
        m_BattleFSM.OnUpdate();
        m_txtTime.text = $"Time : {m_Timer:0.0}";
        m_txtMonsterHP.text = $"Moster HP = {m_MonsterHP}";
        if (m_BattleFSM.IsGameState())
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= 10)
            {
                m_BattleFSM.SetResultState();
            }
        }
    }
    void Initialize()
    {
        m_Timer = 0;
        m_MonsterHP = 160;
    }
    private void OnClicked_Start()
    {
        m_BattleFSM.SetReadyState();
    }

    private void OnClicked_Stop()
    {
        m_BattleFSM.SetNoneState();
        Initialize();
    }

    private void OnClicked_Attack()
    {
        if (m_BattleFSM.IsGameState())
        {
            m_MonsterHP -= 1;
            if (m_MonsterHP <= 0)
            {
                m_BattleFSM.SetResultState();
            }
        }
    }
    void SetGameState()
    {
        m_BattleFSM.SetGameState();
    }
    private void Callback_kReady()
    {
        m_txtResult.text = "Ready";
        Invoke("SetGameState", 1f);
    }

    private void Callback_kGame()
    {
        Initialize();
        m_txtResult.text = "Game";
    }

    private void Callback_kWave()
    {
    }

    private void Callback_kResult()
    {
        m_txtResult.text = "Result ";
        if (m_MonsterHP <= 0)
            m_txtResult.text += "(½Â¸®)";
        else
            m_txtResult.text += "(ÆÐ¹è)";
    }
}
