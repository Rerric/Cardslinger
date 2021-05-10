using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public float price;
    public int item;
    public GameObject buyText;
    public GameObject buyTextLit;
    public bool isSelected;

    public GameObject cursor;
    public CoinManager coinScript;
    public Deck deckScript;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        coinScript = GameObject.Find("Coin").GetComponent<CoinManager>();
        deckScript = GameObject.Find("Deck").GetComponent<Deck>();
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(cursor.transform.position, transform.position);
        if (distance <= 1.5)
        {
            isSelected = true;
        }
        else isSelected = false;

        if (isSelected)
        {
            buyTextLit.SetActive(true);
            buyText.SetActive(false);

            if (Input.GetMouseButtonDown(0))
            {
                if (coinScript.coins >= price)
                {
                    coinScript.coins -= price;
                    deckScript.AddCards(item, 1);
                }
            }

        }
        else
        {
            buyTextLit.SetActive(false);
            buyText.SetActive(true);
        }
    }
 
}
