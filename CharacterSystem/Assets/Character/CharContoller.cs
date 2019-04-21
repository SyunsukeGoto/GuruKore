using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharContoller : MonoBehaviour
{
    //キャラの種類
    enum CharValue
    {
        CAT1,
        CAT2,
        CAT3,
        MAX_CHAR
    }
    //キャラのデータ
    //キャラ１
    float[] time = new float[(int)CharValue.MAX_CHAR];
    Vector3[] scale = new Vector3[(int)CharValue.MAX_CHAR];

    [SerializeField]
    GameObject[] _charPre = new GameObject[(int)CharValue.MAX_CHAR];    //キャラのプレハブ
    GameObject[] _char;                                                 //インスタンス用のオブジェ


    // Start is called before the first frame update
    void Start()
    {
        //データの保存
        _char = new GameObject[(int)CharValue.MAX_CHAR];

        scale[(int)CharValue.CAT1] = new Vector3(1, 1, 1);
        time[(int)CharValue.CAT1] = 5.0f;

        scale[(int)CharValue.CAT2] = new Vector3(1, 1, 1);
        time[(int)CharValue.CAT2] = 5.0f;

        scale[(int)CharValue.CAT3] = new Vector3(2, 2, 1);
        time[(int)CharValue.CAT3] = 5.0f;

        //インスタンス化
        _char[(int)CharValue.CAT1] = Instantiate(_charPre[(int)CharValue.CAT1], new Vector3(0, 0, 0), Quaternion.identity);
        _char[(int)CharValue.CAT1].SetActive(true);

        _char[(int)CharValue.CAT2] = Instantiate(_charPre[(int)CharValue.CAT2], new Vector3(3, 3, 3), Quaternion.identity);
        _char[(int)CharValue.CAT2].SetActive(true);

        _char[(int)CharValue.CAT3] = Instantiate(_charPre[(int)CharValue.CAT3], new Vector3(-3, -3, -3), Quaternion.identity);
        _char[(int)CharValue.CAT3].SetActive(true);

        //データの格納
        CharData cat1 = _char[(int)CharValue.CAT1].GetComponent<CharData>();
        cat1.SetScale(scale[(int)CharValue.CAT1]);
        cat1.SetTime(time[(int)CharValue.CAT1]);

        CharData cat2 = _char[(int)CharValue.CAT2].GetComponent<CharData>();
        cat2.SetScale(scale[(int)CharValue.CAT2]);
        cat2.SetTime(time[(int)CharValue.CAT2]);

        CharData cat3 = _char[(int)CharValue.CAT3].GetComponent<CharData>();
        cat3.SetScale(scale[(int)CharValue.CAT3]);
        cat3.SetTime(time[(int)CharValue.CAT3]);

        Debug.Log("時間" + _char[(int)CharValue.CAT1].GetComponent<CharData>().GetTime());
        Debug.Log("スケール" + _char[(int)CharValue.CAT1].GetComponent<CharData>().GetScale());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

