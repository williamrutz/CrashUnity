using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public float intervaloDeAtaque;
	private float proximoAtaque;
	public AudioClip spinSound;
	private AudioSource audioS;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Ataque") && Time.time > proximoAtaque) {
			Atacando ();
		}
		
	}

	void Atacando()
	{
		anim.SetTrigger ("Ataque");
		proximoAtaque = Time.time + intervaloDeAtaque;
		audioS.clip = spinSound;
		audioS.Play ();
	}
}
