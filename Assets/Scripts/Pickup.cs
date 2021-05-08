using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pickupType;
    public int amount; // amount (coins), quantity (cards)
    public bool selected;

    public Deck deckScript;
    public CoinManager coinScript;

    /* Pickup Types:
        0 = Coins;
        1 = Cards;
    */

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GameObject.Find("Deck").GetComponent<Deck>();
        coinScript = GameObject.Find("Coin").GetComponent<CoinManager>();
        selected = false;

        float r = Random.Range(0, 359);
        transform.Rotate(0, 0, r);

        RandomAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && selected)
        {
            Get();
        }
    }

    void RandomAmount()
    {
        if (pickupType == 0)
        {
            amount = Random.Range(10, 50);
        }

        if (pickupType == 1)
        {
            amount = Random.Range(2, 5);
        }
    }

    public void Get()
    {
        if (pickupType == 0)
        {
            coinScript.coins += amount;
        }

        if (pickupType == 1)
        {
            for (int c = 0; c < amount; c++)
            {
                int q = Random.Range(1, 3); //chance to get Bullet or other card
                int r = Random.Range(2, 7); //if getting other card, which card to get
                if (q == 2)
                {
                    deckScript.AddCards(r, 1);
                }
                else deckScript.AddCards(1, 1);
            }
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") == true)
        {
            selected = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") == true)
        {
            selected = false;
        }
    }


}
