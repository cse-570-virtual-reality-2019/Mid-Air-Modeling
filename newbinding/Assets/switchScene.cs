using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour {
	// public bool flag;
	public float[] shapes=new float[4];
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// if(flag){
			// flag=false;
			// SceneManager.LoadScene("MainScene");
		// }
	}
	void Awake(){
		DontDestroyOnLoad(this);
	}
}
