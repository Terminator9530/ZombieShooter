using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject pickUpEffect;
    public float multiplier = 2f;
    public float duration = 4f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        // spawn an effect
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        // apply effect to player
        playerstats stats = player.GetComponent<playerstats>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        // wait for 2 sec

        yield return new WaitForSeconds(duration);

        // original health

        stats.health /= multiplier;

        // destroy power up
        Destroy(gameObject);
    }
}
