using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject mainCamera;

    public GameObject deckText;
    public GameObject coinText;
    public GameObject cardScreen;

    public bool onScreen;

    // Start is called before the first frame update
    void Start()
    {
        onScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y);

        if (Input.GetKeyDown("tab"))
        {
            if (onScreen == false)
            {
                onScreen = true;
            }
            else onScreen = false;
        }

        if (onScreen)
        {
            cardScreen.SetActive(true);
            deckText.SetActive(false);
            coinText.SetActive(false);
        }
        else
        {
            cardScreen.SetActive(false);
            deckText.SetActive(true);
            coinText.SetActive(true);
        }
    }
}
