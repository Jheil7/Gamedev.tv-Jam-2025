using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrol : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed= 1.0f;
    [SerializeField] float travelDistance;
    Vector3 startPos;
    bool isReturning;
    Vector3 currentScale;
    // Start is called before the first frame update
    void Start()
    {
        isReturning=false;
        myRigidBody=GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(7,7);
        startPos=transform.position;
    }

    void OnDrawGizmos()
    {
        Vector3 direction = transform.right*Mathf.Sign(transform.localScale.x);
        Vector3 endPoint = transform.position + direction * travelDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, endPoint);
    }

    void FixedUpdate()
    {
        myRigidBody.linearVelocity=new Vector2 (Mathf.Sign(transform.localScale.x)*moveSpeed, 0.0f);
        CheckDistance();
    }

    void FlipEnemyFacing(){
        currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }

    void CheckDistance(){
        if(Vector3.Distance(startPos,transform.position)>=travelDistance&&!isReturning){
            isReturning=true;
            FlipEnemyFacing();
        }
        else if(Vector3.Distance(startPos,transform.position)<=1&&isReturning){
            isReturning=false;
            FlipEnemyFacing();
        }
    }


}
