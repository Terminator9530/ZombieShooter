using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public Animator animator;
    private bool isAttacking = false;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= 2f)
        {
            if (isWalking)
            {
                animator.SetBool("Walk", false);
                isWalking = false;
            }
            if (!isAttacking)
            {
                StartCoroutine(Attacking());
            }
            return;
        }

        if(distance <= lookRadius)
        {
            animator.SetBool("Walk", true);
            isWalking = true;
            agent.SetDestination(target.position);
        } else
        {
            animator.SetBool("Walk", false);
            isWalking = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator Attacking()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(5f);
        isAttacking = false;
        animator.SetBool("Attack", false);
    }
}
