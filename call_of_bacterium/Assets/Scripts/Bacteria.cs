using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bacteria : MonoBehaviour
{
    private int health;
    public float xpos;
    public float ypos;
    public float zpos;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        NavMeshAgent enemy = this.GetComponent<NavMeshAgent>();
        enemy.SetDestination(new Vector3(xpos, ypos, zpos));
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health < 1)
            Destroy(this.gameObject);
    }

}
