using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    public List<int> deck = new List<int>();
    public int[] cardTypes;
    public TextMeshProUGUI deckCount;

    // Start is called before the first frame update
    void Start()
    {
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
        deckCount.text = ("" + deck.Count);
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
}
