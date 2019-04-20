using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharData : MonoBehaviour
{
    //メンバ変数
    float _charTime;       //出現時間
    bool _tFlag = false;   //カウントを始めるか

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //一定時間を過ぎたら出現をやめる
        if (_tFlag)
        {
            _charTime -= Time.deltaTime;
        }

        if (_charTime <= 0)
        {
            _tFlag = false;
            gameObject.SetActive(false);
        }
    }

    //ゲームオブジェクトの変換
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    //出現時間をセット
    public void SetTime(float time)
    {
        _charTime = time;
        _tFlag = true;
    }

    //出現時間のゲット
    public int GetTime()
    {
        return (int)_charTime;
    }

    //Scaleの設定
    public void SetScale(Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }

    //Scaleのゲット 
    public Transform GetScale()
    {
        return gameObject.transform;
    }

    public Collider2D GetRd()
    {
        return gameObject.GetComponent<Collider2D>();
    }
}

