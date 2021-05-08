using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deck : MonoBehaviour
{
    public List<int> deck = new List<int>();
    public int[] cardTypes;
    public TextMeshProUGUI deckCount;

    public HUDManager HUDScript;
    public Text deck_Count;
    public Text count1;
    public Text count2;
    public Text count3;
    public Text count4;
    public Text count5;
    public Text count6;

    // Start is called before the first frame update
    void Start()
    {
        HUDScript = GameObject.Find("PlayerHUD").GetComponent<HUDManager>();

        for (int i = 0; i < cardTypes.Length; i++) //Add Starting Cards to deck
        {
            if (cardTypes[i] != 0)
            {
                for (int n = cardTypes[i]; n > 0; n--)
                {
                    deck.Add(i);
                }
            }
        }

        Shuffle();

    }

    // Update is called once per frame
    void Update()
    {
        if (HUDScript.onScreen)
        {
            deck_Count.text = "" + deck.Count;
            count1.text = "x " + CountCards(1);
            count2.text = "x " + CountCards(2);
            count3.text = "x " + CountCards(3);
            count4.text = "x " + CountCards(4);
            count5.text = "x " + CountCards(5);
            count6.text = "x " + CountCards(6);
        }
        else
        {
            deckCount.text = ("" + deck.Count);
        }
    }

    public void Shuffle() //Shuffles the Deck
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void AddCards(int cardType, int quantity) //Adds cards to the deck (doesn't shuffle in)
    {
        for (int i = 0; i < quantity; i++)
        {
            deck.Add(cardType);
        }
    }

    public void RemoveCards(int numberOfCards) //Removes cards from the top of the deck
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            deck.RemoveAt(i);
        }
    }

    int CountCards(int cardType)
    {
        int count = 0;
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i] == cardType)
            {
                count += 1;
            }
        }
        return count;
    }
}
