using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{//start class

	public int _Health = 0;
	public int _Armor = 0;
	public int _StarSize = 0;
	public float _MovingSpeed = 0.0f;

	// Use this for initialization
	public virtual void Start () 
	{//constructor start
	
		Debug.Log("Super Class Star");

	}//constructor end

	public virtual void Update()
	{//start update function

		Move();

	}//end update function

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

	public virtual void TakeDamage()
	{//start take damage function


	}//end take damage function

	public virtual void Die()
	{//start die function


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
	

}//end class
