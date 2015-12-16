using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip explosion;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	
	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;
	
	
	
	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag =="Breakable"); 
		if (isBreakable) {
			breakableCount++;
		
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		
	}
	
	
	
	void OnCollisionEnter2D (Collision2D collision) {
		
		
		
		AudioSource.PlayClipAtPoint (explosion, transform.position);
		if (isBreakable) {
			PuffSmoke();
			HandleHits();
			
		} 
	}
	
	
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
	smoke.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	Instantiate (smoke, transform.position, Quaternion.identity);
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
		Debug.LogError("Brick sprite missing.");
		}
	}
	
	
}
