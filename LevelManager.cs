﻿using UnityEngine;
using System.Collections;



public class LevelManager : MonoBehaviour {
	
	
	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: "+name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
		
	}
	
	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel +1);
		Screen.showCursor = false;
		}
	public void BrickDestroyed(){
		if (Brick.breakableCount <=0) {
		Invoke("LoadNextLevel", 2);
		
		
		}
	
	}
 }