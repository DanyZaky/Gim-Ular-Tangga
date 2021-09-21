using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

    private GameObject diceText;
    public GameControl _gc;

    // Use this for initialization
    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        diceText = GameObject.Find("Dice Text");
    }

    private void OnMouseDown()
    {
        if (!_gc.gameOver && coroutineAllowed)
            StartCoroutine(RollTheDice());
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

        _gc.diceSideThrown = randomDiceSide + 1;
        
        _gc.MovePlayer();

        coroutineAllowed = true;
    }
}
