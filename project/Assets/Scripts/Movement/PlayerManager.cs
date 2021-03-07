using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private enum Direction
    {
        North,//0
        South,//1
        East,//2
        West//3
    }

    private Vector3[] directionList = new Vector3[]{
        Vector3.up,
        Vector3.down,
        Vector3.right,
        Vector3.left,
    };

    private string[] directionName = new string[]{
        "North",
        "South",
        "East",
        "West"
    };


    private PlayerGridMovement playerGridMovement;
    private PlayerAnimations playerAnimations;

    private Direction direction = Direction.South;
    private Vector2 vector2Direction;
    private Vector2 input;


    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (!playerGridMovement)
        {
            playerGridMovement = GetComponent<PlayerGridMovement>();
        }
        if (!playerAnimations)
        {
            playerAnimations = GetComponent<PlayerAnimations>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (input != Vector2.zero)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                {
                    direction = Direction.East;
                }
                else
                {
                    direction = Direction.West;
                }
            }
            else
            {
                if (input.y > 0)
                {
                    direction = Direction.North;
                }
                else
                {
                    direction = Direction.South;
                }
            }

            vector2Direction = directionList[(int)direction];
        }
        else
        {
            vector2Direction = Vector2.zero;
        }

        playerGridMovement.SetDirection(vector2Direction);
    }

    void LateUpdate()
    {
        playerAnimations.SetPauseAnimation(!playerGridMovement.IsMoving());

        if (!playerGridMovement.IsMoving())
        {
            playerAnimations.SetDirection(directionName[(int)direction]);
        }

    }
}
