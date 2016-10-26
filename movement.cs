using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	private float speed;
	private Rigidbody2D move;

    //Each of these numbers it to help time every event that happens
	private double nextTime;
	private double spawnTime;
	private double moveTime;
	private double movingTime;
    private double shootingTime;
    private double shootTime;

    //private static int num0;
    //private static int num1;
    //private static int num2;
    //private static int num3;

	public GameObject self;
	private Collider2D selfCol;

    //position stuff
    //private Vector2 startingPos;
	private double yPos = 0;
    private double xPos;
    private Vector2 maxRange;

    //used to determine if ship is moving left/right or up/down; yVal and xVal should only ever be -1 and 1
	private float yVal = 1;
	private float xVal = 1;

	private SpriteRenderer bulletSpriteRenderer;
	private SpriteRenderer spriteRenderer;

	private GameObject reference;
	private Spawn spawnReference;
    private GameObject player;
    private int myNum;

	// Use this for initialization
	void Start () {

		move = GetComponent<Rigidbody2D> ();
		selfCol = GetComponent<Collider2D> ();
        myNum = bulletNum(GetComponent<SpriteRenderer>().sortingLayerName);
        speed = spawnReference.speed[myNum];
        moveTime = spawnReference.moveTime[myNum];
        shootingTime = spawnReference.shootingTime[myNum];
        //startingPos = spawnReference.startingPos[myNum];
        maxRange = spawnReference.maxPos[myNum];
	}

	void Awake() {
		reference = GameObject.Find ("EnemyGenerator");
        player = GameObject.Find("Player");
        spawnReference = reference.GetComponent<Spawn>();

    }

    void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals("Enemy")){
			Physics2D.IgnoreCollision (col, selfCol);
		}
		if (col.gameObject.name == "Background") {
			xVal = xVal * -1;
			move.velocity = new Vector2 (0, -1) * speed;
		}
		spriteRenderer = GetComponent<SpriteRenderer> ();
		bulletSpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
		if (col.gameObject.name == "Bullet(Clone)" 
			&& spriteRenderer.sortingLayerName == bulletSpriteRenderer.sortingLayerName
		) {
			spriteRenderer.gameObject.SetActive(false);
            spawnReference.num(myNum);
		}
        if (col.gameObject.name == "Player") {
            /* for instant death
             * some game over code
             * */

            //for not instant death (ie one or two hits)
            /* player.GetComponent<Control>().beenHit -= 1;
             * spriteRenderer.gameObject.SetActive(false); 
             * */
        }
	}

    public void setSpawnTime(double x)
    {
        spawnTime = x;
    }

    public double getRandomShootingTime()
    {
        Random temp = new Random();
        return shootingTime * Random.value;
    }


	//Box size limit: 5, bottom is -4 (because of player);

	// Update is called once per frame
	void Update () {

		if (Time.time > movingTime) {
			movingTime = Time.time + moveTime;
            Vector2 moving = spawnReference.movementDirection[myNum];
			moving = new Vector2 (moving.x * xVal, moving.y * yVal);
			move.velocity = moving * speed;
			yPos += Mathf.Abs (spawnReference.movementDirection[myNum].y);

			if (yPos > maxRange.y - 1) {
				yPos = 0;
				yVal = yVal * -1;
			}
		}

        if (Time.time - spawnTime > shootTime)
        {
            shootTime = Time.time + (Random.value * shootingTime);
            GameObject temp = reference.GetComponent<Spawn>().allBull(myNum)[spawnReference.returnShot(myNum)].gameObject;
            temp.transform.position = new Vector3(GetComponent<Transform>().position.x,
                GetComponent<Transform>().position.y, 0);
            temp.gameObject.SetActive(true);
            spawnReference.incrementShot(myNum);
        }

        if (self.transform.position.y < -4) {
            self.SetActive(false);
            player.GetComponent<Control>().worldHealth -= 1;
            spawnReference.num(myNum);
        }
	}

    int bulletNum(string bul)
    {
        switch (bul)
        {
            case "0":
                return 0;
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
        }
        return 0;
    }
}
