using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    public int BACTERIAS_AT_THE_SAME_TIME;
    public int BACTERIAS_PER_WAVE;
    public GameObject[] BACTERIAS;
    public float X_FROM;
    public float X_TO;
    public float Z_FROM;
    public float Z_TO;

    private GameObject[] bacteriasInScene;

    // Start is called before the first frame update
    void Start()
    {
        bacteriasInScene = new GameObject[BACTERIAS_AT_THE_SAME_TIME];
        for (int i = 0; i < BACTERIAS_AT_THE_SAME_TIME; i++)
            bacteriasInScene[i] = (GameObject) spawnBacteria();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Object spawnBacteria() {
        GameObject bacteriaToSpawn = getRandomBacteria();
        Vector3 position = getRandomPosition();
        Debug.Log(bacteriaToSpawn);
        Object newBacteria = Instantiate(bacteriaToSpawn, position, Quaternion.identity);
        return newBacteria;
    }

    private Vector3 getRandomPosition() {
        float x = Random.Range(X_FROM, X_TO);
        float z = Random.Range(Z_FROM, Z_TO);
        Vector3 position = new Vector3(x, 2, z);
        return position;
    }

    private GameObject getRandomBacteria(){
        int index = Random.Range(0, BACTERIAS.Length);
        return BACTERIAS[index];
    }
}
