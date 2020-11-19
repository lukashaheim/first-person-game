using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour 
{

	
	public GameObject bullet;

	void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.name == "Capsule") 
		{
			Debug.Log("Bullet hit");
			
			//Destroy(collision.collider.gameObject);
			//collision.collider.gameObject.active = false;
			GameObject.Find("Capsule").transform.localScale = new Vector3(0, 0, 0);
			//DestroyImmediate(bullet, true);
		}
	}
}	