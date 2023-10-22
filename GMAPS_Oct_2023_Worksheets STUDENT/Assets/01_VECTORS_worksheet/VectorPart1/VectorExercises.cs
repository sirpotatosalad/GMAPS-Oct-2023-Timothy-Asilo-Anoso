
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for(int i = n; i > 0; i--)
        {
            startPt = new Vector2(Random.Range(-maxX, maxX),Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));



            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);

            Debug.Log(i);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY)),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);

        //code to show sum of a and b
        //HVector2D c = a + b;

        //code to show a - b
        HVector2D c = a - b;


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        
        //getting head of b
        //Vector3 bHead = b.ToUnityVector3();
        //drawing c again from the head of b
        //DebugExtension.DebugArrow(bHead, c.ToUnityVector3(), Color.white, 60f);


        //getting head of a
        Vector3 aHead = a.ToUnityVector3();
        //-b HVector obj
        HVector2D minusB = new HVector2D(-b.x,-b.y);
        DebugExtension.DebugArrow(aHead, minusB.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));

        
        
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a * 2;
        HVector2D c = a / 2;

        //drawing HVector a
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //after poking around Unity's Vector3 documentation, new Vector3(1,0,0) can be written as Vector3.right
        //drawing HVector b
        //DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        //drawing HVector where a/2
        DebugExtension.DebugArrow(Vector3.right, c.ToUnityVector3(), Color.green, 60f);

        // Your code here
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(3, 5);
        //normalized vector of a
        b.Normalize();

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of normalized a = " + b.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;

        HVector2D proj = c.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), v1.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
