using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[RequireComponent(typeof(LineRenderer))]
public class TestDrawCam : MonoBehaviour {

    public enum VerName
    {
        B = 0,
        D,
        A,
        C,
        G,
        E,
        H,
        F
    }

    [Tooltip("视域")]
    [Range(1, 179)]  public int FieldofView = 60;

    [Tooltip("近截面")]
    public float NearPlane = 0.3f;

    [Tooltip("远截面")]
    public float FarPlane = 100;

    [Tooltip("材质球")]
    public Material CamMeta;

    public GameObject MyInsideViewObj;
    DrawInSideCameraView dicv;
    public GameObject GodCamera;

    int NumOfPoints = 17;
    LineRenderer linePoint;
    public Camera MyCam;


    Mesh CamMesh;
    Vector3[] Vertices;
    Vector2[] UVs;
    int[] TriangleNum;


    // Use this for initialization
    void Start() {


        Vertices = new Vector3[8]; //8
        TriangleNum = new int[6 * 2 * 3];
        UVs = new Vector2[8];

      //  MyCam = GetComponent<Camera>();
   //     MyCam.enabled = false;

        dicv = MyInsideViewObj.GetComponent<DrawInSideCameraView>();


        //for (int i = 0; i < 8; i++)
        //{
        //    GameObject go = CreateCubeObjByPos(Vertices[i],i);
        //}


        GodCamera.SetActive(false);
        gameObject.SetActive(false);


        //Test
        // InitMyDrawField();
    }

    public void InitMyDrawField()
    {
        if (CamMesh == null)
        {
            //然后初始化各个点的位置
            UpdateGetCamTwoPlaneClicp();
            //初始化LineRenderer组件
            InitLineCom();
            //初始化Mesh组件
            InitMyMesh();
        }
        MyInsideViewObj.SetActive(true);
        GodCamera.SetActive(true);

        Vector3 v = transform.position;
        v.y = 68;
        GodCamera.transform.position = v;
    }

    /// <summary>
    /// 初始化Mesh组件
    /// 8 个顶点 Vertices[8]
    /// 6 个面 = 12个三角形 TriangleNum[ 12*3 ]
    /// TriangleNum[0] 对应的值就是 Vertices[] 里面对应的点的坐标在数组里面的Index
    /// </summary>
    void InitMyMesh()
    {

        MeshFilter MeshFil = GetComponent<MeshFilter>();
        CamMesh = MeshFil.mesh;
        CamMesh.name = "LineCamMesh";
        GetComponent<Renderer>().material = CamMeta;


        //绘制出两面的模型
        AllPointContentToPoint();
        //  FanAllPointContentToPoint();
        setMeshUV();
        
        //设置Mesh
        UpdateSetCamMesh();
    }

    /// <summary>
    ///  初始化LineRenderer组件
    /// </summary>
    void InitLineCom()
    {

        linePoint = GetComponent<LineRenderer>();
        linePoint.SetVertexCount(NumOfPoints);
     //   linePoint.material = CamMeta;
     //   linePoint.SetWidth(0.5f, 0.5f);
     //   linePoint.SetColors(Color.blue, Color.blue);
    //    linePoint.useWorldSpace = false;

    }



    // Update is called once per frame
    void Update() {

            //xx设置相机的各种参数
            UpdateSetCamClipPlane();

            //获取相机的近远面的所有点
            UpdateGetCamTwoPlaneClicp();
            //  AllPointContentToPoint();
            //动态修改Mesh的属性
            UpdateSetCamMesh();
        


        //点和点直接用先连起来
        LineContentEachOne();

       

        

    }


    /// <summary>
    /// 动态修改Mesh 的属性
    /// </summary>
    void UpdateSetCamMesh()
    {
        CamMesh.Clear();

        CamMesh.vertices = Vertices;
        CamMesh.triangles = TriangleNum;
        CamMesh.uv = UVs;
      //  CamMesh.RecalculateBounds();
        CamMesh.RecalculateNormals();
    }


