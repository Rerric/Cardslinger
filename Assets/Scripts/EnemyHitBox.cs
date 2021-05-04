using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public GameObject enemy;
    public Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemy.GetComponent<Enemy>();
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
            temp.hp -= enemyScript.damage;
        }
    }
}
