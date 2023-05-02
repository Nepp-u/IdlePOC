using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatAI : MonoBehaviour
{
    enum State
    {
        Roaming
    }

    private State state;
    private CatPathfinding catPathfinding;

    // in which interval should the cat get a new walking direction
    [SerializeField] private float newDirectionInterval = 2f;
    [SerializeField] float intervalRandomness = .5f;

    private void Awake()
    {
        state = State.Roaming;
        catPathfinding = GetComponent<CatPathfinding>();
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // this is not a good way to do it but it will do for now
        // TODO: not do it like this
        if (col.gameObject.tag == "Cat")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // get a new direction when its stuck on wall
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine("RoamingRoutine");
        }
    }

    Vector2 GetRoamingDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    
    IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingDirection();
            catPathfinding.MoveTo(roamPos);

            yield return new WaitForSeconds(newDirectionInterval + Random.Range(-intervalRandomness,intervalRandomness));
        }
    }
    
    
}
