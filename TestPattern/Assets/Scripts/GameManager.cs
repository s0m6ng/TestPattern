using UnityEngine;

public class GameManager
{
    static GameManager _inst = null;
    public static GameManager Inst()
    {
        if (_inst == null)
        {
            _inst = new GameManager();
        }
        return _inst;
    }
    public int m_Score = 0;
    public void SetScore(int score)
    {
        m_Score += score;
    }
}

public class GameManager2
{
    static GameManager2 _inst = null;
    public static GameManager2 Inst
    {

        get
        {
            if (_inst == null)
                _inst = new GameManager2();

            return _inst;
        }
    }
    public int m_Score = 0;
    public void SetScore(int score)
    {
        m_Score += score;
    }
}
public class GameManager3 : MonoBehaviour
{
    static GameManager3 _inst = null;
    public static GameManager3 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject go = new GameObject("Singleton GameMgr");
                _inst = go.AddComponent<GameManager3>();
                DontDestroyOnLoad(go);
            }
            return _inst;
        }
    }
    private int m_Score = 100;
    public int GetScore() { return m_Score; }
    public void SetScore(int score) { m_Score = score; }

    public int score
    {
        get { return m_Score; }
        set { m_Score = value; }
    }
}

