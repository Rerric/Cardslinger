using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float speed;
    public float range;
    public float damage;
    private Vector2 direction;
    public int behavior;

    public GameObject eSprite;
    public GameObject healthBar;
    public GameObject alertSprite;
    public GameObject chaseArmsSprite;
    public GameObject windupArmsSprite;
    public GameObject attackArmsSprite;
    public Rigidbody2D rb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        behavior = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Hp();

        //Behavior State Machine
        switch (behavior)
        {
            case 3: //attack
                break;

            case 2: //chase
                Aim();
                Move();
                Chase();
                break;

            case 1:  //alert
                StartCoroutine(Alert());
                Aim();
                break;

            default: //idle
                Idle();
                break;
        }
    }

    void FixedUpdate()
    {

    }

    void Idle()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= 12 || hp < maxHp)
        {
            behavior = 1;
        }
    }

    IEnumerator Alert()
    {
        alertSprite.SetActive(true);
        yield return new WaitForSeconds(1);
        alertSprite.SetActive(false);
        behavior = 2;
    }

    void Aim()
    {
        direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        eSprite.transform.up = direction;
    }

    void Move()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    void Hp()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.transform.localScale = new Vector3((hp / maxHp) / 2, 0.5f, 1);
    }

    void Chase()
    {
        chaseArmsSprite.SetActive(true);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= range)
        {
            rb.velocity = new Vector2(0, 0);
            chaseArmsSprite.SetActive(false);
            behavior = 3;
        }
    }
}
