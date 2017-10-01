﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {


    public float shotSpeed;
    public float shotDamage;
    //Vector2 PositionTransform;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //this.GetComponent<Rigidbody2D> ().velocity = Vector3.up * SpaceShipSpeed;
        //PositionTransform += Vector2.up * shotSpeed;
        this.GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position + Vector2.up * shotSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name != "Spaceship")
        {
            Destroy(gameObject);
        }
    }

}
