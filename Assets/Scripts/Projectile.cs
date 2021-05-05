using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public int id;
    public Rigidbody2D rb;
    public int statusEffect;

    public Deck deckScript;

    /* Status Effects
        0 = none;
        1 = marked;
    */

    // Start is called before the first frame update
    void Start()
    {
        deckScript = GameObject.Find("Deck").GetComponent<Deck>();

        rb.AddRelativeForce(Vector3.up * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.CompareTag("Projectile") == true)
        {
            Destroy(collider.gameObject);
        }

        if (collider.CompareTag("Enemy") == true)
        {
            var temp = collider.gameObject.GetComponent<Enemy>();
            if (temp.marked == true)
            {
                temp.hp -= damage * 1.5f;
                if (temp.hp <= 0)
                {
                    deckScript.AddCards(id, 1);
                }
            }
            else
            {
                temp.hp -= damage;
                if (statusEffect == 1)
                {
                    temp.marked = true;
                }
            }

            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
