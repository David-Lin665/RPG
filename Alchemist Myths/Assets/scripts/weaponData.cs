using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Melee
public class weaponData : MonoBehaviour
{
    public float attackRate = 0.5f;//攻擊CD
    public int damage = 10; //攻擊力
    public new Collider2D collider;//武器的碰撞箱
    float nextAttackTime = 0f;
    
    public void Attack(){//攻擊
        Invoke("AttackReturn",attackRate);//武器回到原位置(待改)
        collider.enabled = true;//啟用武器collider
        transform.eulerAngles = new Vector3 (0, 0, -45);//之後改成用animation移動collider(待改)
        transform.eulerAngles = new Vector3 (0, 0, -90); 
    }
    
    void AttackReturn(){//回復
        transform.eulerAngles = new Vector3 (0, 0, 0); 
        collider.enabled = false;
    }

    void Start(){
        collider.enabled = false;
    }

    void Update(){
        if(Time.time >= nextAttackTime){//普攻CD
            if(Input.GetButtonDown("Attack")){//按下攻擊鍵(E)
                Attack();//攻擊
                nextAttackTime = Time.time + 1f / attackRate;//重製CD
            }     
        }
    }
}   