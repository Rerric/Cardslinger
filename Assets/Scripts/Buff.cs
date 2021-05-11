using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float buffRate; // time between buffs
    public int buffType; 

    public GameObject player;
    public PlayerController playerScript;
    public GameObject buffSprite;
    public GameObject cardSprite;

    public GameObject buffProjectile;

    /* Buff Types:
        0 = healing;
        1 = damage;
     */

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();

        InvokeRepeating("BuffNow", buffRate, buffRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.Rotate(0, 0, 1.0f);

        buffSprite.transform.position = cardSprite.transform.position + new Vector3(0, 0.77f);
        buffSprite.transform.Rotate(0, 0, -1.0f);
    }

    void BuffNow()
    {
        Instantiate(buffProjectile, cardSprite.transform.position, transform.rotation);
    }
}
