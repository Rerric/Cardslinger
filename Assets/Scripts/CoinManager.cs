using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public float coins;

    public TextMeshProUGUI coinsText;
    public Text coinCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "" + coins;
        coinCount.text = "" + coins;
    }
}
