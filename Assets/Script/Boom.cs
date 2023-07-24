using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private ManagerGame managerGame;

    
    public float explosionForce = 10f;
    public float explosionRadius = 5f;

    void Start()
    {
        // khai bao de manager game co the tham chieu den ham ManagerGame.Script 
        managerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // kiem tra nguoi choi chma vao boom
        if (collision.gameObject.CompareTag("Player")) 
        {
            managerGame.GameOver();
        }
        else if (collision.gameObject.CompareTag("Good") || collision.gameObject.CompareTag("Bad")) 
        {
            // cho phep ke dich di xuyen qua trai cay
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
    public void OnMouseDown()
    {
        // neu nguoi choi chem vao bopom thì se dung
        if (managerGame.isGameActive && gameObject.CompareTag("Boom"))
        {
            Destroy(gameObject);
            managerGame.GameOver();
            
        }
    }

    //void Explosion()
    //{
    //    // xoa cac collider va rigibody de qua boom tranh bi va cham voi cac doi tuong khac
    //    Destroy(GetComponent<Rigidbody>());
    //    Destroy(GetComponent<BoxCollider>());

    //}
}
