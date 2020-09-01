using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public Image healthBar;
    private float healthBarWidth;
    // Start is called before the first frame update
    void Start()
    {
        // get health bar rect width
        healthBarWidth = healthBar.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Zombie")
        {
            Debug.Log("Attacked");
            GetComponent<playerstats>().health -= 10f;
            SetHealthBar();
        }
    }

    public void SetHealthBar()
    {
        float health = GetComponent<playerstats>().health / 100;

        // setting size of health bar
        healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, health * healthBarWidth);
    }
}
