using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectileData : MonoBehaviour
{
    public int damage = 10; //攻擊力
    Rigidbody2D rb;
    bool hasHit;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(hasHit == false){//若尚未碰到地形
            float angle = Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == 10){//碰到怪
            Destroy(gameObject);
        }else if(col.gameObject.layer == 7){//碰到地形
            hasHit =true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }
}   