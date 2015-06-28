using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour 
{//start class

	//holds all enemy stars
	public static List<GameObject> _EnemyStars = new List<GameObject>();
	//==================================================================

	//if the name of the player changes in the hierarchy it must be changed here
	public string _NameOfPlayer = "";
	//==========================================================================

	//holds reference of the player
	public static GameObject _Player = null;
	//======================================

	// Use this for initialization
	void Start () 
	{//constructor start

		if (_NameOfPlayer == "") 
		{//start if1

			Debug.LogWarning("_nameOfPlayer is empty");

		}//end if1
		GameObject.Find(_NameOfPlayer);
	
	}//constructor end
	

}//end class
