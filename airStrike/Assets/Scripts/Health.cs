using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


    int mCurHealth;

    public delegate void onHealthZero();
    onHealthZero mDeathFunc = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    public void setCurrentHealth(int curHealth)
    {
        mCurHealth = curHealth;
    }

    public void addHealth(int addedValue)
    {
        mCurHealth += addedValue;
    }

    public void decreaseHealth(int decreaseValue)
    {
        mCurHealth -= decreaseValue;
        if (mCurHealth <= 0f)
        {
            mDeathFunc();
        }
    }

    public void setDeathFunc(onHealthZero func)
    {
        mDeathFunc = func;
    }
}
