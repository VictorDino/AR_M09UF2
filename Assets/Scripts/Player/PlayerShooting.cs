using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject powerVision;
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 15f;
    public float fireRate = 1f; 
    public float bulletLifetime = 0.5f; 

    public int maxBullets = 6; 
    public float reloadTime = 5f; 

    public int bulletsInMagazine = 0; 
    private float timeToFire = 0.0f;
    private bool isReloading = false; 

    private float timer = 0f;
    private const int powerUpTime= 10;

    public bool powerUp = false;

    public bool powerUp2 = false;

    public bool powerUp3 = false;

    public bool powerUp4 = false;

    public bool powerUp5 = false;
    private void Start()
    {
        bulletsInMagazine = maxBullets; 
        
        Bullet bulletScript = GetComponent<Bullet>();

        PlayerHealth playerHealthScript = GetComponent<PlayerHealth>();
    }
    void Update()
    {

        if (isReloading) // Si se está recargando, salir del método
        {
            return;
        }
        
        if (Input.GetButton("Fire1") && Time.time >= timeToFire && !isReloading && bulletsInMagazine > 0) 
        {
            timeToFire = Time.time + 1 / fireRate; 
            Shoot(); 
            bulletsInMagazine--;

        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsInMagazine < maxBullets) 
        {
            StartCoroutine(Reload()); 
        }

        PowerUp();
        PowerUp2();
        PowerUp3();
        PowerUp4();
        PowerUp5();
        
    }

    void Shoot()
    {
        // Obtener la posición de la cámara y la dirección del rayo
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraDirection = Camera.main.transform.forward;

        // Lanzar un rayo desde la posición de la cámara en la dirección de la mira
        RaycastHit hit;
        if (Physics.Raycast(cameraPosition, cameraDirection, out hit))
        {
            // Calcular la dirección de la bala
            Vector3 bulletDirection = hit.point - firePoint.position;
            bulletDirection.Normalize();

            // Instanciar una bala en el punto de origen del disparo y en la rotación actual
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Aplicar velocidad a la bala en la dirección del rayo
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bulletDirection * bulletSpeed;

            // Destruir la bala después de un cierto tiempo
            Destroy(bullet, bulletLifetime);
            
        }
    }

    void PowerUp()
    {
        if (powerUp)
        {
            if (timer < powerUpTime)
            {
                powerVision.SetActive(true);
                fireRate = 5;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                fireRate = 1f;
                powerUp = false;
                powerVision.SetActive(false);
            }

        }
    }

    void PowerUp2()
    {
        if (powerUp2)
        {
            if (timer < powerUpTime)
            {
                powerVision.SetActive(true);
                maxBullets = 30;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                maxBullets = 6;
                bulletsInMagazine = 6;
                powerUp2 = false;
                powerVision.SetActive(false);
            }

        }
    }

    void PowerUp3()
    {
        if (powerUp3)
        {
            if (timer < powerUpTime)
            {
                powerVision.SetActive(true);
                reloadTime = 1;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                reloadTime= 5;
                powerUp3= false;
                powerVision.SetActive(false);
            }

        }
    }

    void PowerUp4()
    {
        if (powerUp4)
        {
            if (timer < powerUpTime)
            {
                powerVision.SetActive(true);
                Bullet.damage = 100;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                Bullet.damage = 25;
                powerUp4 = false;
                powerVision.SetActive(false);
            }

        }
    }

    void PowerUp5()
    {
        if (powerUp5)
        {
            if (timer < powerUpTime)
            {
                powerVision.SetActive(true);
                PlayerHealth.maxHealth = 999;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                PlayerHealth.currentHealth = 100;
                powerUp5 = false;
                powerVision.SetActive(false);
            }

        }
    }

    IEnumerator Reload()
    {
        isReloading = true; // Indicar que se está recargando
        yield return new WaitForSeconds(reloadTime); // Esperar el tiempo de recarga
        bulletsInMagazine = maxBullets; // Llenar el cargador
        isReloading = false; // Indicar que ha terminado la recarga
    }
}

