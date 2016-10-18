using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float speed;

	private Rigidbody2D move;

	private double nextTime;
	public double spawnTime;
	public double moveTime;
	private double movingTime;

	public GameObject self;
	private string selfName;
	private Collider2D selfCol;

	public float startPosX;
	public float startPosY;
	private double yPos = 0;
	private double xPos;
	public double yMaxRange;
	private Transform position;

	public Vector2 direction;

	private float yVal = 1;
	public float xVal = 1;

	private SpriteRenderer bulletSpriteRenderer;
	private SpriteRenderer spriteRenderer;

	private GameObject reference;
	private Spawn spawnReference;

	// Use this for initialization
	void Start () {

		move = GetComponent<Rigidbody2D> ();
		selfName = gameObject.name;
		position = GetComponent<Transform> ();
		selfCol = GetComponent<Collider2D> ();

		/* This part makes it bounce around erratically
		Vector2 moving = direction;
		move.velocity = moving * speed;
		*/
	
	}

	void Awake() {
		reference = GameObject.Find ("EnemyGenerator");
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals("Enemy")){
		//if (!col.gameObject.name.Equals("Background") && !col.gameObject.name.Equals("Player") 
		//	&& !col.gameObject.name.Equals("nullWall")) {
			Physics2D.IgnoreCollision (col, selfCol);
		}
		if (col.gameObject.name == "Background") {
			xVal = xVal * -1;
			//move.position.Set (move.position.x, move.position.y - 1);
			//position.position = new Vector2(move.position.x, move.position.y - 1);
			move.velocity = new Vector2 (0, -1) * speed;
		}
		spriteRenderer = GetComponent<SpriteRenderer> ();
		bulletSpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
		if (col.gameObject.name == "Bullet(Clone)" 
			&& spriteRenderer.sortingLayerName == bulletSpriteRenderer.sortingLayerName
		) {
			spriteRenderer.gameObject.SetActive(false);
			spawnReference = reference.GetComponent<Spawn> ();
			switch(spriteRenderer.sortingLayerName) {
			case "0":
				spawnReference.num(0);
				break;
			case "1":
				spawnReference.num(1);
				break;
			case "2":
				spawnReference.num(2);
				break;
			case "3":
				spawnReference.num(3);
				break;
			}
		}
	}


	//Box size limit: 5, bottom is -4 (because of player);

	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextTime && (selfName == "Enemy0" || selfName == "Enemy1" || selfName == "Enemy2" || selfName == "Enemy3")) {
			nextTime = Time.time + spawnTime;
			Instantiate (self, new Vector3 (startPosX, startPosY, 0), new Quaternion ());
			//Instantiate (self, new Vector3 (startPosX, startPosY, 0), new Quaternion (), self.transform);
		}*/

		if (Time.time > movingTime) {
			movingTime = Time.time + moveTime;
			Vector2 moving = new Vector2 (direction.x * xVal, direction.y * yVal);
			move.velocity = moving * speed;
			//move.AddForce(moving * speed);
			yPos += Mathf.Abs (direction.y);
			//print ("x = " + move.position.x + " y = " + move.position.y + " yPos = " + yPos);

			if (yPos > yMaxRange - 1) {
				yPos = 0;
				yVal = yVal * -1;
			}
		}
	}
}
