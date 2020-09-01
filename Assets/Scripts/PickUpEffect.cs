using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<playerstats>().health != other.gameObject.GetComponent<playerstats>().totalHealth)
            {
                Destroy(gameObject);
            }
            other.gameObject.GetComponent<playerstats>().health += 50f;
            if(other.gameObject.GetComponent<playerstats>().health > other.gameObject.GetComponent<playerstats>().totalHealth)
            {
                other.gameObject.GetComponent<playerstats>().health = other.gameObject.GetComponent<playerstats>().totalHealth;
            }
            other.gameObject.GetComponent<Damage>().SetHealthBar();
        }
    }
}
