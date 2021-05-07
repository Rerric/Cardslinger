using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject target;
    public PlayerController pScript;
    private Vector2 direction;

    public Rigidbody2D rb;
    public GameObject tSprite;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        pScript = target.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y).normalized;
        rb.transform.up = direction;

        rb.velocity = new Vector2(direction.x * pScript.speed * 1.4f, direction.y * pScript.speed * 1.4f);
        tSprite.transform.rotation = GameObject.Find("Cursor").transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            var temp = other.GetComponent<PlayerController>();
            temp.hp += 10;
        }
        Destroy(gameObject);
    }
}
