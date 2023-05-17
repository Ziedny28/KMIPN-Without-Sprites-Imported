using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseNoRot : MonoBehaviour
{
    public GameObject player;
    public float speed=4f;
    public float distanceBetween=6f;

    public float distance;
    private SpriteRenderer sprite;

    public Animator anim;

    public enum movementState
    {
        idle,
        move,
        attack,
        death
    }

    private movementState state;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //check if we need to flip sprite/not
        if (player.transform.position.x < transform.position.x && distance < distanceBetween)
        {
            sprite.flipX = true;
            
            state = movementState.move;
        }
        else
        {
            sprite.flipX = false;
            state = movementState.idle;
        }

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        anim.SetInteger("state", (int)state);
        
    }
}
