using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum ZombieState
{
    Idle = 0,
    Run = 1,
    Attack = 2,
    Dead = 3,

}
public class ZombieAI : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    ZombieState zombieState;

    GameObject playerObject;


    PlayerHealth playerHealth;
    ZombieHealt zombieHealt;
    private bool isDead = false;

    public int zombieDamage = 10;

    public new Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        zombieHealt = GetComponent<ZombieHealt>();
        playerObject = GameObject.FindWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zombieHealt.GetHealth() <=0 && !isDead)
        {
            WaveSpawner.EnemiesAlive--;
            SetState(ZombieState.Dead);
        }

        switch (zombieState)
        {
            case ZombieState.Dead:
                KillZombie();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Run:
                SearchForTarget();
                break;
            case ZombieState.Idle:
                SearchForTarget();
                break;


            
        }
    }

    private void Attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped = true;
    }

    void MakeAttack()
    {
        playerHealth.DedectHealth(zombieDamage);
        SearchForTarget();
    }

    private void SearchForTarget()
    {
        if (Vector3.Distance(transform.position, playerObject.transform.position) < 2)
        {
            Attack();
        }
        else if (Vector3.Distance(transform.position, playerObject.transform.position)<10)
        {
            MoveToPlayer();
        }
        else
        {
            SetState(ZombieState.Idle);
            agent.isStopped = true;
        }
    }

    private void SetState(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("State", (int)state);
    }

    private void MoveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        SetState(ZombieState.Run);
    }

    private void KillZombie()
    {
        isDead = true;
        SetState(ZombieState.Dead);
        collider.enabled = false;
        agent.isStopped = true;
        Destroy(gameObject, 5);
    }
}