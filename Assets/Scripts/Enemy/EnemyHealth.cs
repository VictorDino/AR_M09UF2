using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public List<GameObject> possibleDrops;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        int randomIndex = Random.Range(0, possibleDrops.Count);
        GameObject drop = possibleDrops[randomIndex];
        Instantiate(drop, transform.position, Quaternion.identity);

        
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.EnemyDefeated();
        }

        Destroy(gameObject);
    }
}
