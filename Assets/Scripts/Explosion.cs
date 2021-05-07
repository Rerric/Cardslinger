using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;
    public int id;
    public int statusEffect;

    public Deck deckScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroyed());

        deckScript = GameObject.Find("Deck").GetComponent<Deck>();
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

            if (statusEffect == 2)
            {
                temp.Stun(3.0f);
            }
        }

    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
