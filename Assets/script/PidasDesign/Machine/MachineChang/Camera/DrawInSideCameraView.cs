using UnityEngine;
using System.Collections;

public class DrawInSideCameraView : MonoBehaviour {

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

    public GameObject MyOutSideViewObj;
    TestDrawCam tdc;

    [Tooltip("材质球")]
    public Material CamMeta;


    Camera MyCam;


    Mesh CamMesh;
    Vector3[] Vertices;
    Vector2[] UVs;
    int[] TriangleNum;

    // Use this for initialization
    void Start () {
        tdc = MyOutSideViewObj.GetComponent<TestDrawCam>();
        MyCam = MyOutSideViewObj.GetComponent<Camera>();

        Vertices = new Vector3[8]; //8
        TriangleNum = new int[6 * 2 * 3];
        UVs = new Vector2[8];

        InitMyDrawField();
      //  gameObject.SetActive(false);
    }


    public void InitMyDrawField()
    {
        if (CamMesh == null)
        {
            //然后初始化各个点的位置
            UpdateGetCamTwoPlaneClicp();

            //初始化Mesh组件
            InitMyMesh();
        }
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



    // Update is called once per frame
    void Update()
    {

        //xx设置相机的各种参数
        UpdateSetCamClipPlane();

        //获取相机的近远面的所有点
        UpdateGetCamTwoPlaneClicp();
        //  AllPointContentToPoint();



        //动态修改Mesh的属性
        UpdateSetCamMesh();
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
        CamMesh.RecalculateBounds();
        CamMesh.RecalculateNormals();
    }

    //设置相机的两个面的距离
    void UpdateSetCamClipPlane()
    {
        MyCam.fieldOfView = tdc.FieldofView;
        MyCam.nearClipPlane = tdc.NearPlane;
        MyCam.farClipPlane = tdc.FarPlane;
    }

    /// <summary>
    /// 获取相机的两个面的所有点
    /// </summary>
    void UpdateGetCamTwoPlaneClicp()
    {

        Vector3[] NearPoints = GetCorners(MyCam.nearClipPlane);
        Vertices[(int)VerName.A] = NearPoints[0];
        Vertices[(int)VerName.B] = NearPoints[1];
        Vertices[(int)VerName.D] = NearPoints[2];
        Vertices[(int)VerName.C] = NearPoints[3];



        //hgfe
        Vector3[] FarPoints = GetCorners(MyCam.farClipPlane);
        Vertices[(int)VerName.H] = FarPoints[0];
        Vertices[(int)VerName.G] = FarPoints[1];
        Vertices[(int)VerName.E] = FarPoints[2];
        Vertices[(int)VerName.F] = FarPoints[3];

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

    /// <summary>
    /// 将所有三角形的点赋值  
    /// </summary>
    void AllPointContentToPoint()
    {

        //ABCD = cba + cad
        //cba
        TriangleNum[0] = (int)VerName.C;
        TriangleNum[1] = (int)VerName.B;
        TriangleNum[2] = (int)VerName.A;
        //cad
        TriangleNum[3] = (int)VerName.C;
        TriangleNum[4] = (int)VerName.A;
        TriangleNum[5] = (int)VerName.D;



        //CDEF = cef + cde
        //cef
        TriangleNum[6] = (int)VerName.C;
        TriangleNum[7] = (int)VerName.E;
        TriangleNum[8] = (int)VerName.F;
        //cde
        TriangleNum[9] = (int)VerName.C;
        TriangleNum[10] = (int)VerName.D;
        TriangleNum[11] = (int)VerName.E;


        //ABGH = bgh + bha
        //bgh
        TriangleNum[12] = (int)VerName.B;
        TriangleNum[13] = (int)VerName.G;
        TriangleNum[14] = (int)VerName.H;
        //bha
        TriangleNum[15] = (int)VerName.B;
        TriangleNum[16] = (int)VerName.H;
        TriangleNum[17] = (int)VerName.A;


        //bcfg = cgf + cbg
        //cgf
        TriangleNum[18] = (int)VerName.C;
        TriangleNum[19] = (int)VerName.F;
        TriangleNum[20] = (int)VerName.G;
        //cbg
        TriangleNum[21] = (int)VerName.C;
        TriangleNum[22] = (int)VerName.G;
        TriangleNum[23] = (int)VerName.B;

        //ADEH 
        //ADE
        TriangleNum[24] = (int)VerName.A;
        TriangleNum[25] = (int)VerName.H;
        TriangleNum[26] = (int)VerName.E;
        //AEH
        TriangleNum[27] = (int)VerName.A;
        TriangleNum[28] = (int)VerName.E;
        TriangleNum[29] = (int)VerName.D;

        //GHEF = fhg + feh
        //fhg
        TriangleNum[30] = (int)VerName.G;
        TriangleNum[31] = (int)VerName.F;
        TriangleNum[32] = (int)VerName.E;
        //feh
        TriangleNum[33] = (int)VerName.G;
        TriangleNum[34] = (int)VerName.E;
        TriangleNum[35] = (int)VerName.H;

    }


    Vector3[] GetCorners(float distance)
    {
        Vector3[] corners = new Vector3[4];

        Transform tx = transform;
        float halfFOV = (MyCam.fieldOfView * 0.5f) * Mathf.Deg2Rad;
        float aspect = MyCam.aspect;

        float height = distance * Mathf.Tan(halfFOV);
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
            //corners[i] -= tx.position;
            corners[i] = transform.InverseTransformPoint(corners[i]);
        }

        return corners;
    }



}
