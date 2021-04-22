using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public int[] slots;
    public GameObject[] projectilePrefabs;
    public int currentSlot;

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
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {

    }

    void ProcessInputs()
    {
        //Mouse Inputs
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CycleSlot();
        }

        //Keyboard Inputs
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Fire()
    {
        if (slots[currentSlot] != 0)
        {
            Instantiate(projectilePrefabs[slots[currentSlot]], transform.position, transform.rotation);
            slots[currentSlot] = 0;
            CycleSlot();
        }
    }

    public void Reload()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = 1;
        }
    }

    void CycleSlot()
    {
        if (currentSlot != 5)
        {
            currentSlot += 1;
        }
        else
        {
            currentSlot = 0;
        }
    }
}
