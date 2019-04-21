using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointButton : MonoBehaviour
{
    private ClickPointCreatePolygon checkPointCreate;
    private Vector3 nowPos;

    // Start is called before the first frame update
    void Start()
    {
        checkPointCreate = GameObject.Find("ClickPointCreatePolygon").GetComponent<ClickPointCreatePolygon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNowPos(Vector3 pos)
    {
        nowPos = pos;
    }

    //チェックポイントボタン
    public void OnClickCheckButton()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        checkPointCreate.CheckButtonDown(Camera.main.ScreenToWorldPoint(mousePos));
        Debug.Log(mousePos);
        // TODO : ここで現在座標のVector3が欲しい
        //checkPointCreate.CheckButtonDown(nowPos)
    }

    //囲うボタン
    public void OnClickEnCloseButton()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        checkPointCreate.EncloseButtonDown(Camera.main.ScreenToWorldPoint(mousePos));
        // TODO : ここで現在座標のVector3が欲しい
        //checkPointCreate.EncloseButton(nowPos);
    }
}
