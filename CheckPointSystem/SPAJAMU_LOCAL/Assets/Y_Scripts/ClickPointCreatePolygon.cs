using UnityEngine;
using System.Collections;

public class ClickPointCreatePolygon : MonoBehaviour
{
    private Vector3 checkPointPos;
    [SerializeField]
    private Material cubeMaterial;
    GameObject[] cubeArray;         //チェックポイントの排列
    int cubeIndex = 0;              //生成されているチェックポイントの数

    //デバッグ用
    public bool isDebug;

    void Start()
    {
        cubeArray = new GameObject[100];
        Vector3 cubePos = new Vector3(0, 0, -100f);
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i] = CreateCube(cubePos);
            cubeArray[i].transform.parent = this.transform;
        }
        CubePosReset();
    }

    void Update()
    {
        //デバッグ用
        if (isDebug)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (cubeIndex <= cubeArray.Length - 2)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = 10f;
                    AddPolygonPoint(Camera.main.ScreenToWorldPoint(mousePos));
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                if (cubeIndex >= 2)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = 10f;
                    AddPolygonPoint(Camera.main.ScreenToWorldPoint(mousePos));
                    CreatePolygon();
                    CubePosReset();
                }
            }
        }
    }


    //チェックポイントのリセット
    private void CubePosReset()
    {
        Vector3 cubePos = new Vector3(0, 0, -100f);
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].transform.position = cubePos;
        }
        cubeIndex = 0;
    }

    //チェックポイント用のオブジェクトの生成
    private GameObject CreateCube(Vector3 pos)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material = cubeMaterial;
        cube.transform.position = pos;
        float scale = 0.4f;
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }

    //チェックポイントを追加
    private void AddPolygonPoint(Vector3 pos)
    {
        // 座標を把握するCubeの生成位置を手動で設定しているので変更が必要になるかもしれない
        // pos.z = 10f;
        cubeArray[cubeIndex++].transform.position = pos;
        if (cubeIndex >= 2 &&
            cubeArray[cubeIndex - 2].transform.position == cubeArray[cubeIndex - 1].transform.position)
        {
            Destroy(cubeArray[cubeIndex]);
            cubeIndex--;
        }
    }

    //ポリゴンを生成
    private void CreatePolygon()
    {
        Mesh mesh = new Mesh();

        //メッシュの頂点を設定
        Vector3[] vertices = new Vector3[cubeIndex];
        for (int i = 0; i < cubeIndex; i++)
        {
            vertices[i] = cubeArray[i].transform.position;
        }
        mesh.vertices = vertices;

        //
        Vector2[] verticesXY = new Vector2[cubeIndex];
        for (int i = 0; i < cubeIndex; i++)
        {
            Vector3 pos = cubeArray[i].transform.position;
            verticesXY[i] = new Vector2(pos.x, pos.y);
        }
        Triangulator tr = new Triangulator(verticesXY, Camera.main.transform.position);
        //
        int[] indices = tr.Triangulate();
        //三角測量
        mesh.triangles = indices;

        //Mashのベースとなるテクスチャの座標
        mesh.uv = new Vector2[cubeIndex];

        // メッシュ変更時の法線の再計算
        mesh.RecalculateNormals();
        // バウンディングボリュームの再計算
        mesh.RecalculateBounds();

        //Meshの生成.機能を追加
        GameObject obj = new GameObject("Area");
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Diffuse"));
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        //エリアに沿ったPolygonの生成
        PolygonCollider2D polygonCollider = obj.AddComponent<PolygonCollider2D>();
        polygonCollider.CreatePrimitive(cubeIndex);
        polygonCollider.points = verticesXY;
        polygonCollider.isTrigger = true;
        obj.AddComponent<Area>();
        Vector3 objPos = obj.transform.position;
    }

    //チェックポイントボタンが押されたら
    public void CheckButtonDown(Vector3 pos)
    {
        if (cubeIndex <= cubeArray.Length - 2)
        {
            AddPolygonPoint(pos);
        }
    }

    //囲うボタンが押されたら
    public void EncloseButtonDown(Vector3 pos)
    {
        if (cubeIndex >= 2)
        {
            AddPolygonPoint(pos);
            CreatePolygon();
            CubePosReset();
        }
    }
}
