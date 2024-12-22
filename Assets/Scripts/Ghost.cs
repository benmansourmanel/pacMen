using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    private Rigidbody rb;
    private Vector3 currentDirection, previousPosition;
    //private int angle = 180;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDirection = Vector3.back;
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        //movement
        if (transform.position != previousPosition)
        {
            previousPosition = transform.position;
        }
        else
        {
            currentDirection = GetNewRandomDirection();
        }
        rb.velocity = currentDirection.normalized * moveSpeed;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Coin") || collision.gameObject.CompareTag("PowerPellet"))
    //    {
    //        Physics.IgnoreCollision(rb.GetComponent<Collider>(), collision.collider);
    //    }
    //    if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ghost"))
    //    {
    //        currentDirection = GetNewRandomDirection();
    //    }
    //}

    private Vector3 GetNewRandomDirection()
    {
        int randomDirection = UnityEngine.Random.Range(0, 4);

        switch (randomDirection)
        {
            case 0:
            return Vector3.left;
            case 1:
            return Vector3.right;
            case 2:
            return Vector3.forward;
            case 3:
            return Vector3.back;
            default:
            return Vector3.back;
        }
    }
}






