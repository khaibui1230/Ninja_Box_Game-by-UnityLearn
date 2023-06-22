using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{
    private Button button;
    private ManagerGame managerGame;
    public int difficult;

    // Start is called before the first frame update
    void Start()
    {
        button= GetComponent<Button>();
        // khai bao manager game
        managerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();
        button.onClick.AddListener(SetDifficuly);
    }

    void SetDifficuly()
    {
        managerGame.StartGame(difficult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
