using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int[] itemID;
    public float[] prices;
    public Text[] pricesText;
    public GameObject[] buttons;
    public GameObject shopItems;
    public GameObject shopText;
    public bool inShop;

    public PlayerController pcScript;
    

    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();

        for (int b = 0; b < buttons.Length; b++)
        {
            var temp = buttons[b].GetComponent<ShopButton>();
            temp.price = prices[b];
            temp.item = itemID[b];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inShop)
        {
            shopItems.SetActive(true);
            shopText.SetActive(true);
        }
        else
        {
            shopItems.SetActive(false);
            shopText.SetActive(false);
        }

        for (int i = 0; i < pricesText.Length; i++)
        {
            pricesText[i].text = "" + prices[i];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            pcScript.inShop = true;
            inShop = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            pcScript.inShop = false;
            inShop = false;
        }
    }
}
