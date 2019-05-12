using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulledController : MonoBehaviour
{

    public float speed;

    public PlayerController player;

    public GameObject enemyDeathEffect;

    public GameObject impactEffact;

    public int pointsForKill;

    public float rotationSpeed;

    public int damgeToGive;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            // Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            // Destroy(collision.gameObject);
            // powerPoint.AddPoints(pointsForKill);

            collision.GetComponent<EnemyhealthManager>().giveDamage(damgeToGive);
        }

        if (collision.tag == "Boss")
        {
            collision.GetComponent<BossHealthManager>().giveDamage(damgeToGive);
        }
        Instantiate(impactEffact, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
