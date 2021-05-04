using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverText;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(playerScript.hp / playerScript.maxHp, 1, 1);

        if (playerScript.isDead)
        {
            gameOverText.SetActive(true);
        }
    }
}
