using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    public float blastRadius = 5f;
    public float force = 700f;
    public float blastDamage = 0.1f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    public void Explode()
    {

        gameObject.GetComponent<AudioSource>().Play();

        // explosion effect

        Instantiate(explosionEffect, transform.position, transform.rotation);

        // get nearby objects

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        
        foreach(Collider nearbyObject in colliders)
        {
            // destroy object nearby
            if(nearbyObject.tag == "Zombie")
            {
                if(nearbyObject.GetComponent<Target>() != null)
                nearbyObject.GetComponent<Target>().TakeDamage(blastDamage);
            }
        }

        StartCoroutine(DestroyGrenade());
    }

    IEnumerator DestroyGrenade()
    {
        yield return new WaitForSeconds(3f);

        // destroy grenade

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}
