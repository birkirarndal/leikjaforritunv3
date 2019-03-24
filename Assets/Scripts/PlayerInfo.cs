using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    // breytur
    private bool attacked = false;
    private float invincible = 0.5f; 
    private int health;
    private float timer;

    public Animator animator;
    public Text healthText;
    private GameObject[] Enemies; // listi með afturgöngum

    // Start is called before the first frame update
    void Start()
    {
        // setur líf sem 100 og kallar í SetCountText()
        health = 100;
        SetCountText();

    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy"); // setur alla gameobject sem eru með taggið Enemy í listan 

        timer += Time.deltaTime;
        foreach (GameObject Enemy in Enemies) // fyrir hverja afturgöngu í listanum
        {
            animator = Enemy.GetComponent<Animator>();
            if (Vector3.Distance(transform.position, Enemy.transform.position) < 1) // ef fjarlægðinn á milli afturgangan og spilarinn er minn en 1
            {
                animator.SetBool("inRange", true); // kveikir hreyfingu
                if (timer >= invincible && health > 0) // ef tíminn er stærri eða jafnt og invincible breytan og health er stærra en 0
                {
                    attack(); // kallar í attack fallið
                }
                if (health <= 0) // ef lífið á spilaranum er minna eða jafnt og 0
                {                    
                    SceneManager.LoadScene("GameOver"); // hlaðar inn GameOver sceneinu
                }
            }
            else
            {
                animator.SetBool("inRange", false); // slekkur á hreyfingu
            }
        }
    }
   
    void attack()
    {
        timer = 0f; // setur tíman á 0
        if (health > 0) // ef lífið er stærra en 0
        {
            Hurt(10); // kallar í Hurt fallið
        }
    }

    public void Hurt(int damage)
    {
        health -= damage; // minnkar lífið á spilaranum
        SetCountText();
    }
    
    void SetCountText()
    {
        healthText.text = "Health: " + health; // birtir hversu mikið líf spilarinn er með á skjáinn
    }
}
