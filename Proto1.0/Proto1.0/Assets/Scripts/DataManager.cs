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

	//holds reference to the player's class to get its functions
	public static Player _PlayerClass = null;
	//===============================================

	// Use this for initialization
	void Start () 
	{//constructor start

		if (_NameOfPlayer == "") 
		{//start if1

			Debug.LogWarning ("_nameOfPlayer is empty");

		}//end if1
		else if (_NameOfPlayer != "")
		{//start else if

			_Player = GameObject.Find (_NameOfPlayer);

		}//end else if

		if (_Player != null) {//start if2

			_PlayerClass = _Player.GetComponent<Player> ();

		}//end if2
		else if (_Player == null)
		{//start else 2

			Debug.LogWarning("_Player variable is empty");

		}//end else 2

	}//constructor end
	

}//end class
