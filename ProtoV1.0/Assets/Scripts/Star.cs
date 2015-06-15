﻿using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{//start class

	public int _Health = 0;
	public int _Armor = 0;
	public int _StarSize = 0;
	public float _MovingSpeed = 0.0f;
	public float _CollisionDistance = 0.0f;

	// Use this for initialization
	public virtual void Start () 
	{//constructor start
	
		Debug.Log("Super Class Star");


	}//constructor end

	public virtual void Move()
	{//start function

		//MOVE LEFT
		if(Input.GetKey(KeyCode.A))
		{//start if1

			this.gameObject.transform.position += new Vector3(-1.0f,0.0f,0.0f) * _MovingSpeed * Time.deltaTime;
			Debug.Log("moving left");

		}//end if1

		//MOVE RIGHT
		if(Input.GetKey(KeyCode.D))
		{//start if2

			this.gameObject.transform.position += new Vector3(1.0f,0.0f,0.0f) * _MovingSpeed * Time.deltaTime;
			Debug.Log("moving right");

		}//end if2

		if(Input.GetKey(KeyCode.W))
		{//start if3

			this.gameObject.transform.position += new Vector3(0.0f,1.0f,.0f) * _MovingSpeed * Time.deltaTime;
			Debug.Log("moving up");
			
		}//end if3

		if(Input.GetKey(KeyCode.S))
		{//start if4

			this.gameObject.transform.position += new Vector3(0.0f,-1.0f,0.0f) * _MovingSpeed * Time.deltaTime;
			Debug.Log("moving down");
			
		}//end if4

	}//end move function

	public virtual bool CheckCollision(GameObject _ObjectToCollideWith)
	{//start check collision function

		if(Vector3.Distance(this.gameObject.transform.position,_ObjectToCollideWith.transform.position) <= _CollisionDistance)
		{//start if1

			return true;

		}//end if1
		else
		{//start else 1

			return false;

		}//end else 1


	}//end check collision function

	public virtual void TakeDamage(int DamageToTake)
	{//start take damage function

		Debug.Log("player armor:" + _Armor);
		Debug.Log("damage to take:" + DamageToTake);

		//subtracts armor from damage to take
		int TotalDamageToTake = DamageToTake - _Armor;
		//============================================

		//takes health out after armor has been taken into consideration
		this._Health -= TotalDamageToTake;
		//==============================================================

		Debug.Log("total damage taken after armor:" + TotalDamageToTake);

	}//end take damage function

	public virtual void Die()
	{//start die function

		Destroy(this.gameObject);

	}//end die function

	public virtual int GetHealth()
	{//start get health function

		return _Health;

	}//end get health function

	public virtual int GetArmor()
	{//start get armor function

		return _Armor;
		
	}//end get armor function

	public virtual int GetStarSize()
	{//start get star size function

		return _StarSize;
		
	}//end get star size function

	public float GetXcoord()
	{//start get x coord function

		return this.gameObject.transform.position.x;

	}//end get x coord function

	public float GetYcoord()
	{//start get x coord function
		
		return this.gameObject.transform.position.y;
		
	}//end get x coord function
	

}//end class
