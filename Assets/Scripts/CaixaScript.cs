﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour {
	Animator anim;
	public float jumpForce;
	public int frutas;
	public GameObject frutaPrefab;

	public AudioClip[] audios;
	AudioSource audioS;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			anim.SetTrigger ("Colidindo");
			audioS.clip = audios [0];
			audioS.Play ();
			if (frutas > 0) {
				GameObject tempFruta = Instantiate (frutaPrefab, transform.position, transform.rotation) as GameObject;
				tempFruta.GetComponent<Animator> ().SetTrigger ("Coletando");
				tempFruta.GetComponent<AudioSource> ().Play();
				frutas -= 1;
				GameManager.gm.SetFrutas (1);
				Destroy (tempFruta, 0.667f);
			} else {
				Destroy (gameObject);
				audioS.clip = audios [1];
				audioS.Play ();
			}
		}
	}
}
