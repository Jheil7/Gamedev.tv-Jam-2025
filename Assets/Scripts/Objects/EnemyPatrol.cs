using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed= 1.0f;
    [SerializeField] public Vector3 currentScale;

    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(7,7);
    }

    void FixedUpdate()
    {
        myRigidBody.linearVelocity=new Vector2 (Mathf.Sign(transform.localScale.x)*moveSpeed, 0.0f);
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Ground"){
            FlipEnemyFacing();
        }

        
    }

    void FlipEnemyFacing(){
        currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
