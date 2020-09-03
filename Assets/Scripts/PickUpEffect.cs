using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    public GameObject WeaponHolder;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Bullets")
            {
                WeaponHolder = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                int indexOfWeapon = WeaponHolder.GetComponent<WeaponSwitcher>().selectedWeapon;
                if(WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<OneShot>() != null)
                {
                    WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<OneShot>().totalBullets += 10;
                    WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<OneShot>().UpdateAmmoOnGUI();
                    Destroy(gameObject);
                }
                if (WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<MultiShot>() != null)
                {
                    WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<MultiShot>().totalBullets += 10;
                    WeaponHolder.transform.GetChild(indexOfWeapon).gameObject.GetComponent<MultiShot>().UpdateAmmoOnGUI();
                    Destroy(gameObject);
                }
            }
            else
            {
                if (other.gameObject.GetComponent<playerstats>().health != other.gameObject.GetComponent<playerstats>().totalHealth)
                {
                    Destroy(gameObject);
                }
                other.gameObject.GetComponent<playerstats>().health += 50f;
                if (other.gameObject.GetComponent<playerstats>().health > other.gameObject.GetComponent<playerstats>().totalHealth)
                {
                    other.gameObject.GetComponent<playerstats>().health = other.gameObject.GetComponent<playerstats>().totalHealth;
                }
                other.gameObject.GetComponent<Damage>().SetHealthBar();
            }
        }
    }
}