    //设置相机的两个面的距离
    void UpdateSetCamClipPlane()
    {
        MyCam.fieldOfView = FieldofView;
        MyCam.nearClipPlane = NearPlane;
        MyCam.farClipPlane = FarPlane;
    }

    /// <summary>
    /// 获取相机的两个面的所有点
    /// </summary>
    void UpdateGetCamTwoPlaneClicp()
    {
        //先初始化一下相机的参数
        //UpdateSetCamClipPlane();

        // Vector3 ParentPos = transform.parent.position;
        //Vector3 ParentPos = Vector3.zero;

        //因为这里是世界坐标   而且它是人家儿子 
        //儿子的世界坐标 = 父母的坐标 + 儿子的相对坐标
        //Vertices[(int)VerName.B] = MyCam.ViewportToWorldPoint(new Vector3(1, 1, MyCam.nearClipPlane)) - ParentPos;
        //Vertices[(int)VerName.D] = MyCam.ViewportToWorldPoint(new Vector3(0, 0, MyCam.nearClipPlane)) - ParentPos;
        //Vertices[(int)VerName.A] = MyCam.ViewportToWorldPoint(new Vector3(0, 1, MyCam.nearClipPlane)) - ParentPos;
        //Vertices[(int)VerName.C] = MyCam.ViewportToWorldPoint(new Vector3(1, 0, MyCam.nearClipPlane)) - ParentPos;

        //Vertices[(int)VerName.G] = MyCam.ViewportToWorldPoint(new Vector3(1, 1, MyCam.farClipPlane)) - ParentPos;
        //Vertices[(int)VerName.E] = MyCam.ViewportToWorldPoint(new Vector3(0, 0, MyCam.farClipPlane)) - ParentPos;
        //Vertices[(int)VerName.H] = MyCam.ViewportToWorldPoint(new Vector3(0, 1, MyCam.farClipPlane)) - ParentPos;
        //Vertices[(int)VerName.F] = MyCam.ViewportToWorldPoint(new Vector3(1, 0, MyCam.farClipPlane)) - ParentPos;

        Vector3[] NearPoints = GetCorners(MyCam.nearClipPlane);
        Vertices[(int)VerName.A] = NearPoints[0];
        Vertices[(int)VerName.B] = NearPoints[1];
        Vertices[(int)VerName.D] = NearPoints[2];
        Vertices[(int)VerName.C] = NearPoints[3];

        //Vector2 scalefactor = new Vector2(MyCam.rect.width, MyCam.rect.height);
        //Vector2 offset = new Vector2(MyCam.rect.x * Screen.width, MyCam.rect.y * Screen.height);
        //Vertices[(int)VerName.B] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width*1f*scalefactor.x)+offset.x,(Screen.height*1f*scalefactor.y)+offset.y,MyCam.nearClipPlane));
        //Vertices[(int)VerName.D] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width*0f*scalefactor.x)+offset.x,(Screen.height*0f*scalefactor.y)+offset.y,MyCam.nearClipPlane));
        //Vertices[(int)VerName.A] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width*0f*scalefactor.x)+offset.x,(Screen.height*1f*scalefactor.y)+offset.y,MyCam.nearClipPlane));
        //Vertices[(int)VerName.C] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width*1f*scalefactor.x)+offset.x,(Screen.height*0f*scalefactor.y)+offset.y,MyCam.nearClipPlane));

        //Vertices[(int)VerName.G] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width * 1f * scalefactor.x) + offset.x, (Screen.height * 1f * scalefactor.y) + offset.y, MyCam.farClipPlane));
        //Vertices[(int)VerName.E] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width * 0f * scalefactor.x) + offset.x, (Screen.height * 0f * scalefactor.y) + offset.y, MyCam.farClipPlane));
        //Vertices[(int)VerName.H] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width * 0f * scalefactor.x) + offset.x, (Screen.height * 1f * scalefactor.y) + offset.y, MyCam.farClipPlane));
        //Vertices[(int)VerName.F] = MyCam.ScreenToWorldPoint(new Vector3((Screen.width * 1f * scalefactor.x) + offset.x, (Screen.height * 0f * scalefactor.y) + offset.y, MyCam.farClipPlane));
        //Debug.DrawLine(Vertices[(int)VerName.A], Vertices[(int)VerName.B], Color.red);
        //Debug.DrawLine(Vertices[(int)VerName.B], Vertices[(int)VerName.C], Color.green);
        //Debug.DrawLine(Vertices[(int)VerName.C], Vertices[(int)VerName.D], Color.black);
        //Debug.DrawLine(Vertices[(int)VerName.D], Vertices[(int)VerName.A], Color.yellow);

        //hgfe
        Vector3[] FarPoints = GetCorners(MyCam.farClipPlane);
        Vertices[(int)VerName.H] = FarPoints[0];
        Vertices[(int)VerName.G] = FarPoints[1];
        Vertices[(int)VerName.E] = FarPoints[2];
        Vertices[(int)VerName.F] = FarPoints[3];

        //Debug.DrawLine(Vertices[(int)VerName.H], Vertices[(int)VerName.G], Color.red);
        //Debug.DrawLine(Vertices[(int)VerName.G], Vertices[(int)VerName.F], Color.green);
        //Debug.DrawLine(Vertices[(int)VerName.F], Vertices[(int)VerName.E], Color.black);
        //Debug.DrawLine(Vertices[(int)VerName.E], Vertices[(int)VerName.H], Color.yellow);


        ////bcgf
        //Vertices[8] = Vertices[(int)VerName.B];
        //Vertices[9] = Vertices[(int)VerName.C];
        //Vertices[10] = Vertices[(int)VerName.F];
        //Vertices[11] = Vertices[(int)VerName.G];

        ////cdfe
        //Vertices[12] = Vertices[(int)VerName.C];
        //Vertices[13] = Vertices[(int)VerName.D];
        //Vertices[14] = Vertices[(int)VerName.E];
        //Vertices[15] = Vertices[(int)VerName.F];

        ////bagh
        //Vertices[16] = Vertices[(int)VerName.B];
        //Vertices[17] = Vertices[(int)VerName.A];
        //Vertices[18] = Vertices[(int)VerName.G];
        //Vertices[19] = Vertices[(int)VerName.H];

        ////adeh
        //Vertices[20] = Vertices[(int)VerName.A];
        //Vertices[21] = Vertices[(int)VerName.D];
        //Vertices[22] = Vertices[(int)VerName.E];
        //Vertices[23] = Vertices[(int)VerName.H];


    }

