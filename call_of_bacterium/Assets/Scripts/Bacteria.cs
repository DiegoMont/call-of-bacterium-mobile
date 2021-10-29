using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bacteria : MonoBehaviour
{
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        NavMeshAgent enemy = this.GetComponent<NavMeshAgent>();
        Vector3 playerPosition = new Vector3(9, 4, -43);
        enemy.SetDestination(playerPosition);
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health < 1)
            Destroy(this.gameObject);
    }

}
