﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Sprite NewBehaviourScript1;
	public float EnemySpeed;
	float rotateX;
	private Vector2 movement;
	float turnTimer;
	float nextTurn = 0.0f;
	bool facingRight;
    public int Health;
    public Sprite damagedSprite;

    //public Transform target;

    // Use this for initialization
    void Start () {
        Health = 2;
		facingRight = true;
		rotateX = 2;
		turnTimer = .5f;

	}
	
	// Update is called once per frame
	void Update () {

		//Only change horizontal direction after a certain time
		if (Time.time > nextTurn) {
			Debug.Log ("turn");
			nextTurn = Time.time + turnTimer;
			if (facingRight) {
				rotateX = -1;
				facingRight = false;

				this.GetComponent<Rigidbody2D> ().rotation = -50;
			}
			else{
				rotateX = 1.5f;
				facingRight = true;
				this.GetComponent<Rigidbody2D> ().rotation = 50;		
			}

		}
		movement = new Vector2 (rotateX, -1);

        if(Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy 1 dead");
            GameManager.gm.enemyDead(0);
        }

		// LOOKING AT PLAYER AND MOVING TOWARDS IT
		/*
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,90),Space.Self);//correcting the original rotation
		//move towards the player
		transform.Translate(new Vector3(0,-EnemySpeed* Time.deltaTime,0) );
		*/




		this.GetComponent<Rigidbody2D> ().MovePosition(this.GetComponent<Rigidbody2D> ().position + movement* EnemySpeed) ;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "BoundBoxBottom") {
			Destroy (gameObject);
		}
        if (coll.gameObject.name == "PlayerBullet" || coll.gameObject.name == "PlayerBullet(Clone)")
        {
            this.GetComponent<SpriteRenderer>().sprite = damagedSprite;
			GetComponent<SpriteRenderer>().color = new Color(1f,0.286f, 0.286f);
            //Debug.Log("Bullet hit");

            Health--;
        }


	}


}
