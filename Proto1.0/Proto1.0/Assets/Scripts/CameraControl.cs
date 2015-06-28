using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization

	public Camera cam1;
	public Camera cam2;

	public bool UseMainCam = true;

	void Start () {

		if ( UseMainCam == true )
		{
			cam1.enabled = true;
			cam2.enabled = false;
		}
		else
		{
			cam1.enabled = false;
			cam2.enabled = true;
		}
		//cam1.enabled = !cam1.enabled;
		//cam2.enabled = !cam2.enabled;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
