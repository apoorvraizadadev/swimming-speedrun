using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Vector2> waypoints = new List<Vector2>();
    public int currentTarget = 1;
    public int previousTarget;
    public float time;
    public float speed;
    public bool rotate = false;
    public float rotateSpeed;
    public bool bob;
    public float bobSpeed;
    public float bobAmplitude;
    public bool useRandomTime = true;

    public Vector2 start;

    float addition;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        if (previousTarget == 0)
        {
            previousTarget = waypoints.Count - 1;
        }
        if (useRandomTime)
        {
            time = Random.Range(0f, 1f);
        }
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 1f) * 360);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += speed * Time.deltaTime;

        if (time > 1)
        {
            time = 0;
            transform.position = waypoints[currentTarget] + start;
            if (bob)
            {
                transform.position += Mathf.Sin(Time.time * bobSpeed) * bobAmplitude * Vector3.up;
            }
            previousTarget = currentTarget;
            currentTarget += 1;
            if (currentTarget > waypoints.Count - 1)
            {
                currentTarget = 0;
            }

            rotateSpeed *= -1;
        }

        else
        {
            transform.position = Vector2.Lerp(waypoints[previousTarget] + start, waypoints[currentTarget] + start, time);
            if (rotate)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotateSpeed);

            }

            if (bob)
            {
                transform.position += Mathf.Sin(Time.time * bobSpeed) * bobAmplitude * Vector3.up;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (var waypoint in waypoints)
        {
            Gizmos.DrawWireSphere(waypoint + (Vector2)transform.position, 1f);
        }
    }
}
