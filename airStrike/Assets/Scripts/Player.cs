using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 curPos = transform.position;
        if(Input.GetKey(KeyCode.A))
        {
            curPos.x -= GameConstants.kPlayerMoveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            curPos.x += GameConstants.kPlayerMoveSpeed * Time.deltaTime;
        }

        if(curPos.x < GameConstants.kLeftBorder)
        {
            curPos.x = GameConstants.kLeftBorder;
        }
        if(curPos.x > GameConstants.kRightBorder)
        {
            curPos.x = GameConstants.kRightBorder;
        }
        transform.position = curPos;
	}
}
