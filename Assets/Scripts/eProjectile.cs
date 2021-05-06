using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector3.up * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") == true)
        {
            var temp = collider.gameObject.GetComponent<PlayerController>();
            temp.hp -= damage;
            Destroy(gameObject);
        }

        if (collider.CompareTag("Prop") == true)
        {
            var temp = collider.gameObject.GetComponent<Prop>();
            temp.hp -= damage;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
