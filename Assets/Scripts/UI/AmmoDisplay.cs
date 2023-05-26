using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public PlayerShooting playerShooting;
    private Text ammoText; 

    private void Awake()
    {
        ammoText = GetComponent<Text>(); 
    }

    private void Update()
    {
       
            
      ammoText.text = "Ammo: " + playerShooting.bulletsInMagazine.ToString() + " / " + playerShooting.maxBullets.ToString();
        
    }
}

