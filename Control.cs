using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float speed;
    private static int lives = 3;

    public int health;
    public int worldHealth;

	private Rigidbody2D move;
	public GameObject bullet;
	public float yPosition;
	public GameObject ship;
	public double shootTime;
	public double switchTime;
	private double bulletNextTime;
	private double shipNextTime;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
    private Sprite[] allSprites = new Sprite[4];
    private string[] allNames = new string[4];
	private int myNum;
	private SpriteRenderer spriteRenderer;

    private GameObject enemySpawns;
    private Spawn enemySpawner;

	// Use this for initialization
	void Start () {
		
		spriteRenderer = GetComponent<SpriteRenderer> ();
        myNum = bulletNum(spriteRenderer.sortingLayerName);
        allSprites[0] = sp1;
        allSprites[1] = sp2;
        allSprites[2] = sp3;
        allSprites[3] = sp4;
        allNames[0] = "0";
        allNames[1] = "1";
        allNames[2] = "2";
        allNames[3] = "3";
        spriteRenderer.sprite = sp1;
		move = GetComponent<Rigidbody2D> ();

	}

    public void beenHit()
    {
        health -= 1;
    }

    void Awake()
    {
        enemySpawns = GameObject.Find("EnemyGenerator");
    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0 || worldHealth <= 0) {
            lives -= 1;
            /*enemySpawner = enemySpawns.GetComponent<Spawn>();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < enemySpawner.allEnem(x).Length; y++)
                {
                    enemySpawner.allEnem(x)[y].gameObject.SetActive(false);
                }
            }
            //trigger game over
            */
        }

        if (lives <= 0)
        {
            //trigger game over
            //end this process
        }
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 moving = new Vector2 (moveHorizontal, 0);
		move.velocity = moving * speed;

		if (Input.GetButton ("Fire1") && Time.time > bulletNextTime) {
			bulletNextTime = Time.time + shootTime;
			Instantiate (bullet, new Vector3 (ship.transform.position.x, yPosition, 0), new Quaternion());
		}

		if (Input.GetButton("colorChange") && Time.time > shipNextTime) {
			shipNextTime = Time.time + switchTime;
            myNum = bulletNum(spriteRenderer.sortingLayerName);
            spriteRenderer.sprite = allSprites[(myNum + 1) % 4];
            spriteRenderer.sortingLayerName = allNames[(myNum + 1) % 4];
			//switch (myNum) {
			//case 0:
			//	spriteRenderer.sprite = sp1;
			//	spriteRenderer.sortingLayerName = "0";
			//	break;
			//case 1:
			//	spriteRenderer.sprite = sp2;
			//	spriteRenderer.sortingLayerName = "1";
			//	break;
			//case 2:
			//	spriteRenderer.sprite = sp3;
			//	spriteRenderer.sortingLayerName = "2";
			//	break;
			//case 3:
			//	spriteRenderer.sprite = sp4;
			//	spriteRenderer.sortingLayerName = "3";
			//	break;
			//}
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