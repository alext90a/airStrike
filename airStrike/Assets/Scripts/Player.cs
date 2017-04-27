using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {

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
        mStrikeManager = GameManager.getInstance().getStrikeStore();
        mScoreText = GameManager.getInstance().getPlayerScoreText();
        mHealth.setCurrentHealth(GameConstants.kPlayerStartHealth);
        mHealth.setDeathFunc(onZeroHealth);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!isLocalPlayer)
        {
            return;
        }

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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    void onZeroHealth()
    {
        Debug.Log("Player is destroyed");
        Strike strike = mStrikeManager.getNext() as Strike;
        strike.activate(transform.position, mStrikeManager);

        //GameObject.Destroy(gameObject);
    }

    void addScore()
    {
        mCurScore += 10;
        mScoreText.text = mCurScore.ToString();
    }

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
    }
}
