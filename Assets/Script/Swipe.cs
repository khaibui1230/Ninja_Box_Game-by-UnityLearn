using System;
using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {

    }
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        managerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();
        target = gameObject.AddComponent<Target>();
    }

    // Update is called once per frame
    void Update()
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
                swiping = true;
                UpdateComponents();
            }
            if(swiping)
            {
                UpdateMousePosition();
            }
        }
        
    }
    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    

}
