using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

    private static GameObject diceText;

    // Use this for initialization
    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        diceText = GameObject.Find("Dice Text");
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];

            diceText.GetComponent<Text>().text = (randomDiceSide+1).ToString();

            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        
        GameControl.MovePlayer();

        coroutineAllowed = true;
    }
}
