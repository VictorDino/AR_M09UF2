using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    #region
    public static GameObject instance;

    private void Awake()
    {
        instance = this.gameObject;
    }
    #endregion
    public static int maxHealth = 100;
    
    
    public static int currentHealth;

    [SerializeField]private ProgressBar healthBar;

    private void Start()
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

    private void Die()
    {
        Debug.Log("HAS MUERTO");
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        healthBar.SetValues(currentHealth, maxHealth);
    }
}
