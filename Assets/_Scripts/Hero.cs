using System.Collections;
using System.Collections.Generic; 
using UnityEngine;


public class Hero : MonoBehaviour
{
    public static Hero S; //Singleton

    // Public variables float
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("HeroScript.Awake() - Attempted to assign second Hero.S!");
        }
    }

    void Update()
    {
        // Gets input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        //Changes position
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
        // Rotates position
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go.tag == "Enemy"){
            Destroy(go);
            Destroy(this.gameObject);
        }
    }
}