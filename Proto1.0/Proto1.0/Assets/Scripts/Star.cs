using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{//start class

	public int _Health = 0;
	public int _Armor = 0;
	public int _StarSize = 0;
	public int _StarLevel = 0;
	public float _MovingSpeed = 0.0f;
	public float _CollisionDistance = 0.0f;

	// Use this for initialization
	public virtual void Start () 
	{//constructor start
	
		Debug.Log("Super Class Star");

	}//constructor end

	public virtual void Update()
	{//start update function

	}//end update function

	public virtual void Move()
	{//start function

		//MOVE LEFT
		if(Input.GetKey(KeyCode.A))
		{//start if1

			this.gameObject.transform.position += new Vector3(-1.0f,0.0f,0.0f) * _MovingSpeed * Time.deltaTime;

		}//end if1

		//MOVE RIGHT
		if(Input.GetKey(KeyCode.D))
		{//start if2

			this.gameObject.transform.position += new Vector3(1.0f,0.0f,0.0f) * _MovingSpeed * Time.deltaTime;

		}//end if2

		if(Input.GetKey(KeyCode.W))
		{//start if3

			this.gameObject.transform.position += new Vector3(0.0f,1.0f,.0f) * _MovingSpeed * Time.deltaTime;
			
		}//end if3

		if(Input.GetKey(KeyCode.S))
		{//start if4

			this.gameObject.transform.position += new Vector3(0.0f,-1.0f,0.0f) * _MovingSpeed * Time.deltaTime;
			
		}//end if4

	}//end move function

	public virtual bool CollisionCheck(GameObject objectTocheckCollisionAgainst, float collisionDistance)
	{//start distance check function

		if (Vector3.Distance(this.gameObject.transform.position, objectTocheckCollisionAgainst.gameObject.transform.position) < collisionDistance) 
		{//start if1

			//Debug.Log("collided with:" + objectTocheckCollisionAgainst.gameObject.name);
			return true;
		
		}//end if1
		else 
		{//start else 1

			//Debug.Log("not colliding");
			return false;

		}//end else 1

	}//end distance check function

	public virtual void TakeDamage(int damageToTake)
	{//start take damage function

		int totalDamageToTake = damageToTake - _Armor;

		if (totalDamageToTake <= 0) 
		{//start if

			totalDamageToTake = 0;

		}//end if1

		_Health -= totalDamageToTake;

	}//end take damage function

	public virtual int GiveDamage(int damageToGive)
	{//start give damage function

		int totalDamageToGive = damageToGive * (_StarSize * _StarLevel);

		return totalDamageToGive;

	}//end give damamge function

	public virtual void Die()
	{//start die function

		Debug.Log ("Star has died :(");
		Destroy (this.gameObject);

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
