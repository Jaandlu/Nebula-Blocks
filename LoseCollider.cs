using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {
	public int ballsLeft = 5;
	public Text ballCounter; 
	
	
	
	private LevelManager levelManager; 
	private Ball ball;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		ball = GameObject.FindObjectOfType<Ball>();
		
	
	}
	void Update() {
		ballCounter.text = ballsLeft.ToString();
	} 
	
	void OnTriggerEnter2D (Collider2D trigger) {
		
		audio.Play();
		if (ballsLeft == 0 && Brick.breakableCount != 0) {
		levelManager.LoadLevel("Lose");
		Screen.showCursor = true;
		ballsLeft = 5;
		} else {
		ball.hasStarted=false;
		ballsLeft--;
		
		
		}
		
	}
	
	
}
