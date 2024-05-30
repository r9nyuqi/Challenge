using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Mesh mesh;
    [SerializeField] private LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;


        

    }

    // Update is called once per frame
    void Update()
    {
        float fov = 70f;
        Vector3 origin = Vector3.zero;
        int raycount = 50;
        float angle = 120f;
        float angleIncrease = fov / raycount;
        float viewDistance = 5f;


        Vector3[] verticies = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];

        int[] triangles = new int[raycount * 3];

        verticies[0] = origin;

        int vertexIndex = 1;

        int triangleIndex = 0;
        for (int i = 0; i < raycount; i++)
        {
            Vector3 vertex;


            RaycastHit2D rayCastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layermask);


            if (rayCastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;


            }
            else
            {
                
                vertex = rayCastHit2D.point;
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
}
