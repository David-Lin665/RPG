using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTilemap : MonoBehaviour
{
    public Tilemap destructibleTilemap;
    public LayerMask layermask;
    public GameObject rock;

    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>(); // 選取要作用的tilemap
        layermask = LayerMask.GetMask("Ground"); // 設置要作用的layermask

    }
    void Update()
    {
        Vector3 mousepos = Input.mousePosition; // 滑鼠在螢幕上的座標(pixel)
        mousepos.z = Camera.main.nearClipPlane; // 令z座標在nearclipplane上
        Vector3 worldposition = Camera.main.ScreenToWorldPoint(mousepos); // 將滑鼠座標轉換成遊戲世界座標
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldposition.x,worldposition.y),Vector2.zero,0,layermask); // 從滑鼠的世界座標射出一道雷射偵測碰到的東西記錄在hitData
        if(hitData&&Input.GetMouseButtonDown(0)) //如果有hitData且按下滑鼠左鍵
        {
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(worldposition),null); // 將滑鼠所在位置的那格Tile刪除
            Spawn(worldposition);
        }

    }

    void Spawn(Vector3 position)
    {
        Instantiate(rock,position,rock.transform.rotation);
    }
    
}

    
    
    

