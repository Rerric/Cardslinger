﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<int> deck = new List<int>();
    public int[] cardTypes;

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
        
    }

    void Shuffle() //Shuffles the Deck
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void AddCards(int cardType, int quantity) //Adds cards to the deck (doesn't shuffle in)
    {
        for (int i = 0; i < quantity; i++)
        {
            deck.Add(cardType);
        }
    }
}