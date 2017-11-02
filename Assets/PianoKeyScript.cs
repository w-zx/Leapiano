using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoKeyScript : MonoBehaviour {
	public float semitone_offset = 0;
	public GameObject obj;
	AudioSource audioSource;

	bool isClicked = false;
	private GUIStyle guiStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		obj = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		PlayNote ();
		RotateKey (90);
		isClicked = true;
	}

	void OnMouseUp () {
		RotateKey (-90);
		isClicked = false;
	}


	void OnTriggerEnter (Collider c) {
		PlayNote ();
		obj.GetComponent<Renderer> ().material.color = Color.red;
		isClicked = true;
		//RotateKey (90);
	}

	void OnTriggerExit (Collider c) {
		obj.GetComponent<Renderer> ().material.color = Color.white;
		isClicked = false;
		//RotateKey (-90);
	}

	void OnGUI () {
		guiStyle.fontSize = 25;
		guiStyle.normal.textColor = Color.red;
		if (isClicked == true) {
			GUI.Label (new Rect (Screen.width/2, Screen.height/2+Screen.height/16, 200, 20), this.name, guiStyle);
		}
	}
		
	void PlayNote () {
		audioSource.pitch = Mathf.Pow(2f, semitone_offset/12.0f);
		audioSource.Play();
	}

	void RotateKey (float degree) {
		transform.Rotate (new Vector3 (degree, 0, 0), Space.Self);
	}
}