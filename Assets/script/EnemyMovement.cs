using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AggroDetection aggroDetection;
    private Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>(); //enemy alt dosyasında kareketerımız oldugu için children kullandık.
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        this.target = target;
        
        
    }
    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position); //karekter navMeshi algilayip bize dogru gelicek.
            float currentSpeed = navMeshAgent.velocity.magnitude; //hızımızı basılı tutmaya göre ayarladık
            animator.SetFloat("Speed", currentSpeed); // düsmana animasyon verdik
        }
        
    }
}
