using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest3Dlg : MonoBehaviour
{
    BattleFSM m_BattleFSM = new BattleFSM();
    public Button m_btnStart;
    public Button m_btnStop;
    public Text m_txtKey;
    public Text m_txtResult;
    public Text m_txtScore;
    public Text m_txtTime;
    public Text m_txtCheck;
    public Text m_txtHp;
    int m_key;
    int m_lastkey;
    int m_score;
    int m_hp;
    float m_maxTime = 10;
    float m_curTime;

    private void Awake()
    {
        m_BattleFSM.Initialize(OnCallBack_Ready,
            OnCallBack_Wave,
            OnCallBack_Game,
            OnCallBack_Result);
    }
    private void Start()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        Initialize();
    }
    private void Update()
    {
        if (m_BattleFSM != null)
        {
            m_BattleFSM.OnUpdate();
        }
        m_txtScore.text = $"score = {m_score}";
        m_txtKey.text = $"키 : {(m_key == -1 ? "?" : m_key)}";
        m_txtTime.text = $"time : {m_curTime:F1}";
        m_txtHp.text = $"목숨 : {m_hp}";
        if (m_BattleFSM.IsGameState())
        {
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    if (m_key == i)
                    {
                        m_score += 10;
                        m_txtCheck.text = "<color=#03fc84>정답</color>";
                    }
                    else
                    {
                        m_txtCheck.text = "<color=#f27668>오답</color>";
                        m_hp--;
                        if (m_hp <= 0)
                        {
                            m_BattleFSM.SetResultState();
                            return;
                        }
                    }
                    m_BattleFSM.SetWaveState();
                    break;
                }
            }
        }
        if (m_BattleFSM.IsNoneState())
        {
            m_txtCheck.text = "게임 대기중 ...";
        }
    }
    public void Initialize()
    {
        m_BattleFSM.SetNoneState();
        m_txtResult.text = "상태";
        m_key = -1;
        m_lastkey = m_key;
        m_score = 0;
        m_curTime = m_maxTime;
        m_hp = 3;
    }
    public void OnCallBack_Ready()
    {
        m_txtResult.text = "Ready";
        StartCoroutine(EnumGameState());
    }
    public void OnCallBack_Wave()
    {
        m_txtResult.text = "Wave";
        StartCoroutine(EnumGameState());
    }
    public void OnCallBack_Game()
    {
        m_txtCheck.text = "입력 대기중 ...";
        m_txtResult.text = "Game";
        StartCoroutine(EnumTime());
        while (m_key == m_lastkey)
            m_key = Random.Range(0, 10);
        m_lastkey = m_key;
    }
    public void OnCallBack_Result()
    {
        m_txtResult.text = $"게임 결과 : {m_score}점";
    }
    public void OnClicked_Start()
    {
        if (m_BattleFSM.IsNoneState() || m_BattleFSM.IsResultState())
        {
            Initialize();
            m_BattleFSM.SetReadyState();
        }
    }
    public void OnClicked_Stop()
    {
        Initialize();
        StopAllCoroutines();
        m_BattleFSM.SetNoneState();
    }
    IEnumerator EnumGameState()
    {
        yield return new WaitForSeconds(1);
        m_BattleFSM.SetGameState();
    }
    IEnumerator EnumTime()
    {
        while (m_BattleFSM.IsGameState())
        {
            yield return new WaitForSeconds(0.1f);
            m_curTime -= 0.1f;
            if (m_curTime <= 0)
            {
                m_BattleFSM.SetResultState();
                yield break;
            }
        }
    }
}
