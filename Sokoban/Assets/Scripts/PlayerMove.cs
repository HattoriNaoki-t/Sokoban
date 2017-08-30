using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    private static int _movedirection;

    public GameObject stage;

    [SerializeField, Range(0, 10)]
    float time = 1;
    Vector2 endPosition;
    private bool moveflag = false; 


    // Use this for initialization
    void Start () {
        _movedirection = 0;

        stage.GetComponent<Stage>().getPlayerPositon();

    }
	
	// Update is called once per frame
	void Update ()
    {
        _movedirection = 0;

        if (_movedirection == 0)
        {
            stage.GetComponent<Stage>().getPlayerPositon();
        }

        if (stage.GetComponent<Stage>().isthrough("left") && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _movedirection = 1;
        }
        if (stage.GetComponent<Stage>().isthrough("right") && Input.GetKeyDown(KeyCode.RightArrow))
        {
            _movedirection = 2;
        }
        if (stage.GetComponent<Stage>().isthrough("up") && Input.GetKeyDown(KeyCode.UpArrow) )
        {
            _movedirection = 3;
        }
        if (stage.GetComponent<Stage>().isthrough("down") && Input.GetKeyDown(KeyCode.DownArrow))
        {
            _movedirection = 4;
        }
        if(_movedirection != 0)
        {
            moveflag = true;
        }
        endPosition = new Vector2(-304 + (stage.GetComponent<Stage>().getPlayerPositon()[0] - 32) * 32, 224 + stage.GetComponent<Stage>().getPlayerPositon()[1] * -32);
        if (endPosition != (Vector2)gameObject.transform.position)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y);
        }


        switch (_movedirection)
        {
            case 1:
                break;
            case 2:
                endPosition = new Vector2(-304 + stage.GetComponent<Stage>().getPlayerPositon()[0] * 32, 224 + stage.GetComponent<Stage>().getPlayerPositon()[1] * -32);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
                break;
            case 3:
                endPosition = new Vector2(-304 + stage.GetComponent<Stage>().getPlayerPositon()[0] * 32, 224 + stage.GetComponent<Stage>().getPlayerPositon()[1] * -32);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
                break;
            case 4:
                endPosition = new Vector2(-304 + stage.GetComponent<Stage>().getPlayerPositon()[0] * 32, 224 + stage.GetComponent<Stage>().getPlayerPositon()[1] * -32);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
                break;
        }
        
    }
    public int getMoveDirection()
    {
        return _movedirection;
    }
}
