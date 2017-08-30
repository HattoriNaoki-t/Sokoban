using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    private static int _movedirection;

    public GameObject stage;

    public float buttonWait=1.05f;

    public bool buttonDown = false;

    // Use this for initialization
    void Start () {
        _movedirection = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _movedirection = 0;

        if (stage.GetComponent<Stage>().isthrough("left") && Input.GetKeyDown(KeyCode.LeftArrow)&&buttonDown == false)
        {
            buttonDown = true;
            //gameObject.transform.Translate(new Vector2(-32,0));
            iTween.MoveBy(gameObject, iTween.Hash("x", -32f));
            _movedirection = 1;
        }
        if (stage.GetComponent<Stage>().isthrough("right") && Input.GetKeyDown(KeyCode.RightArrow) && buttonDown == false)
        {
            buttonDown = true;
            iTween.MoveBy(gameObject, iTween.Hash("x", 32f));
            _movedirection = 2;
        }
        if (stage.GetComponent<Stage>().isthrough("up") && Input.GetKeyDown(KeyCode.UpArrow) && buttonDown == false)
        {
            buttonDown = true;
            iTween.MoveBy(gameObject, iTween.Hash("y", 32f));
            _movedirection = 3;
        }
        if (stage.GetComponent<Stage>().isthrough("down") && Input.GetKeyDown(KeyCode.DownArrow) && buttonDown == false)
        {
            buttonDown = true;
            iTween.MoveBy(gameObject, iTween.Hash("y", -32f));
            _movedirection = 4;
        }
        if(buttonDown == true)
        {
            buttonWait -= Time.deltaTime;
        }
        if(buttonWait < 0)
        {
            buttonWait = 1.05f;
            buttonDown = false;
        }

    }
    public int getMoveDirection()
    {
        return _movedirection;
    }
}
