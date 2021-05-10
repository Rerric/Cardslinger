using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public float hp;
    public Rigidbody2D rb;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        float rot = Random.Range(0, 359);
        transform.Rotate(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    { 
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
