﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	public GameObject bulletPrefab;

	public Transform bulletSpawn;

	public AudioSource gunSound;

	public float bulletSpeed = 30;

	public float lifetime = 3;


	// Use this for initialization
	void Start () {

	}


	void Update () 
	{
			{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Fire();
		}
	}
	}

	private void Fire()
	{
		GameObject bullet = Instantiate(bulletPrefab);
		
		Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
		bulletSpawn.parent.GetComponent<Collider>());

		bullet.transform.position = bulletSpawn.position;

		Vector3 rotation = bullet.transform.rotation.eulerAngles;

		bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

		bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

		StartCoroutine(DestroyBulletAfterTime(bullet, lifetime));	
		PlaySound();
	}

	private void PlaySound() 
	{
		gunSound.Play();
	}
		
	private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
	{
		yield return new WaitForSeconds(delay);

		Destroy(bullet);
	}

	}
	

