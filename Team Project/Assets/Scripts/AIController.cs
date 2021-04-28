using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIController : MonoBehaviour
{
    public Transform target;

    public float speed = 5;
    public float nextWaypointDistance = 3f;
    // Start is called before the first frame update

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb2d;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb2d.AddForce(force);
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 2);

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