    void setMeshUV()
    {

            UVs[0] = new Vector2(1, 0);
            UVs[1] = new Vector2(1, 0);
            UVs[2] = new Vector2(1, 0);

            UVs[3] = new Vector2(1, 0);
            UVs[4] = new Vector2(0.1f, 0);
            UVs[5] = new Vector2(0.1f, 0);
            UVs[6] = new Vector2(0.1f, 0);

    }

    GameObject CreateCubeObjByPos(Vector3 v,int i)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = v;

        Color c = Color.red;
        switch (i)
        {
            case 0: c = Color.red; break;
            case 1: c = Color.green; break;
            case 2: c = Color.yellow; break;
            case 3: c = Color.black; break;
            case 4: c = Color.blue; break;
            case 5: c = Color.white; break;
            case 6: c = Color.gray; break;
            case 7: c = Color.cyan; break;
            default: c = new Color(getRand(), getRand(), getRand()); break;
        }

        go.GetComponent<Renderer>().material.color = c;
        return go;
    }

    float getRand()
    {
        return Random.Range(0, 1.0f);
    }

    /// <summary>
    /// 将摄像机的范围用点连接起来
    /// </summary>
    void LineContentEachOne()
    {
        linePoint.SetPosition(0, Vertices[(int)VerName.A] ); //a
        linePoint.SetPosition(1, Vertices[(int)VerName.B] ); //b
        linePoint.SetPosition(2, Vertices[(int)VerName.C] ); //c
        linePoint.SetPosition(3, Vertices[(int)VerName.D] ); //d
        linePoint.SetPosition(4, Vertices[(int)VerName.A] ); //a
        linePoint.SetPosition(5, Vertices[(int)VerName.H] ); //h
        linePoint.SetPosition(6, Vertices[(int)VerName.G] ); //g
        linePoint.SetPosition(7, Vertices[(int)VerName.F] ); //f
        linePoint.SetPosition(8, Vertices[(int)VerName.E] ); //e
        linePoint.SetPosition(9, Vertices[(int)VerName.H] ); //h
        linePoint.SetPosition(10, Vertices[(int)VerName.A] ); //a
        linePoint.SetPosition(11, Vertices[(int)VerName.D] ); //d
        linePoint.SetPosition(12, Vertices[(int)VerName.E] ); //e
        linePoint.SetPosition(13, Vertices[(int)VerName.F] ); //f
        linePoint.SetPosition(14, Vertices[(int)VerName.C] ); //c
        linePoint.SetPosition(15, Vertices[(int)VerName.B] ); //b
        linePoint.SetPosition(16, Vertices[(int)VerName.G] ); //g

    }


    /// <summary>
    /// 将所有三角形的点赋值
    /// </summary>
    void AllPointContentToPoint()
    {
        
        //ABCD = cab + cda
        //CAB
        TriangleNum[0] = (int)VerName.C;
        TriangleNum[1] = (int)VerName.A;
        TriangleNum[2] = (int)VerName.B;
        //ABC
        TriangleNum[3] = (int)VerName.C;
        TriangleNum[4] = (int)VerName.D;
        TriangleNum[5] = (int)VerName.A;

        

        //CDEF = dhe + dah
        //CFE
        TriangleNum[6] = (int)VerName.C;
        TriangleNum[7] = (int)VerName.F;
        TriangleNum[8] = (int)VerName.E;
        //CED
        TriangleNum[9] = (int)VerName.C;
        TriangleNum[10] = (int)VerName.E;
        TriangleNum[11] = (int)VerName.D;


        //ABGH = bhg + bah
        //BHG
        TriangleNum[12] = (int)VerName.B;
        TriangleNum[13] = (int)VerName.H;
        TriangleNum[14] = (int)VerName.G;
        //BAH
        TriangleNum[15] = (int)VerName.B;
        TriangleNum[16] = (int)VerName.A;
        TriangleNum[17] = (int)VerName.H;


        //bcfg = cgf + cbg
        //cgf
        TriangleNum[18] = (int)VerName.C;
        TriangleNum[19] = (int)VerName.G;
        TriangleNum[20] = (int)VerName.F;
        //cbg
        TriangleNum[21] = (int)VerName.C;
        TriangleNum[22] = (int)VerName.B;
        TriangleNum[23] = (int)VerName.G;

        //ADEH 
        //ADE
        TriangleNum[24] = (int)VerName.A;
        TriangleNum[25] = (int)VerName.D;
        TriangleNum[26] = (int)VerName.E;
        //AEH
        TriangleNum[27] = (int)VerName.A;
        TriangleNum[28] = (int)VerName.E;
        TriangleNum[29] = (int)VerName.H;

        //GHEF = fhg + feh
        //fhg
        TriangleNum[30] = (int)VerName.G;
        TriangleNum[31] = (int)VerName.E;
        TriangleNum[32] = (int)VerName.F;
        //feh
        TriangleNum[33] = (int)VerName.G;
        TriangleNum[34] = (int)VerName.H;
        TriangleNum[35] = (int)VerName.E;

    }


    Vector3[] GetCorners(float distance)
    {
        Vector3[] corners = new Vector3[4];
        
        Transform tx = transform;
        float halfFOV = (MyCam.fieldOfView * 0.5f) * Mathf.Deg2Rad;
        float aspect = MyCam.aspect;

        float height = distance * Mathf.Tan( halfFOV );
        float width = height * aspect;

        //UpperLeft
        corners[0] = tx.position - (tx.right * width);
        corners[0] += tx.up * height;
        corners[0] += tx.forward * distance;

        //UpperRight 
        corners[1] = tx.position + (tx.right * width);
        corners[1] += tx.up * height;
        corners[1] += tx.forward * distance;

        //LowLeft
        corners[2] = tx.position - (tx.right * width);
        corners[2] -= tx.up * height;
        corners[2] += tx.forward * distance;

        //LowerRight
        corners[3] = tx.position + (tx.right * width);
        corners[3] -= tx.up * height;
        corners[3] += tx.forward * distance;


        for (int i = 0; i < 4; i++)
        {
           // corners[i] -= tx.position;
            corners[i] = transform.InverseTransformPoint(corners[i]);
        }

       
        return corners;
    }



    public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
    {
        Vector3 point = Quaternion.AngleAxis(angle, axis) * (position - center);
        Vector3 resultVec3 = center + point;
        return resultVec3;
    }

    /// <summary>
    /// xxx
    /// </summary>
    void FanAllPointContentToPoint()
    {
        //ABCD = adc + abc
        //ADC
        TriangleNum[0] = (int)VerName.A;
        TriangleNum[1] = (int)VerName.D;
        TriangleNum[2] = (int)VerName.C;
        //abc
        TriangleNum[3] = (int)VerName.C;
        TriangleNum[4] = (int)VerName.B;
        TriangleNum[5] = (int)VerName.A;


        //ADEH = ade + ahe
        //ade
        TriangleNum[6] = (int)VerName.E;
        TriangleNum[7] = (int)VerName.D;
        TriangleNum[8] = (int)VerName.A;
        //ahe
        TriangleNum[9] = (int)VerName.A;
        TriangleNum[10] = (int)VerName.H;
        TriangleNum[11] = (int)VerName.E;


        //ABGH = abg + ahg
        //abg
        TriangleNum[12] = (int)VerName.A;
        TriangleNum[13] = (int)VerName.B;
        TriangleNum[14] = (int)VerName.G;
        //ahg
        TriangleNum[15] = (int)VerName.G;
        TriangleNum[16] = (int)VerName.H;
        TriangleNum[17] = (int)VerName.A;


        //bcfg = gbc + gfc
        //gbc
        TriangleNum[18] = (int)VerName.G;
        TriangleNum[19] = (int)VerName.B;
        TriangleNum[20] = (int)VerName.C;
        //gfc
        TriangleNum[21] = (int)VerName.C;
        TriangleNum[22] = (int)VerName.F;
        TriangleNum[23] = (int)VerName.G;

        //cdef = fcd + fed
        //fcd
        TriangleNum[24] = (int)VerName.F;
        TriangleNum[25] = (int)VerName.C;
        TriangleNum[26] = (int)VerName.D;
        //fed
        TriangleNum[27] = (int)VerName.D;
        TriangleNum[28] = (int)VerName.E;
        TriangleNum[29] = (int)VerName.F;

        //GHEF = ghe + gfe
        //ghe
        TriangleNum[30] = (int)VerName.E;
        TriangleNum[31] = (int)VerName.H;
        TriangleNum[32] = (int)VerName.G;
        //gfe
        TriangleNum[33] = (int)VerName.G;
        TriangleNum[34] = (int)VerName.F;
        TriangleNum[35] = (int)VerName.E;




    }

}
