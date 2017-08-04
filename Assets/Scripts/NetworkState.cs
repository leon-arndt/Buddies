/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

/// <summary>
/// Holds relevant game state information like spawned players and scores
/// </summary>
public class NetworkState : NetworkBehaviour
{
    public static NetworkState Singleton;

    [SerializeField]
    private Rigidbody m_Ball;
    [SerializeField]
    private Transform m_BallRespawn;

    [Space(10)]
    [SerializeField]
    private Text m_Team0ScoreText;
    [SerializeField]
    private Text m_Team1ScoreText;

    [SyncVar(hook = "UpdateTeamScore0")]
    private int m_Team0Score = 0;
    [SyncVar(hook = "UpdateTeamScore1")]
    private int m_Team1Score = 0;


    private List<CarUserControl> m_Players = new List<CarUserControl>();
    public Rigidbody Ball { get { return m_Ball; } }

    private Dictionary<int, TeamSpawn> m_TeamSpawns = new Dictionary<int, TeamSpawn>();

    public void RegisterTeamSpawn(int teamID, TeamSpawn spawn)
    {
        m_TeamSpawns.Add(teamID, spawn);
    }

    public void NotifyPlayerReady()
    {
        for (int i = 0; i < m_Players.Count; i++)
        {
            if (!m_Players[i].IsReady)
            {
                return;
            }
        }

        RpcStartGame();
    }

    private void UpdateTeamScore0(int score)
    {
        m_Team0Score = score;
        UpdateTeamScoreUI();
    }

    private void UpdateTeamScore1(int score)
    {
        m_Team1Score = score;
        UpdateTeamScoreUI();
    }

    private void UpdateTeamScoreUI()
    {
        m_Team0ScoreText.text = m_Team0Score.ToString();
        m_Team1ScoreText.text = m_Team1Score.ToString();
    }

    /// <summary>
    /// Gets executed on all clients (and the server as it is a client, too)
    /// </summary>
    [ClientRpc]
    private void RpcStartGame()
    {
        for (int i = 0; i < m_Players.Count; i++)
        {
            m_Players[i].GetComponent<Rigidbody>().isKinematic = false;
        }

        m_Ball.isKinematic = false;
    }

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        UpdateTeamScoreUI();
    }

    public void AddPlayer(CarUserControl Player)
    {
        m_Players.Add(Player);

        Player.SetTeamID(m_Players.Count % 2);
    }

    public void RemovePlayer(CarUserControl Player)
    {
        m_Players.Remove(Player);
    }

    public void GoalScored(int teamID)
    {
        if (teamID == 0)
        {
            m_Team0Score++;
        }
        else
        {
            m_Team1Score++;
        }

        ResetGame();
    }

    public void ResetGame()
    {
        for (int i = 0; i < m_Players.Count; i++)
        {
            m_Players[i].transform.position = m_TeamSpawns[m_Players[i].GetTeamID()].transform.position;
        }

        m_Ball.transform.position = m_BallRespawn.position;
        m_Ball.isKinematic = true;

        StartCoroutine(KeepBallInStasis(3));
    }

    private IEnumerator KeepBallInStasis(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        m_Ball.isKinematic = false;
    }
}
*/