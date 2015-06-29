using UnityEngine;
using System.Collections;

public class EnemyStar : Star
{//start class

	public GameObject _ObjectToDropWhenDead = null;
	public int _ExperiencePointsToGive = 0;

	// Use this for initialization
	public override void Start () 
	{//start constructor
	
		Debug.Log("Enemy Start");
		Debug.Log ("Adding myself to enemy list");
		DataManager._EnemyStars.Add (this.gameObject);

	}//end constructor
	
	// Update is called once per frame
	public override void Update () 
	{//start update function

		CheckCollision ();
	
	}//end update function

	public override bool CollisionCheck (GameObject objectTocheckCollisionAgainst, float collisionDistance)
	{//start collision check function

		return base.CollisionCheck (objectTocheckCollisionAgainst, collisionDistance);

	}//end collision check function

	public void CheckCollision()
	{//start check collision function

		if(CollisionCheck(DataManager._Player,_CollisionDistance) == true) 
		{//start if1

			Debug.Log("colliding with player");
			DataManager._EnemyStars.Remove(this.gameObject);
			Die();

		}//end if1

	}//end check collision function

}//end class
