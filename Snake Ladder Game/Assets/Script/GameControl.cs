using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject winText, player;
    public GameObject soalContainer;

    public static int diceSideThrown = 0;
    public static int playerStartWaypoint = 0;

    public static bool gameOver = false;

    void Start ()
    {
        winText = GameObject.Find("WinText");
        player = GameObject.Find("Player");

        player.GetComponent<FollowThePath>().moveAllowed = false;
    }

    void Update()
    {
        if (player.GetComponent<FollowThePath>().waypointIndex > playerStartWaypoint + diceSideThrown)
        {
            player.GetComponent<FollowThePath>().moveAllowed = false;
            playerStartWaypoint = player.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        //WIN CONDITION
        if (player.GetComponent<FollowThePath>().waypointIndex == player.GetComponent<FollowThePath>().waypoints.Length)
        {
            winText.GetComponent<Text>().text = "Kamu Menang";
            gameOver = true;
        }

        //SOAL CONTROLLER
        if (player.GetComponent<FollowThePath>().waypointIndex == 7)
        {
            soalContainer.SetActive(true);
        }
    }

    public static void MovePlayer()
    {
        player.GetComponent<FollowThePath>().moveAllowed = true;
    }

    public void isPencetTrue()
    {
        soalContainer.SetActive(false);
    }
}
