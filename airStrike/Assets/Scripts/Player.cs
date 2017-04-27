using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    Health mHealth = null;
    [SerializeField]
    Weapon mCurWeapon = null;

	// Use this for initialization
	void Start () {
        mHealth.setCurrentHealth(GameConstants.kPlayerStartHealth);
        mHealth.setDeathFunc(onZeroHealth);
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            mCurWeapon.launchBullet();
        }
	}

    void onZeroHealth()
    {
        Debug.Log("Player is destroyed");
    }
}
