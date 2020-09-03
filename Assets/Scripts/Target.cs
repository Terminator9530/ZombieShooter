using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Image healthBar;
    private float totalHealth;
    private float healthBarWidth;
    public GameObject[] items;

    private void Start()
    {
        totalHealth = health;

        // get health bar rect width
        healthBarWidth = healthBar.GetComponent<RectTransform>().rect.width;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        
        // setting size of health bar
        healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (health / totalHealth) * healthBarWidth);

        if(health <= 0f)
        {
            Instantiate(items[Random.Range(0,items.Length)], gameObject.transform.position + new Vector3(0, 0.5f, 0), gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<playerstats>().score += 1;
        }
    }
}
