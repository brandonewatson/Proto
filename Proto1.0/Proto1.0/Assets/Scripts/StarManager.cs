using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour 
{
	//public ArrayList starList = new ArrayList();

	public Component[] starList;
	public Component[] colliderList;
	//public Cluster[,] clusters;

	public Cluster[,] clusters = new Cluster[3,3];

	public const int CLUSTER_FOCUS = 1;

	public int myNumb;

	private int[] starArray;

	// Use this for initialization
	void Start () 
	{
		//Debug.Log ( starList[0].particleSystem.renderer.bounds.size );
		Debug.Log ( "Hello World" );
		initClusters();
		AlignStars ();
		AlignCollision ();
	
	}

	public void initClusters()
	{
		//Cluster[,] clusters = new Cluster[3,3];
		int clusterCount = 0;

		//for ( int i = 0; i < 3; i++)
		//{
		//	clusters[i] = new Cluster[3];
		//}

		for ( int i = 0; i < 3; i++)
		{
			for ( int j = 0; j < 3; j++ )
			{
				clusters[i,j] = new Cluster();
				clusters[i,j].currentCluster = clusterCount;

				if ( i == 1 && j == 1 )
				{
					clusters[i,j].focus = true;
				}
				else
				{
					clusters[i,j].focus = false;
				}

				clusterCount++;
			}
		}

		for ( int i = 0; i < 3; i++)
		{
			for ( int j = 0; j < 3; j++ )
			{
				// View Clusters
				//Debug.Log ( "Current Cluster: " + clusters[i,j].currentCluster + " - Is Focus: " + clusters[i,j].focus);

			}
		}

		viewClusters ();

		//Debug.Log ( clusters.Length);


	}

	public void viewClusters ()
	{
		for ( int i = 0; i < 3; i++)
		{
			for ( int j = 0; j < 3; j++ )
			{
				// View Clusters
				//Debug.Log ( "Current Cluster: " + clusters[i,j].currentCluster + " - Is Focus: " + clusters[i,j].focus);
				
			}
		}
	}

	/*byte[][] scores = new byte[5][];
	for (int x = 0; x < scores.Length; x++) 
	{
		scores[x] = new byte[4];
	}*/

	public void CalculateCollision ( int boxCollided )
	{
		int xDirection = 0;
		int yDirection = 0;


		for ( int i = 0; i < 3; i++)
		{
			for ( int j = 0; j < 3; j++ )
			{
				clusters[i,j].focus = false;

				if ( clusters [ i, j ].currentCluster == boxCollided )
				{

					clusters[i,j].focus = true;
					xDirection = j - CLUSTER_FOCUS;
					yDirection = i - CLUSTER_FOCUS;

					// What box was hit
					//Debug.Log ( "Box " + boxCollided + " Collided" );
					//Debug.Log ( "Direction from Focus: ( " + xDirection + ", " + yDirection + " )" + " - (i,j): " + i + j);
					viewClusters ();


				}
			}
		}

		if ( xDirection == 0 )
		{
			if ( yDirection == 1 )
			{
				ShiftClusters( "Down" );
			}
			if ( yDirection == -1 )
			{
				ShiftClusters( "Up" );
			}
		}
		if ( yDirection == 0 )
		{
			if ( xDirection == 1 )
			{
				ShiftClusters( "Right" );
			}
			if ( xDirection == -1 )
			{
				ShiftClusters( "Left" );
			}
		}


		//if ( boxCollided == 0 )
		//{
			
		//}


	}

	void ShiftClusters ( string theDirection )
	{
		Vector3 newPosition = new Vector3( 0, 0, 0 );
		int[] boxSave = new int [ 3 ];

		if ( theDirection == "Down" )
		{
			newPosition = new Vector3( 0, 0, 5.9f );
			starList[clusters [ 0, 0 ].currentCluster].transform.position -= ( newPosition * 3 );
			starList[clusters [ 0, 1 ].currentCluster].transform.position -= ( newPosition * 3 );
			starList[clusters [ 0, 2 ].currentCluster].transform.position -= ( newPosition * 3 );

			boxSave [ 0 ] = clusters [ 0, 0 ].currentCluster;
			boxSave [ 1 ] = clusters [ 0, 1 ].currentCluster;
			boxSave [ 2 ] = clusters [ 0, 2 ].currentCluster;

			clusters [ 0, 0 ].currentCluster = clusters [ 1, 0 ].currentCluster;
			clusters [ 0, 1 ].currentCluster = clusters [ 1, 1 ].currentCluster;
			clusters [ 0, 2 ].currentCluster = clusters [ 1, 2 ].currentCluster;

			clusters [ 1, 0 ].currentCluster = clusters [ 2, 0 ].currentCluster;
			clusters [ 1, 1 ].currentCluster = clusters [ 2, 1 ].currentCluster;
			clusters [ 1, 2 ].currentCluster = clusters [ 2, 2 ].currentCluster;

			clusters [ 2, 0 ].currentCluster = boxSave [ 0 ];
			clusters [ 2, 1 ].currentCluster = boxSave [ 1 ];
			clusters [ 2, 2 ].currentCluster = boxSave [ 2 ];

		}

		if ( theDirection == "Up" )
		{
			newPosition = new Vector3( 0, 0, 5.9f );
			starList[clusters [ 2, 0 ].currentCluster].transform.position += ( newPosition * 3 );
			starList[clusters [ 2, 1 ].currentCluster].transform.position += ( newPosition * 3 );
			starList[clusters [ 2, 2 ].currentCluster].transform.position += ( newPosition * 3 );

			boxSave [ 0 ] = clusters [ 2, 0 ].currentCluster;
			boxSave [ 1 ] = clusters [ 2, 1 ].currentCluster;
			boxSave [ 2 ] = clusters [ 2, 2 ].currentCluster;
			
			clusters [ 2, 0 ].currentCluster = clusters [ 1, 0 ].currentCluster;
			clusters [ 2, 1 ].currentCluster = clusters [ 1, 1 ].currentCluster;
			clusters [ 2, 2 ].currentCluster = clusters [ 1, 2 ].currentCluster;
			
			clusters [ 1, 0 ].currentCluster = clusters [ 0, 0 ].currentCluster;
			clusters [ 1, 1 ].currentCluster = clusters [ 0, 1 ].currentCluster;
			clusters [ 1, 2 ].currentCluster = clusters [ 0, 2 ].currentCluster;
			
			clusters [ 0, 0 ].currentCluster = boxSave [ 0 ];
			clusters [ 0, 1 ].currentCluster = boxSave [ 1 ];
			clusters [ 0, 2 ].currentCluster = boxSave [ 2 ];
			
		}

		if ( theDirection == "Left" )
		{
			newPosition = new Vector3( 5.9f, 0, 0 );
			
			starList[clusters [ 0, 2 ].currentCluster].transform.position -= ( newPosition * 3 );
			starList[clusters [ 1, 2 ].currentCluster].transform.position -= ( newPosition * 3 );
			starList[clusters [ 2, 2 ].currentCluster].transform.position -= ( newPosition * 3 );

			boxSave [ 0 ] = clusters [ 0, 2 ].currentCluster;
			boxSave [ 1 ] = clusters [ 1, 2 ].currentCluster;
			boxSave [ 2 ] = clusters [ 2, 2 ].currentCluster;
			
			clusters [ 0, 2 ].currentCluster = clusters [ 0, 1 ].currentCluster;
			clusters [ 1, 2 ].currentCluster = clusters [ 1, 1 ].currentCluster;
			clusters [ 2, 2 ].currentCluster = clusters [ 2, 1 ].currentCluster;
			
			clusters [ 0, 1 ].currentCluster = clusters [ 0, 0 ].currentCluster;
			clusters [ 1, 1 ].currentCluster = clusters [ 1, 0 ].currentCluster;
			clusters [ 2, 1 ].currentCluster = clusters [ 2, 0 ].currentCluster;
			
			clusters [ 0, 0 ].currentCluster = boxSave [ 0 ];
			clusters [ 1, 0 ].currentCluster = boxSave [ 1 ];
			clusters [ 2, 0 ].currentCluster = boxSave [ 2 ];
			
		}

		if ( theDirection == "Right" )
		{
			newPosition = new Vector3( 5.9f, 0, 0 );
			starList[clusters [ 0, 0 ].currentCluster].transform.position += ( newPosition * 3 );
			starList[clusters [ 1, 0 ].currentCluster].transform.position += ( newPosition * 3 );
			starList[clusters [ 2, 0 ].currentCluster].transform.position += ( newPosition * 3 );

			boxSave [ 0 ] = clusters [ 0, 0 ].currentCluster;
			boxSave [ 1 ] = clusters [ 1, 0 ].currentCluster;
			boxSave [ 2 ] = clusters [ 2, 0 ].currentCluster;
			
			clusters [ 0, 0 ].currentCluster = clusters [ 0, 1 ].currentCluster;
			clusters [ 1, 0 ].currentCluster = clusters [ 1, 1 ].currentCluster;
			clusters [ 2, 0 ].currentCluster = clusters [ 2, 1 ].currentCluster;
			
			clusters [ 0, 1 ].currentCluster = clusters [ 0, 2 ].currentCluster;
			clusters [ 1, 1 ].currentCluster = clusters [ 1, 2 ].currentCluster;
			clusters [ 2, 1 ].currentCluster = clusters [ 2, 2 ].currentCluster;
			
			clusters [ 0, 2 ].currentCluster = boxSave [ 0 ];
			clusters [ 1, 2 ].currentCluster = boxSave [ 1 ];
			clusters [ 2, 2 ].currentCluster = boxSave [ 2 ];
			
		}

		AlignCollision ();
	}

	void AlignStars ()
	{
		Vector3 nextXPosition = new Vector3 ( 5.9f, 0, 0);
		Vector3 nextZPosition = new Vector3 ( 0, 0, 5.9f);
		starList[1].transform.position = starList[0].transform.position + nextXPosition;
		starList[2].transform.position = starList[0].transform.position + ( nextXPosition * 2);
		starList[3].transform.position = starList[0].transform.position - nextZPosition;
		starList[4].transform.position = starList[0].transform.position + nextXPosition - nextZPosition;
		starList[5].transform.position = starList[0].transform.position + ( nextXPosition * 2 ) - nextZPosition;
		starList[6].transform.position = starList[0].transform.position - ( nextZPosition * 2 );
		starList[7].transform.position = starList[0].transform.position + nextXPosition - ( nextZPosition * 2 );
		starList[8].transform.position = starList[0].transform.position + ( nextXPosition * 2 ) - ( nextZPosition * 2 );
		//Debug.Log ( "Box0 Size" + starList[0].particleSystem.renderer.bounds.size );
	}
	void AlignCollision ()
	{
		for ( int i = 0; i < 9; i++)
		{
			Vector3 starPosition = new Vector3(starList[i].transform.position.x, colliderList[i].transform.position.y, starList[i].transform.position.z);
			colliderList[i].transform.position = starPosition;
		}

		//Vector3 starPosition = new Vector3(starList[1].transform.position.x, colliderList[1].transform.position.y, starList[1].transform.position.x);
		//colliderList[1].transform.position = starPosition;

		//colliderList[0].transform.position.x = starList[0].transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter ( Collision col )
	{

	}
}

public class Cluster
{
	public bool focus;
	public int currentCluster;

	public Cluster()
	{
	}

}
/*
	//public StarArray() {}

	public StarArray(  )
}*/
