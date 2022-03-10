using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Radian : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Handles.color = new Color(0.3f, 0.4f, 0.5f, 0.8f);
        Handles.DrawWireDisc(Vector3.zero, Vector3.forward, 1f, 3f);

        Handles.color = new Color(0.2f, 0.6f, 1f, 1);
        Handles.DrawLine(Vector3.zero, Vector3.right, 3f);

        Vector2 point = new Vector2(Mathf.Cos(1), Mathf.Sin(1));
        Handles.DrawLine(Vector3.zero, point, 3f);

        Handles.color = Color.red;
        Handles.DrawWireArc(Vector3.zero, Vector3.forward, Vector3.right, Mathf.Rad2Deg, 1f, 3f);

        Handles.color = new Color(0, 1, 0, 0.2f);
        Handles.DrawSolidArc(Vector3.zero, Vector3.forward, Vector3.right, Mathf.Rad2Deg, 0.2f);
    }
}