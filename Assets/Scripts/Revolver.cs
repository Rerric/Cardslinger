using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public int[] slots;
    public GameObject[] projectilePrefabs;
    public GameObject[] uiSlots;
    public int currentSlot;
    private Deck deckScript;

    public GameObject revolver;
    public bool canShoot;
    public float shotCd;

    /*Cardtypes
        0 = None;
        1 = Bullet;
        2 = Knife;
        3 = Burst;
        4 = Queen of Hearts;
        5 = Ace of Spades;
        6 = Wild Card;
    */

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GameObject.Find("Deck").GetComponent<Deck>();
        shotCd = 60;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        RotateBarrel();
        UpdateUISlots();
    }

    void FixedUpdate()
    {
        
    }

    void ProcessInputs()
    {
        //Mouse Inputs
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            Fire();
        }

        if (Input.GetMouseButtonDown(1) && canShoot == true)
        {
            CycleSlot();
        }

        //Keyboard Inputs
        if (Input.GetKeyDown(KeyCode.R) && canShoot == true)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            deckScript.AddCards(1, 1);
        }
    }

    public void Fire()
    {
        CycleSlot();
        if (slots[currentSlot] != 0)
        {
            Instantiate(projectilePrefabs[slots[currentSlot]], transform.position, transform.rotation);
            slots[currentSlot] = 0;
        }
    }

    public void Reload()
    {
        if (deckScript.deck.Count != 0)
        {
            int n = currentSlot + 1;
            for (int i = 0; i < slots.Length; i++)
            {
                if (n >= slots.Length)
                {
                    n = 0;
                }

                if (slots[n] == 0)
                {
                    slots[n] = deckScript.deck[0];
                    deckScript.RemoveCards(1);
                    break;
                }

                n += 1;
            }
        }
    }

    void CycleSlot()
    {
        shotCd = 0;
        canShoot = false;

        if (currentSlot != 5)
        {
            currentSlot += 1;
        }
        else
        {
            currentSlot = 0;
        }
    }

    void RotateBarrel()
    {
        if (shotCd < 60)
        {
            revolver.transform.Rotate(0, 0, -1);
            shotCd += 1;
        }
        else canShoot = true;
    }

    void UpdateUISlots()
    {
        for (int s = 0; s < slots.Length; s++)
        {
            if (slots[s] != 0)
            {
                uiSlots[s].SetActive(true);
            }
            else
            {
                uiSlots[s].SetActive(false);
            }
        }
    }
}
