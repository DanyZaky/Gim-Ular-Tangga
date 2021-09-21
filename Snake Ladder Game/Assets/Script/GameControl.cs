using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private GameObject winText, player;
    private FollowThePath _playerFollowPath;
    public GameObject soalContainer;

    public int diceSideThrown = 0;
    public int playerStartWaypoint = 0;

    public bool gameOver = false;

    private void Awake()
    {
        winText = GameObject.Find("WinText");
        player = GameObject.Find("Player");
        _playerFollowPath = player.GetComponent<FollowThePath>();        
    }

    void Start ()
    {
        _playerFollowPath.moveAllowed = false;
    }

    void Update()
    {
        if (_playerFollowPath.waypointIndex > playerStartWaypoint + diceSideThrown)
        {
            _playerFollowPath.moveAllowed = false;
            playerStartWaypoint = _playerFollowPath.waypointIndex - 1;
        }

        //WIN CONDITION
        if (_playerFollowPath.waypointIndex == _playerFollowPath.waypoints.Length)
        {
            winText.GetComponent<Text>().text = "Kamu Menang";
            gameOver = true;
        }

        //SOAL CONTROLLER
        if (_playerFollowPath.waypointIndex == 7)
        {
            soalContainer.SetActive(true);
        }
    }

    public void MovePlayer()
    {
        _playerFollowPath.moveAllowed = true;
    }

    public void isPencetTrue()
    {
        soalContainer.SetActive(false);
    }
}
