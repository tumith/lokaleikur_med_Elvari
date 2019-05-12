using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public int enemyHealth;

    public GameObject deathEffect;

    public int pointsOnDeath;

    public GameObject bossPrefab;

    public float minSize;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            powerPoint.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }

    }
    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
