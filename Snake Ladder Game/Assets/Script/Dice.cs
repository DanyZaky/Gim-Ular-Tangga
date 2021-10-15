using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

    private GameObject diceText;
    public GameControl _gc;
    public FollowThePath _fp;

    public int diceMin;
    public int diceMax;

    // Use this for initialization
    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        diceText = GameObject.Find("Dice Text");
    }

    //private void OnMouseDown()
    //{
    //    if (!_gc.isGameOver && coroutineAllowed)
    //        StartCoroutine(RollTheDice());
    //}

    public void ButtonAcakAngka()
    {
        if (!_gc.isGameOver && coroutineAllowed && !_fp.isMoveAllowed && !_fp.isForcedMove)
            StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(diceMin, diceMax);
            //rend.sprite = diceSides[randomDiceSide];

            diceText.GetComponent<Text>().text = (randomDiceSide).ToString();

            yield return new WaitForSeconds(0.05f);
        }

        _gc.diceSideThrown = randomDiceSide;
        
        _gc.MovePlayer();

        coroutineAllowed = true;
    }
}
