using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class Levels : MonoBehaviour {

    public int one;
    public int two;
    bool menu;
    bool levelSelect;
    bool options;
    int menuPos; //0 is start, 1 is options, 2 is exit
    int level = 1; //number of level selected
    int optionsPos;
    static bool[] availableLevels = new bool[10]; //10 is arbitrary last level

    int levelFactor = 0; //factor of which set of 5 is being viewed

    List<GameObject> buttons = new List<GameObject>();
    List<string> buttonNames = new List<string>() { "Button0", "Button1", "Button2", "Button3", "Button4" };
    

    // Use this for initialization
    void Start () {
        menuPos = 0;
        menu = true;
        levelSelect = false;
        options = false;

        for (int x = 0; x < 5; x++)
        {            
            GameObject temp = GameObject.Find(buttonNames[x]);
            buttons.Add(temp);
            buttons[x].SetActive(false);
        }
        
        availableLevels[1] = true;
    }

    void OnGUI()
    {
        GUI.color = Color.white;
        if (options)
        {
            GUI.Label(new Rect(150, 100, 100, 100), optionsToString(optionsPos));
        }
        if (levelSelect)
        {
            GUI.Label(new Rect(150, 100, 100, 100), level.ToString());
        }
        if (menu)
        {
            GUI.Label(new Rect(150, 100, 100, 100), menuToString(menuPos));
        }
    }

    void clearButtons()
    {
        for (int x = 0; x < 5; x++)
        {
            buttons[x].SetActive(false);
        }
    }

    void start()
    {
        clearButtons();
        List<Vector3> positions = new List<Vector3>() { new Vector3(190, 200, 0), new Vector3(290, 100, 0), new Vector3(390, 200, 0), new Vector3(490, 100, 0), new Vector3(590, 200, 0) };
        List<Vector2> sizes = new List<Vector2>() { new Vector2(30, 30), new Vector2(30, 30), new Vector2(30, 30), new Vector2(30, 30), new Vector2(30, 30), new Vector2(30, 30) };
        List<int> buttonTexts = new List<int>() { 1 + levelFactor, 2 + levelFactor, 3 + levelFactor, 4 + levelFactor, 5 + levelFactor };
        for (int x = 0; x < 5; x++)
        {
            buttons[x].GetComponent<RectTransform>().position = positions[x];
            buttons[x].GetComponent<RectTransform>().sizeDelta = sizes[x];
            buttons[x].GetComponentInChildren<Text>().text = buttonTexts[x].ToString();
            buttons[x].SetActive(true);
        }
        menu = false;
        levelSelect = true;
        options = false;
    }

    void menuHelper()
    {
        clearButtons();
        menu = true;
        options = false;
        levelSelect = false;
        List<Vector3> positions = new List<Vector3>() { new Vector3(540, 200, 0), new Vector3(540, 165, 0), new Vector3(540, 130, 0) };
        List<Vector2> sizes = new List<Vector2>() { new Vector2(110, 30), new Vector2(110, 30), new Vector2(110, 30) };
        List<string> buttonTexts = new List<string>() { "Start", "Options", "Exit" };
        for (int x = 0; x < 3; x++)
        {
            buttons[x].GetComponent<RectTransform>().position = positions[x];
            buttons[x].GetComponent<RectTransform>().sizeDelta = sizes[x];
            buttons[x].GetComponentInChildren<Text>().text = buttonTexts[x].ToString();
            buttons[x].SetActive(true);
        }
    }

    public void option()
    {
        
        List<Vector3> positions = new List<Vector3>() { new Vector3(240, 220, 0), new Vector3(240, 180, 0), new Vector3(240, 140, 0), new Vector3(240, 100, 0) };
        List<Vector2> sizes = new List<Vector2>() { new Vector2(110, 30), new Vector2(110, 30), new Vector2(110, 30), new Vector2(110, 30) };
        List<string> buttonTexts = new List<string>() { "Sound Effects", "Music", "Input", "Credits" };
        for (int x = 0; x < 4; x++)
        {
            buttons[x].GetComponent<RectTransform>().position = positions[x];
            buttons[x].GetComponent<RectTransform>().sizeDelta = sizes[x];
            buttons[x].GetComponentInChildren<Text>().text = buttonTexts[x];
            buttons[x].SetActive(true);
        }
        menu = false;
        options = true;
        levelSelect = false;
    }

    public void exit()
    {
        //do exiting stuff
    }

    // Update is called once per frame
    void Update ()
    {
        if (options)
        {
            if (Input.GetKeyUp("down"))
            {
                if (optionsPos != 3)
                {
                    optionsPos += 1;
                }
            }
            if (Input.GetKeyUp("up"))
            {
                if (optionsPos != 0)
                {
                    optionsPos -= 1;
                }
            }
            if (Input.GetKeyUp("z"))
            {
                //do something based on optionsPos
            }
            if (Input.GetKeyUp("x"))
            {
                menuHelper();
            }
        }
        if (levelSelect)
        {
            if (Input.GetKeyUp("right"))
            {
                if (level < 10 && availableLevels[level + 1]) //arbitrary last level
                {
                    if (level - 1 % 5 ==  4)
                    {
                        levelFactor += 5;
                        start();
                    }
                    level += 1;
                }
            }
            if (Input.GetKeyUp("left"))
            {
                if (level > 1 && availableLevels[level - 1])
                {
                    if ((level - 1) % 5 == 0)
                    {
                        levelFactor -= 5;
                        start();
                    }
                    level -= 1;
                }
            }
            if (Input.GetKeyUp("z"))
            {
                SceneManager.GetSceneByName(level.ToString());
                gameObject.SetActive(false);
            }
            if (Input.GetKeyUp("x"))
            {
                menuHelper();
            }
        }
        if (menu)
        {
            menuHelper();
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
            if (Input.GetKeyUp("z"))
            {
                switch(menuPos)
                {
                    case 0:
                        start();
                        break;
                    case 1:
                        option();
                        break;
                    case 2:
                        //close the game;
                        break;
                }
            }
        }
	}

    string menuToString(int x)
    {
        switch (x)
        {
            case 0:
                return "level select";
            case 1:
                return "options";
            case 2:
                return "exit";
        }
        return "null";
    }

    string optionsToString(int x)
    {
        switch (x)
        {
            case 0:
                return "sound fx";
            case 1:
                return "music";
            case 2:
                return "inputs";
            case 3:
                return "credits";
        }
        return "null";
    }

}
