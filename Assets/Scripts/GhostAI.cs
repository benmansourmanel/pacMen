using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    [SerializeField] Transform pacman;
    public NavMeshAgent ghost;
    private Rigidbody rb;

    void Start()
    {
        ghost = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if (pacman != null)
            ghost.destination = pacman.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cherry") || collision.gameObject.CompareTag("Coin") || collision.gameObject.CompareTag("PowerPellet"))
        {
            Physics.IgnoreCollision(rb.GetComponent<Collider>(), collision.collider);
        }
    }
}