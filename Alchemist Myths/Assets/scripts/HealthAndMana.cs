using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthAndMana : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxMana =100;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public int currentHealth;
    public int currentMana;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Q)){
        //     TakeDamage(20);
        // }
    }
    void TakeDamage(int damage){

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth<=0){
            currentHealth =0;
            healthBar.SetHealth(currentHealth);
        }
    }
}
