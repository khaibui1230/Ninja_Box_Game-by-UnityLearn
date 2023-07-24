using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Build.Content;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int point;
    public ParticleSystem explotionParticle;
    public int pointGameOver = 0;

    private ManagerGame managerGame; // khai bao scrip manager game
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float minTorque = 0;
    private float maxTorque = 10;
    private float Range = 4;
    private float ySpawnPos = 6;
    // Start is called before the first frame update
    void Start()
    {
        // tham chieu den ham rigibody
        Rigidbody targetRb = GetComponent<Rigidbody>();
        // khai bao de manager game co the tham chieu den ham ManagerGame.Script 
        managerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();

        //ap mot luc huong len tren theo truc y, voi y nghia la mot luc ngan
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // lam xoay vat the ngau nhien theo gia tri ham random
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        pointGameOver = 0;
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(UnityEngine.Random.Range(-Range, Range), -ySpawnPos);
    }

    float RandomTorque()
    {
        return UnityEngine.Random.Range(-minTorque, maxTorque);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // neu nguoi choi an vao 
    private void OnMouseDown()
    {
        if (managerGame.isGameActive)
        {
            Destroy(gameObject);
            // khoi tao bien explotionParticle when u click 
            Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);

            // tranform.rotation co tac dung cho ve the quay theo cung chieu voi vat the ban dau
            managerGame.UpdateScore(point);
        }
    }





    public void OnTriggerEnter(Collider other)
    {
        if (managerGame.isGameActive == false)
        {
            managerGame.GameOver();
            Destroy(gameObject);
        }
        //Destroy(gameObject);
        //if (gameObject.CompareTag("Good"))
        //{
        //    managerGame.UpdateScorelives();
        //}

    }
    public void DestroyTarget()
    {
        if (managerGame.isGameActive == true)
        {
            if (gameObject.CompareTag("Good"))
            {
                Destroy(gameObject);
                Instantiate(explotionParticle, transform.position,
                explotionParticle.transform.rotation);
                managerGame.UpdateScore(point);
            }
            else if (gameObject.CompareTag("Bad"))
            {
                Destroy(gameObject);
                Instantiate(explotionParticle, transform.position,
                explotionParticle.transform.rotation);
                managerGame.UpdateScorelives();
            }
            else if (gameObject.CompareTag("Boom"))
            {
                Time.timeScale = 0f;
                managerGame.isGameActive = false;
                Instantiate(explotionParticle, transform.position,
                explotionParticle.transform.rotation);
                managerGame.GameOver();
            }
        }
    }


}
