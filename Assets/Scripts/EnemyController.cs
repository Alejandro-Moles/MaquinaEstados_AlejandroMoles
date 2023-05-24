using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform ruta;
    int indiceHijos;
    Vector3 destino;
    Animator animator;
    public Transform Player;
    public float distanciaPlayer;
    public Transform PointVision;
    private bool attack;

    public GameObject Attack;

    private void Start()
    {
        Attack.SetActive(false);
        destino = ruta.GetChild(indiceHijos).position;
        animator = GetComponent<Animator>();
        GetComponent<NavMeshAgent>().SetDestination(destino);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, destino) < 2)
        {
            indiceHijos++;
            if (indiceHijos >= ruta.childCount)
            {
                indiceHijos = 0;
            }
        }

        distanciaPlayer = Vector3.Distance(transform.position, Player.position);

        if(distanciaPlayer > 5 )
        {
            destino = ruta.GetChild(indiceHijos).position;
            GetComponent<NavMeshAgent>().SetDestination(destino);
        }

        if(distanciaPlayer <= 5 && distanciaPlayer > 2)
        {
            Debug.Log("Detectado");
            GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        }

        if(distanciaPlayer <= 2)
        {
            attack = true;
            if(attack)
            {
                Attack.SetActive(true);
                attack = false;
                GetComponent<NavMeshAgent>().speed = 0;
                animator.SetTrigger("Attack");
                Invoke("ChangeVelocity", 1f);
            }
            
        }

    }

    private IEnumerator TiempoEspera()
    {
        animator.SetBool("Andar", false);
        yield return new WaitForSeconds(UnityEngine.Random.Range(3,7));

        animator.SetBool("Andar", true);
        destino = ruta.GetChild(indiceHijos).position;
        GetComponent<NavMeshAgent>().SetDestination(destino);

    }

    private void ChangeVelocity()
    {
        Attack.SetActive(false);
        GetComponent<NavMeshAgent>().speed = 2.5f;
    }
}
