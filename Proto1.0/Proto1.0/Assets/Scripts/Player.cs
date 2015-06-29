using UnityEngine;
using System.Collections;

public class Player : Star
{//start class

	private int _CurrentExperiencePoints = 0;
	public int _MaxExperiencePointsToLevel = 0;

	// Use this for initialization
	public override void Start () 
	{//start constructor
	
		Debug.Log("Player");
		_MaxExperiencePointsToLevel *= _StarLevel;

	}//end constructor

	public override void Update()
	{//start update function

		Move ();
		CheckCollisionDetection ();


	}//end update function

	public override bool CollisionCheck (GameObject objectTocheckCollisionAgainst, float collisionDistance)
	{
		return base.CollisionCheck (objectTocheckCollisionAgainst, collisionDistance);
	}

	public void CheckCollisionDetection()
	{//start check collision detection function

		foreach (GameObject enemy in DataManager._EnemyStars) 
		{//start foreach 1

			 if(CollisionCheck(enemy.gameObject, _CollisionDistance)== true)
			 {//start if1

				Debug.Log("player colliding with:" + enemy.gameObject.name);

			 }//end if 1

		}//end for each 2

	}//end check collision detection function


	public void AddXPpoints(int xpPoints)
	{//start set xp points function

		_CurrentExperiencePoints += xpPoints; 

	}//end set xp points function

	public int GetXPpoints()
	{//start get xp points function

		return _CurrentExperiencePoints;

	}//end get xp points function

}//end class
