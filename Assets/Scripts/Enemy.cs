using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float speed;
    public float range; //How far away this can be before being able to attack
    public float damage; //How much damage attack does
    public float waitTime; //How many frames between readying an attack and attacking
    private float wait; //Variable used to check frames
    private Vector2 direction;
    public int behavior;
    public bool isRanged;
    public bool canAttack;
    public bool isAlert;

    public bool marked;

    public GameObject eSprite;
    public GameObject healthBar;
    public GameObject alertSprite;
    public GameObject chaseArmsSprite;
    public GameObject windupArmsSprite;
    public GameObject attackArmsSprite;
    public GameObject markedSprite;
    public Rigidbody2D rb;
    public GameObject enemyProjectile;
    private GameObject player;

    public GameObject[] dropPrefabs;
    public float dropChance; // %Chance this will drop something from its available drops when defeated

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        behavior = 0;
        canAttack = true;
        isAlert = false;
        marked = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Hp();
        StatusEffects();

        //Behavior State Machine
        switch (behavior)
        {
            case 3: //attack
                if (isRanged)
                {
                    Aim();
                }
                Attack();
                break;

            case 2: //chase
                Aim();
                Move();
                Chase();
                break;

            case 1:  //alert
                if (isAlert == false)
                {
                    isAlert = true;
                    StartCoroutine(Alert());
                }
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
        if (distance <= 15 || hp < maxHp)
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
            float chance = Random.Range(1, 100);
            if (chance <= dropChance)
            {
                int drop = Random.Range(0, dropPrefabs.Length);
                Instantiate(dropPrefabs[drop], transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        healthBar.transform.localScale = new Vector3((hp / maxHp) / 2, 0.5f, 1);
    }

    void StatusEffects()
    {
        if (marked)
        {
            markedSprite.SetActive(true);
        }
        else markedSprite.SetActive(false);
    }

    void Chase()
    {
        chaseArmsSprite.SetActive(true);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= range)
        {
            if (isRanged)
            {
                rb.velocity = new Vector2(0, 0);
            }
            chaseArmsSprite.SetActive(false);
            behavior = 3;
        }
    }

    void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            wait = 0;
            windupArmsSprite.SetActive(true);
        }

        if (wait < waitTime)
        {
            wait += 1;
        }
        else
        {
            windupArmsSprite.SetActive(false);
            attackArmsSprite.SetActive(true);
            if (isRanged && wait == waitTime)
            {
                wait += 1;
                Instantiate(enemyProjectile, eSprite.transform.position, eSprite.transform.rotation);
            }
            StartCoroutine(AttackCd());
        }
    }

    IEnumerator AttackCd()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        attackArmsSprite.SetActive(false);
        canAttack = true;
        behavior = 2;
        
    }
}
