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
        new int[]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
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
                    case 0:chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 1: chip = Instantiate(obj[1], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 2: chip = Instantiate(obj[2], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 3: chip = Instantiate(obj[3], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity); break;
                    case 4:
                        chip = Instantiate(obj[0], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        chip = Instantiate(obj[4], new Vector2((j * 32) - 320 + 16, i * -32 + 240 - 16), Quaternion.identity);
                        break;
                }
                chip.transform.parent = Empty.transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        //switch (player.GetComponent<PlayerMove>().getMoveDirection())
        //{
        //    case 0: break;
        //    case 1:
        //        _playerX--;
        //        break;
        //    case 2:
        //        _playerX++;
        //        break;
        //    case 3:
        //        _playerY--;
        //        break;
        //    case 4:
        //        _playerY++;
        //        break;
        //}
        //Debug.Log(_playerX);
        //Debug.Log(_playerY);
        //Debug.Log(MapChip[14][1]);

    }
    public bool isthrough(string dire)
    {
        switch (dire) {
            case "left":
                if (MapChip[_playerX - 1][_playerY] == 1)
                    return false;
                break;
            case "right":
                if (MapChip[_playerX + 1][_playerY] == 1)
                    return false;
                break;
            case "up":
                if (MapChip[_playerX][_playerY - 1] == 1)
                    return false;
                break;
            case "down":
                if (MapChip[_playerX][_playerY + 1] == 1)
                    return false;
                break;
        }
        return true;
    }
    public int[] getPlayerPositon()
    {
        int[] playerPos= { 0,0};

        playerPos[0] = _playerX;
        playerPos[1] = _playerY;

        return playerPos;
    }
}
