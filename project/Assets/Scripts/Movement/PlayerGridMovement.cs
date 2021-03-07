using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{

    [SerializeField]
    float walkSpeed = 2;

    [SerializeField]
    float stepSize = 1;

    [SerializeField]
    bool canMove = true;

    Vector3 direction;
    Vector3 nextPosition;

    public bool IsMoving()
    {
        return !canMove || nextPosition != transform.position;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }


    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving())
        {
            return;
        }

        if (!CheckMovement())
        {
            return;
        }

        nextPosition += stepSize * direction;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, walkSpeed * Time.deltaTime);
    }

    bool CheckMovement()
    {
        Ray2D r = new Ray2D(transform.position, direction);
        RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction, stepSize);
        return !hit.collider || hit.collider.isTrigger; //!(hit.collider && !hit.collider.isTrigger);
    }

}
