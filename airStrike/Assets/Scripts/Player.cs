using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    Health mHealth = null;
    [SerializeField]
    Weapon mCurWeapon = null;
    [SerializeField]
    Text mScoreText = null;
    [SerializeField]
    RespawnableManager mStrikeManager = null;

    int mCurScore = 0;
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
            mCurWeapon.launchBullet(addScore);
        }
	}

    void onZeroHealth()
    {
        Debug.Log("Player is destroyed");
        Strike strike = mStrikeManager.getNext() as Strike;
        strike.activate(transform.position, mStrikeManager);

        GameObject.Destroy(gameObject);
    }

    void addScore()
    {
        mCurScore += 10;
        mScoreText.text = mCurScore.ToString();
    }
}
