using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//so that we can see changes we make without having to run the game  

[ExecuteInEditMode]

public class PostProcessDepthGrayscale : MonoBehaviour {
	public Material mat;  

	// Use this for initialization
	void Start () {
		Camera.main.depthTextureMode = DepthTextureMode.Depth;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination){  
		Graphics.Blit(source, destination, mat);  
	}  
	
	// Update is called once per frame
	void Update () {
		
	}
}
