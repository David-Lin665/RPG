using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    //public Transform AttackPoint;
    //public float AttackRange = 0.5f;

    float AttackCD = 0f;
    public float AttackRate = 2f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= AttackCD){
           if(Input.GetButtonDown("Attack")){
			    Attack();
                AttackCD = Time.time + 1f / AttackRate;
		    } 
        }
        
    }

    void Attack(){
		animator.SetTrigger("Attack");
        //Physis2D.OverlapCircleAll(AttackPoint.position,);
	}
}
