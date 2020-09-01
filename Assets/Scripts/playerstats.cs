using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerstats : MonoBehaviour
{
    public float health = 100f;
    public int score = 0;
    public Text scoreText;
    public float totalHealth;
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }
}
