using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Mesh mesh;
    [SerializeField] private LayerMask layermask;

    private Vector3 origin;
    private float angle;
    private float fov;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 70f;

        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
       
        int raycount = 50;
        
        float angleIncrease = fov / raycount;
        float viewDistance = 5f;
        origin = Vector3.zero;
        angle = 120f;
        Vector3[] verticies = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];

        int[] triangles = new int[raycount * 3];

        verticies[0] = origin;

        int vertexIndex = 1;

        int triangleIndex = 0;
        for (int i = 0; i < raycount; i++)
        {
            Vector3 vertex;


            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layermask);

            

            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }

            verticies[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;

        }

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    }

    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void setDirection(Vector3 direction)
    {
        this.angle = GetAngleFromVectorFloat(direction) - fov / 2f;
    }

    public void setDirectionFloat(float direction)
    {
        angle = direction;
    }



    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
