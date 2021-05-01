using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float speed;
    public int enemyType;

    public GameObject eSprite;
    public GameObject healthBar;

    /* Enemy Types
        0 = Normal Melee;
        1 = Normal Ranged;
        2 = Big Melee;
        3 = Big Ranged;
    */

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        eSprite.transform.Rotate(0, 0, 1);

        healthBar.transform.localScale = new Vector3((hp / maxHp) / 2, 0.5f, 1);
        
    }
}
