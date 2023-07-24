using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// yeu cau phai co kieu trail va box conllider
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class Swipe : MonoBehaviour
{
    private ManagerGame managerGame;
    private Target target;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;

    private bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        managerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();

    }

    // Update is called once per frame
    void Update()
    {
        // kiem tra coi nhan chuot hay khongf, neu co thif sex ...
        CheckTheMousedown();
        
    }

    void CheckTheMousedown()
    {
        if (managerGame.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Target>())
        //{
        //    collision.gameObject.AddComponent<Target>().DestroyTarget();

        //}
        //if (collision.gameObject.CompareTag("Boom"))
        //{
        //    //StartCoroutine(managerGame.explosionSquence());

        //    //wating for a second to want play the gameover
        //    StartCoroutine(gameOverDeplay());
            
           
        //}
        //else
        //{
            Target targetComponent = collision.gameObject.GetComponent<Target>();
            if (targetComponent != null)
            {
                targetComponent.DestroyTarget();

            }
        //}
    }
    IEnumerator gameOverDeplay()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        managerGame.GameOver();
    }
}
