using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {


    public GameObject player;

    static public int[][] MapChip = new int[][]
    {
        new int[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        new int[]{1,2,3,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        //10
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        new int[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

    public GameObject[] obj;
    private GameObject Empty;
    private static int _playerX = 3;
    private static int _playerY = 1;
    //ハコ、置き場、壁、無、
    //プレイヤー初期位置

    // Use this for initialization
    void Start () {
        Empty = GameObject.Find("Stages");

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameObject chip=null;
                switch (MapChip[i][j])
                {
                    case 0: chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 1: chip = Instantiate(obj[1], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 2: chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        chip = Instantiate(obj[2], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 3:
                        chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        chip = Instantiate(obj[3], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 4:
                        chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        chip = Instantiate(obj[4], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        break;
                }
                chip.name = "[" + i + "," + j + "]";
                chip.transform.parent = Empty.transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (player.GetComponent<PlayerMove>().getMoveDirection())
        {
            case 0: break;
            case 1:
                if(MapChip[_playerY][_playerX - 1] == 3&& MapChip[_playerY][_playerX - 2] != 1)
                {
                    iTween.MoveBy(GameObject.Find("[" + _playerY + "," + (_playerX-1) + "]"), iTween.Hash("x", -32f));
                    MapChip[_playerY][_playerX] = 0;
                    MapChip[_playerY][_playerX - 1] = 3;

                }
                _playerX--;
                break;
            case 2:
                if (MapChip[_playerY][_playerX + 1] == 3 && MapChip[_playerY][_playerX + 2] != 1)
                {
                    iTween.MoveBy(GameObject.Find("[" + _playerY + "," + (_playerX + 1) + "]"), iTween.Hash("x", 32f));
                    MapChip[_playerY][_playerX + 1] = 3;
                }
                _playerX++;
                break;
            case 3:
                if (MapChip[_playerY + 1][_playerX] == 3 && MapChip[_playerY + 2][_playerX] != 1)
                {
                    iTween.MoveBy(GameObject.Find("[" + (_playerY+1) + "," + _playerX + "]"), iTween.Hash("y", 32f));
                    MapChip[_playerY + 1][_playerX ] = 3;
                }
                _playerY--;
                break;
            case 4:
                if (MapChip[_playerY -1 ][_playerX] == 3 && MapChip[_playerY-2][_playerX] != 1)
                {
                    iTween.MoveBy(GameObject.Find("[" + (_playerY - 1) + "," + _playerX + "]"), iTween.Hash("y", 32f));
                    MapChip[_playerY - 1][_playerX] = 3;
                }
                _playerY++;
                break;
        }
        Debug.Log(_playerX);
        Debug.Log(_playerY);
        //Debug.Log(MapChip[_playerY][_playerX]);

    }
    public bool isthrough(string dire)
    {
        switch (dire) {
            case "left":
                if (MapChip[_playerY ][_playerX-1] == 1)
                    return false;
                break;
            case "right":
                if (MapChip[_playerY][_playerX+1] == 1)
                {
                    Debug.Log("右");
                    return false;
                }
                break;
            case "up":
                if (MapChip[_playerY-1][_playerX ] == 1)
                    return false;
                break;
            case "down":
                if (MapChip[_playerY+1][_playerX] == 1)
                    return false;
                break;
        }
        return true;
    }
    public int[] getPlayerPos()
    {
        int[] Pos = null;
        Pos[0] = _playerX;
        Pos[1] = _playerY;
        return Pos;
    }
}
