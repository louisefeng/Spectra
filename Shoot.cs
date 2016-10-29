using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public float speed;
	private Rigidbody2D move;
	public static GameObject collisionItem;
	private double switchTime;
	private double nextTime;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
	private int shipNum = 0;
	private SpriteRenderer spriteRenderer;
    private GameObject player;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		move = GetComponent<Rigidbody2D> ();
        player = GameObject.Find("Player");
        switchTime = player.GetComponent<Control>().switchTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 moving = new Vector2 (0, speed);
		move.velocity = moving * speed;
	
		if (Input.GetButton("colorChange") && Time.time > nextTime) {
			nextTime = Time.time + switchTime;
			shipNum = (shipNum + 1) % 4;
			switch (shipNum) {
			case 0:
				spriteRenderer.sprite = sp1;
				spriteRenderer.sortingLayerName = "0";
				break;
			case 1:
				spriteRenderer.sprite = sp2;
				spriteRenderer.sortingLayerName = "1";
				break;
			case 2:
				spriteRenderer.sprite = sp3;
				spriteRenderer.sortingLayerName = "2";
				break;
			case 3:
				spriteRenderer.sprite = sp4;
				spriteRenderer.sortingLayerName = "3";
				break;
			}
		}
	}
}
