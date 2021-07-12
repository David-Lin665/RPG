using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public HealthBar healthBar;
    public int currentHealth;
    float timer = 0;//for TakeDamage CD

    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0){//血條歸0
            die();
        }  
    }
    public void TakeDamage(int damage,float next){  //受傷  
        if(Time.time >= timer){//CD
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            timer = Time.time + next;//武器下次揮擊後才能再被判定
        }
    }

    void die(){//死亡
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D col){ //被攻擊判定

        if(col.gameObject.layer == 9){//判斷是否為武器
            if(col.gameObject.tag == "Projectile"){//是否為投射物
                int projectileDamage = col.GetComponent<projectileData>().damage;
                TakeDamage(projectileDamage,0);
            }else{//是近戰武器
                int weaponDamage = col.GetComponent<weaponData>().damage;//取得武器攻擊力
                float attackRate = col.GetComponent<weaponData>().attackRate;
                TakeDamage(weaponDamage,attackRate);
            }
            
        }
    }

    
}
