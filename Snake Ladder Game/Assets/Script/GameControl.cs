using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour {

    private GameObject player;
    private FollowThePath _playerFollowPath;
    private SoalController _soalController;

    public Transform[] waypoints;
    public GameObject soalContainer, winWindow;
    public Petak currentCheckTile;
    public TextMeshProUGUI textPoints;
    public GameObject incorrectTile;
    public GameObject correctTile;
    public GameObject colorBoard;

    public int diceSideThrown = 0;
    public int playerStartWaypoint = 0;
    public int playerEndWaypoint = 0;
    public int points;

    public bool isGameOver = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        _playerFollowPath = player.GetComponent<FollowThePath>();
        _soalController = soalContainer.GetComponent<SoalController>();
        waypoints = _playerFollowPath.waypoints;
    }

    void Start ()
    {
        _playerFollowPath.isMoveAllowed = false;        
    }

    void Update()
    {
        MovementChecker();        
    }

    void MovementChecker()
    {
        textPoints.text = "Skor: " + points;
        playerEndWaypoint = playerStartWaypoint + diceSideThrown;
        if (playerEndWaypoint == 0)
        {
            diceSideThrown = 0;
        }
        else if (playerEndWaypoint >= waypoints.Length)
        {
            playerEndWaypoint = waypoints.Length;
            EndWaypoint();
            if (currentCheckTile.isAnswered && isGameOver)
            {
                CalculateStageClear();
            }
        }
        else
        {
            EndWaypoint();
        }
    }

    void EndWaypoint()
    {
        if (_playerFollowPath.transform.position == waypoints[playerEndWaypoint - 1].transform.position)
        {
            _playerFollowPath.isMoveAllowed = false;
            _playerFollowPath.isForcedMove = false;
            diceSideThrown = 0;
            playerStartWaypoint = playerEndWaypoint;
            currentCheckTile = waypoints[playerEndWaypoint - 1].GetComponent<Petak>();
            CheckSoal();
        }
    }

    public void CheckTile()
    {
        if (currentCheckTile.isLadder && currentCheckTile.isAnswerCorrect && currentCheckTile.isAnswered)
        {
            ForceMovePlayer(currentCheckTile.destinationIndex);
        }
        if (currentCheckTile.isSnake && !currentCheckTile.isAnswerCorrect && currentCheckTile.isAnswered)
        {
            ForceMovePlayer(currentCheckTile.destinationIndex);
        }
    }

    void CheckSoal()
    {
        if (!currentCheckTile.isAnswered && (!_playerFollowPath.isForcedMove && !_playerFollowPath.isMoveAllowed) &&
            !_playerFollowPath.wasForcedMove)
        {
            soalContainer.SetActive(true);
            _soalController.GetSoal();
        }
        else
        {
            CheckTile();
        }
    }

    public void ColorBoard(bool answer)
    {
        if (answer)
        {
            Instantiate(correctTile, currentCheckTile.transform.position, Quaternion.identity, colorBoard.transform);
        }
        else
        {
            Instantiate(incorrectTile, currentCheckTile.transform.position, Quaternion.identity, colorBoard.transform);
        }    
    }

    public void MovePlayer()
    {
        _playerFollowPath.isMoveAllowed = true;
        _playerFollowPath.wasForcedMove = false;
    }

    public void ForceMovePlayer(int destination)
    {
        _playerFollowPath.isForcedMove = true;
        _playerFollowPath.wasForcedMove = true;
        diceSideThrown = 0;
        _playerFollowPath.currentDestinationIndex = destination;
        _playerFollowPath.currentWaypointIndex = destination;
        playerStartWaypoint = destination;
        playerEndWaypoint = destination;
    }

    void CalculateStageClear()
    {
        winWindow.SetActive(true);
        isGameOver = true;
    }
}
