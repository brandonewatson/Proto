﻿using UnityEngine;
using System.Collections;

public class Player : Star
{//start class

	// Use this for initialization
	public override void Start () 
	{//start constructor
	
		Debug.Log("Player");

	}//end constructor

	void Update()
	{//start update function

		Move();

	}//end updte function


}//end class
