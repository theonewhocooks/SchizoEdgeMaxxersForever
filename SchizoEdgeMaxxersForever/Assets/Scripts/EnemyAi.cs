using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public int Damage;
    public int health;

 public Transform player;


 private NavMeshAgent navMeshAgent;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
    }

    public void TakeDamage()
    {
        health -= Damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }


    void Update()
    {

 if (player != null)
        {    
            navMeshAgent.SetDestination(player.position);
        }
    }
}
