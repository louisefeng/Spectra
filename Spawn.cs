using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	//public int[] total;
	public int max;
    public int screenLimit;
	public movement enemy0;
    public enemyShoot bullet0;
	public movement enemy1;
    public enemyShoot bullet1;
    public movement enemy2;
    public enemyShoot bullet2;
    public movement enemy3;
    public enemyShoot bullet3;
    //our temporary limit on enemies is 20 of each type, maximum 200 bullets (these numbers can be changed)
    private static GameObject[] enemyList0 = new GameObject[20];
	private static GameObject[] enemyList1 = new GameObject[20];
	private static GameObject[] enemyList2 = new GameObject[20];
	private static GameObject[] enemyList3 = new GameObject[20];
    private static GameObject[] bulletList0 = new GameObject[200];
    private static GameObject[] bulletList1 = new GameObject[200];
    private static GameObject[] bulletList2 = new GameObject[200];
    private static GameObject[] bulletList3 = new GameObject[200];

    private List<movement> enemyTypes = new List<movement>(); 
    private List<enemyShoot> bulletTypes = new List<enemyShoot>();
    private GameObject[][] allEnemies = new GameObject[][] { enemyList0, enemyList1, enemyList2, enemyList3 };
    private GameObject[][] allBullets = new GameObject[][] { bulletList0, bulletList1, bulletList2, bulletList3 };

    public List<Vector2> movementDirection = new List<Vector2>(4);
    private List<double> nextTime = new List<double>();
    public List<float> speed = new List<float>();
    public List<double> moveTime = new List<double>();
    public List<double> shootingTime = new List<double>();
    public List<Vector2> startingPos = new List<Vector2>();
    public List<Vector2> maxPos = new List<Vector2>();
    public List<double> delay = new List<double>();
    public List<double> spawnTime = new List<double>();

    private List<int> enemyNum = new List<int>();
    private List<int> spawns = new List<int>();
    private List<int> shotsTaken = new List<int>();

    // Use this for initialization
    void Start (){
        enemyTypes.Add(enemy0);
        enemyTypes.Add(enemy1);
        enemyTypes.Add(enemy2);
        enemyTypes.Add(enemy3);
        bulletTypes.Add(bullet0);
        bulletTypes.Add(bullet1);
        bulletTypes.Add(bullet2);
        bulletTypes.Add(bullet3);
        for (int x = 0; x < 4; x++)
        {
            shotsTaken.Add(0);
            nextTime.Add(0);
            enemyNum.Add(0);
            spawns.Add(0);
            GameObject bullet = bulletTypes[x].gameObject;
            GameObject enemy = enemyTypes[x].gameObject;
            for (int y = 0; y < allEnemies[x].Length; y++)
            {
                GameObject tempEnemy = Instantiate(enemy, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempEnemy.SetActive(false);
                allEnemies[x][y] = tempEnemy;
            }
            for (int z = 0; z < allBullets[x].Length; z++)
            {
                GameObject tempBullet = Instantiate(bullet, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempBullet.SetActive(false);
                allBullets[x][z] = tempBullet;
            }
        }
	}

    public GameObject[] allBull(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allBullets[x];
        }
        return null;
    }


    public GameObject[] allEnem(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allEnemies[x];
        }
        return null;
    }

	public void num(int x) {
        enemyNum[x] -= 1;
	}

    public void decrementShot(int x)
    {
        shotsTaken[x] -= 1;
    }

    public void incrementShot(int x)
    {
        shotsTaken[x] += 1;
    }

    public int returnShot(int x)
    {
        return shotsTaken[x];
    }
	
	// Update is called once per frame
	void Update () {

        for (int x = 0; x < 4; x++)
        {
            if (Time.time > delay[x] && Time.time > nextTime[x] && spawns[x] < max && enemyNum[x] < screenLimit)
            {
                nextTime[x] = Time.time + spawnTime[x];
                GameObject temp = allEnemies[x][enemyNum[x]];
                temp.transform.position = new Vector3(startingPos[x].x, startingPos[x].y, 0);
                temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
                temp.gameObject.SetActive(true);
                enemyNum[x] += 1;
                spawns[x] += 1;
            }
        }
	}
}