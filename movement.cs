using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float speed;

	private Rigidbody2D move;

	private double nextTime;
	private double spawnTime;
	public double moveTime;
	private double movingTime;
    public double shootingTime;
    private double shootTime;

    private static int num0;
    private static int num1;
    private static int num2;
    private static int num3;

	public GameObject self;
	private Collider2D selfCol;

	public float startPosX;
	public float startPosY;
	private double yPos = 0;
	private double xPos;
	public double yMaxRange;

	public Vector2 direction;

	private float yVal = 1;
	private float xVal = 1;

	private SpriteRenderer bulletSpriteRenderer;
	private SpriteRenderer spriteRenderer;

	private GameObject reference;
	private Spawn spawnReference;
    private GameObject player;

	// Use this for initialization
	void Start () {

		move = GetComponent<Rigidbody2D> ();
		selfCol = GetComponent<Collider2D> ();
	
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
			Vector2 moving = new Vector2 (direction.x * xVal, direction.y * yVal);
			move.velocity = moving * speed;
			yPos += Mathf.Abs (direction.y);

			if (yPos > yMaxRange - 1) {
				yPos = 0;
				yVal = yVal * -1;
			}
		}

        if (Time.time - spawnTime > shootTime)
        {
            shootTime = Time.time + (Random.value * shootingTime);
            int importantNum = bulletNum(GetComponent<SpriteRenderer>().sortingLayerName);
            GameObject temp = reference.GetComponent<Spawn>().allBull(importantNum)[spawnReference.returnShot(importantNum)].gameObject;
            temp.transform.position = new Vector3(GetComponent<Transform>().position.x,
                GetComponent<Transform>().position.y, 0);
            temp.gameObject.SetActive(true);
            spawnReference.incrementShot(importantNum);
            /*switch (GetComponent<SpriteRenderer>().sortingLayerName)
            {
                case "0":
                    GameObject temp = reference.GetComponent<Spawn>().allBull(0)[spawnReference.returnShot(0)].gameObject;
                    temp.transform.position = new Vector3(GetComponent<Transform>().position.x,
                        GetComponent<Transform>().position.y, 0);
                    temp.gameObject.SetActive(true);
                    spawnReference.incrementShot(0);
                    break;
                case "1":
                    temp = reference.GetComponent<Spawn>().allBull(1)[spawnReference.returnShot(1)].gameObject;
                    Instantiate(temp, new Vector3(GetComponent<Transform>().position.x, 
                        GetComponent<Transform>().position.y, 0), new Quaternion());
                    temp.gameObject.SetActive(true);
                    spawnReference.incrementShot(1);
                    print("blue bullet");
                    break;
                case "2":
                    temp = reference.GetComponent<Spawn>().allBull(2)[spawnReference.returnShot(2)].gameObject;
                    Instantiate(temp, new Vector3(GetComponent<Transform>().position.x, 
                        GetComponent<Transform>().position.y, 0), new Quaternion());
                    temp.gameObject.SetActive(true);
                    spawnReference.incrementShot(2);
                    print("green bullet");
                    break;
                case "3":
                    temp = reference.GetComponent<Spawn>().allBull(3)[spawnReference.returnShot(3)].gameObject;
                    Instantiate(temp, new Vector3(GetComponent<Transform>().position.x, 
                        GetComponent<Transform>().position.y, 0), new Quaternion());
                    temp.gameObject.SetActive(true);
                    spawnReference.incrementShot(3);
                    print("yellow bullet");
                    break;

            }*/
        }

        if (self.transform.position.y < -4) {
            self.SetActive(false);
            player.GetComponent<Control>().worldHealth -= 1;
            int importantNum = bulletNum(GetComponent<SpriteRenderer>().sortingLayerName);
            spawnReference.num(importantNum);
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
