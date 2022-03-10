using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DataVisualizer : MonoBehaviour
{
    [SerializeField] int circlePointCount;
    [SerializeField] float sphereRadius;
    [SerializeField] float sphereRadiusIntersection;

    [SerializeField] float speed = 5f;
    const float Tau = 6.28318530718f;
    float targetAngle = 360;
    [SerializeField] float currentAngle = 0;
    [SerializeField] float colorTransparency;
    [SerializeField] TextMeshProUGUI degreeText;
    [SerializeField] TextMeshProUGUI sineCosValueText;

    private void Start()
    {
        Debug.Log(Mathf.Atan2(-0.71f, -0.71f) * Mathf.Rad2Deg);
    }

    private void OnDrawGizmos()
    {
        Vector2 AngToDir(float angleInRadians) {
            return new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        }

        //for (int i = 0; i < circlePointCount; i++)
        //{
        //    //turning 0->8 to 0->1
        //    float turn = i / (float)circlePointCount;
        //    float turnToRad = turn * Tau;

        //    Gizmos.DrawSphere(AngToDir(turnToRad), sphereRadius);
        //}

        Handles.color = new Color(0.650f, 0.733f, 0.905f, 0.7f);
        Handles.DrawWireDisc(Vector2.zero, Vector3.forward, 1f,4f);

        Gizmos.color = Color.white;

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentAngle == 360) currentAngle = 0;

            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, speed * Time.deltaTime);
        }
        degreeText.text = "Degrees:   " + Mathf.RoundToInt(currentAngle).ToString() + "°";

        sineCosValueText.text = ($"sine: {AngToDir(currentAngle * Mathf.Deg2Rad).y:n2} \n cos: {AngToDir(currentAngle * Mathf.Deg2Rad).x:n2}");

        //drawing the hypotenuse : the direction vector
        Handles.color = new Color(1, 1, 1, colorTransparency);
        Handles.DrawLine(transform.position, AngToDir(currentAngle * Mathf.Deg2Rad), 3f);

        //drawing the cosine line
        Handles.color = new Color(1, 0.92f, 0.016f, colorTransparency);
        Handles.DrawLine(transform.position, new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), 0), 3f);

        //drawing the sine line
        Handles.color = new Color(0, 1, 1, colorTransparency);
        Handles.DrawLine(AngToDir(currentAngle * Mathf.Deg2Rad), new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), 0), 3f);

        //drawing spheres at points of intersection
        Gizmos.color = new Color(0.8f, 0.8f, 1, 1f);
        Gizmos.DrawSphere(new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad),0), sphereRadiusIntersection);
        Gizmos.DrawSphere(AngToDir(currentAngle * Mathf.Deg2Rad), sphereRadiusIntersection);

        //drawing the arc angle
        Handles.color = new Color(0.6f, .9f, 1, 0.4f);
        Handles.DrawSolidArc(transform.position, transform.forward, new Vector3(1, 0, 0), currentAngle, 0.3f);
    }
}
