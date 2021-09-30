using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform Player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag ("Player").transform;

        playerHealth = Player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }
    void Update ()
    {
        //Memindahkan posisi player
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth> 0)
        {
           nav.SetDestination(Player.position);
        }
        else //Hentikan gerakan
        {
            nav.enabled = false;
        }
    }
}
