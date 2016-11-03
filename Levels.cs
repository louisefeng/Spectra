using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

    bool menu;
    bool levelSelect;
    bool options;
    int menuPos; //0 is start, 1 is options, 2 is exit
    int level; //number of level selected
    static bool[] availableLevels = new bool[10]; //10 is arbitrary last level

	// Use this for initialization
	void Start () {
        menuPos = 0;
        menu = true;
        levelSelect = false;
        options = false;
        print("menu: " + menu);
        print("levelSelect: " + levelSelect);
        availableLevels[0] = true;
        availableLevels[1] = true;
        availableLevels[2] = true;
	}

    void OnGUI()
    {
        GUI.color = Color.white;
        if (levelSelect)
        {
            GUI.color = Color.white;
            GUI.Label(new Rect(100, 100, 100, 100), level.ToString());
        }
        if (menu)
        {
            GUI.color = Color.white;
            GUI.Label(new Rect(100, 100, 100, 100), menuToString(menuPos));
        }
    }

    string menuToString(int x)
    {
        switch (x) {
            case 0:
                return "level select";
            case 1:
                return "options";
            case 2:
                return "exit";
        }
        return "null";
    }

    public void start()
    {
        menu = false;
        levelSelect = true;
    }

    public void option()
    {
        menu = false;
        options = true;
    }

    public void exit()
    {
        //do exiting stuff
    }

    // Update is called once per frame
    void Update ()
    {
        if (levelSelect)
        {
            if (Input.GetKeyUp("right"))
            {
                if (level < 10 && availableLevels[level + 1]) //arbitrary last level
                {
                    level += 1;
                }
            }
            if (Input.GetKeyUp("left"))
            {
                if (level > 0)
                {
                    level -= 1;
                }
            }
            if (Input.GetKeyUp("space"))
            {
                SceneManager.GetSceneByName(level.ToString());
                gameObject.SetActive(false);
            }
        }
        if (menu)
        {
            if (Input.GetKeyUp("down"))
            {
                if (menuPos != 2)
                {
                    menuPos += 1;
                }
            }
            if (Input.GetKeyUp("up"))
            {
                if (menuPos != 0)
                {
                    menuPos -= 1;
                }
            }
            if (Input.GetKeyUp("space"))
            {
                switch(menuPos)
                {
                    case 0:
                        menu = false;
                        levelSelect = true;
                        //yield return new WaitUntil(Input.GetKeyUp("space"));
                        //start the game, go to select level;
                        break;
                    case 1:
                        menu = false;
                        options = true;
                        //go to options menu;
                        break;
                    case 2:
                        //close the game;
                        break;
                }
            }
        }
	}
}
