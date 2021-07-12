using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour//預計按1切換箭矢
{
    public GameObject arrow; //箭矢
    public float maxLaunchForce; //最遠射程
    public float minLaunchForce; //最近射程
    
    public Transform shotPoint; //射擊起點

    float timer =0f; //拉弓時間計算
    float launchForce ; //本次射箭射程

    public GameObject point; //射擊點顯示
    GameObject[] points;   
    public int numberOfPoints; //射擊點密集程度
    public float spaceBetweenPoints;
    Vector2 direction;

    // Start is called before the first frame update
    void Start(){
        points = new GameObject[numberOfPoints];
        for(int i =0;i<numberOfPoints;i++){
            points[i]= Instantiate(point,shotPoint.position,Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //跟著滑鼠
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if(Input.GetButtonDown("Attack")){ //開始拉弓
            timer = Time.time;
            launchForce = minLaunchForce;
        }
        if(Input.GetButton("Attack")){ //拉弓中
            Force();
        }
        if(Input.GetButtonUp("Attack")){  //放開
            Shoot();
        }

        for(int i =0;i< numberOfPoints;i++){//射擊點提示顯示
            points[i].transform.position = PointPosition(i* spaceBetweenPoints);
        }
    }

    void Shoot(){ //射出箭矢
        GameObject newArrow = Instantiate(arrow,shotPoint.position,shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 PointPosition(float t){ 
        Vector2 position =(Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position;
    }

    void Force(){ //射程計算
        if(Time.time >= timer + 1f){
            timer = Time.time;
            if(launchForce < maxLaunchForce){
            launchForce += 2f;
            }
        }
        //Debug.Log(launchForce);
    }

    
}
