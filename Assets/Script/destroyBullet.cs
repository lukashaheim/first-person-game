﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {
 
     void OnCollisionEnter(Collision collision)
     {
         Destroy(gameObject);
     }
 }
