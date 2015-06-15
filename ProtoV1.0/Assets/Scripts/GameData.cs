using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour 
{//start class

	//list holding enemy stars
	public static List<GameObject> _EnemyList = new List<GameObject>();
	//==================================================================

	//reference to the player
	public GameObject _Player = null;
	public static Player _PlayerClass = null;
	//=================================

	//saved player stats
	public static int _SavedPlayerHealth = 0;
	public static int _SavedPlayerArmor = 0;
	public static int _SavedPlayerStarSize = 0;
	public static float _SavedPlayerXcoords = 0.0f;
	public static float _SavedPlayerYcoords = 0.0f;
	//=============================================

	void Start()
	{//start constructor

		_PlayerClass = _Player.GetComponent<Player>();

	}//end constructor


	public static void SaveGameData()
	{//start game data function

		//save player health
		PlayerPrefs.SetInt("PlayerHealth", _PlayerClass.GetHealth());
		//============================================================

		//save player armor
		PlayerPrefs.SetInt("PlayerArmor", _PlayerClass.GetArmor());
		//============================================================

		//save player start size
		PlayerPrefs.SetInt("PlayerStarSize", _PlayerClass.GetStarSize());
		//============================================================

		//save player x coords
		PlayerPrefs.SetFloat("PlayerXcoords", _PlayerClass.GetXcoord());
		//============================================================

		//save player y coords
		PlayerPrefs.SetFloat("PlayerYcoords", _PlayerClass.GetYcoord());
		//============================================================

	}//end save game data function

}//end class
