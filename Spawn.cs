using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
    //public int[] total;
    //our temporary limit on enemies is 20 of each type, maximum 200 bullets (these numbers can be changed)
    private static List<GameObject> inactiveEnemyList0 = new List<GameObject>();
    private static List<GameObject> inactiveEnemyList1 = new List<GameObject>();
    private static List<GameObject> inactiveEnemyList2 = new List<GameObject>();
    private static List<GameObject> inactiveEnemyList3 = new List<GameObject>();
    private static List<GameObject> activeEnemyList0 = new List<GameObject>();
    private static List<GameObject> activeEnemyList1 = new List<GameObject>();
    private static List<GameObject> activeEnemyList2 = new List<GameObject>();
    private static List<GameObject> activeEnemyList3 = new List<GameObject>();
    private static List<GameObject> inactiveBulletList0 = new List<GameObject>();
    private static List<GameObject> inactiveBulletList1 = new List<GameObject>();
    private static List<GameObject> inactiveBulletList2 = new List<GameObject>();
    private static List<GameObject> inactiveBulletList3 = new List<GameObject>();
    private static List<GameObject> activeBulletList0 = new List<GameObject>();
    private static List<GameObject> activeBulletList1 = new List<GameObject>();
    private static List<GameObject> activeBulletList2 = new List<GameObject>();
    private static List<GameObject> activeBulletList3 = new List<GameObject>();
    
    public List<int> max = new List<int>();
    public List<int> screenLimit = new List<int>();

    private List<movement> enemyTypes = new List<movement>(); 
    private List<enemyShoot> bulletTypes = new List<enemyShoot>();
    private List<List<GameObject>> allEnemies = new List<List<GameObject>>() { inactiveEnemyList0, inactiveEnemyList1, inactiveEnemyList2, inactiveEnemyList3 };
    private List<List<GameObject>> allBullets = new List<List<GameObject>>() { inactiveBulletList0, inactiveBulletList1, inactiveBulletList2, inactiveBulletList3 };
    private List<List<GameObject>> activeEnemies = new List<List<GameObject>>() { activeEnemyList0, activeEnemyList1, activeEnemyList2, activeEnemyList3 };
    private List<List<GameObject>> activeBullets = new List<List<GameObject>>() { activeBulletList0, activeBulletList1, activeBulletList2, activeBulletList3 };
    
    public List<Vector2> movementDirection = new List<Vector2>(4);
    private List<double> nextTime = new List<double>();
    public List<float> speed = new List<float>();
    public List<double> moveTime = new List<double>();
    public List<double> shootingTime = new List<double>();
    public List<float> bulletSpeed = new List<float>();
    public List<Vector2> startingPos = new List<Vector2>();
    public List<Vector2> maxPos = new List<Vector2>();
    public List<double> delay = new List<double>();
    public List<double> spawnTime = new List<double>();

    private List<int> enemyNum = new List<int>();
    private List<int> spawns = new List<int>();
    private List<int> shotsTaken = new List<int>();

    public movement enemy0;
    public enemyShoot bullet0;
    public movement enemy1;
    public enemyShoot bullet1;
    public movement enemy2;
    public enemyShoot bullet2;
    public movement enemy3;
    public enemyShoot bullet3;

    int totalEnemies;
    int killedEnemies;
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
            totalEnemies += max[x];
            shotsTaken.Add(0);
            nextTime.Add(0);
            enemyNum.Add(0);
            spawns.Add(0);
            GameObject bullet = bulletTypes[x].gameObject;
            GameObject enemy = enemyTypes[x].gameObject;
            for (int y = 0; y < max[x]; y++)
            {
                GameObject tempEnemy = Instantiate(enemy, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempEnemy.SetActive(false);
                allEnemies[x].Add(tempEnemy);
            }
            for (int z = 0; z < max[x] * 20; z++)
            {
                GameObject tempBullet = Instantiate(bullet, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempBullet.SetActive(false);
                allBullets[x].Add(tempBullet);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        for (int x = 0; x < 4; x++)
        {
            if (Time.time > delay[x] && Time.time > nextTime[x] && spawns[x] < max[x] && enemyNum[x] < screenLimit[x])
            {
                int last = allEnemies[x].Count - 1;
                nextTime[x] = Time.time + spawnTime[x];
                GameObject temp = allEnemies[x][last];
                allEnemies[x].RemoveAt(last);
                temp.transform.position = new Vector3(startingPos[x].x, startingPos[x].y, 0);
                temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
                temp.gameObject.SetActive(true);
                enemyNum[x] += 1;
                spawns[x] += 1;
            }
        }
        if (killedEnemies == totalEnemies)
        {
            //level won
        }

    }
    public List<GameObject> allBull(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allBullets[x];
        }
        return null;
    }


    public List<GameObject> allEnem(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allEnemies[x];
        }
        return null;
    }

    public void num(int x)
    {
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

    public void removeBullet(int type)
    {
        allBullets[type].RemoveAt(allBullets[type].Count - 1);
    }

    public void addBullet(int type, GameObject bullet)
    {
        allBullets[type].Add(bullet);
    }

    public void removeEnemy(int type, GameObject enemy)
    {
        allEnemies[type].RemoveAt(allEnemies[type].Count - 1);
    }

    public void addEnemy(int type, GameObject enemy)
    {
        killedEnemies += 1;
        allEnemies[type].Add(enemy);
    }
}