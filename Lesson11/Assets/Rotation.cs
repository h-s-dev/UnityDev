﻿using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public Vector3 angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (this.angle * Time.deltaTime);	
	}
}
