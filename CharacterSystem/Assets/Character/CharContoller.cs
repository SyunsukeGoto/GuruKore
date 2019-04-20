using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharContoller : MonoBehaviour
{
    //キャラの種類
    enum CharValue
    {
        CAT = 1,
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

        scale[(int)CharValue.CAT] = new Vector3(1, 1, 1);
        time[(int)CharValue.CAT] = 5.0f;

        //インスタンス化
        _char[(int)CharValue.CAT] = Instantiate(_charPre[(int)CharValue.CAT], new Vector3(0, 0, 0), Quaternion.identity);
        _char[(int)CharValue.CAT].SetActive(true);

        //データの格納
        CharData temp = _char[(int)CharValue.CAT].GetComponent<CharData>();
        temp.SetScale(scale[(int)CharValue.CAT]);
        temp.SetTime(time[(int)CharValue.CAT]);

        Debug.Log("時間" + _char[(int)CharValue.CAT].GetComponent<CharData>().GetTime());
        Debug.Log("スケール" + _char[(int)CharValue.CAT].GetComponent<CharData>().GetScale());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

