using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public bool hasStarted = false;
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		//Gets the paddle to ball vector.
		paddleToBallVector = this.transform.position - paddle.transform.position;	
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//wait for mouse click to launch ball.
		if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (1f,10f);
			}
		} 
	}
	
	void OnCollisionEnter2D (Collision2D triggerBoing) {
		Vector2 tweak = new Vector2 (Random.Range(0.02f,0.2f), Random.Range(0.02f,0.2f));
		
		if (hasStarted) {
			audio.Play();
			rigidbody2D.velocity += tweak;
			

		}
	}
}


