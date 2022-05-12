using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;
    private int[] Seed;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        RandomizePositions();
        Construir();
    }

    void RandomizePositions() {
        Seed = new int[25];
        for (int n = 0; n < 25; n++) {
            Seed[n] = Random.Range(0,10);
        }
    }

    void ConstruirSeed(int pos,int seed) {
            float x, y1, y2, z1, z2, z3;
            x = 9.5f + 4.5f*pos;
            y1 = 7f;
            y2 = 9f;
            z1 = 0f;
            z2 = -2f;
            z3 = -4f;
            if ((seed == 1) ||(seed == 2)||(seed == 6)||(seed == 7)||(seed == 8)) {
                Instantiate(Obstacle, transform.position + new Vector3(x,y1,z1), Quaternion.identity, transform);
            }
            if ((seed == 1)||(seed == 3)||(seed == 6)||(seed == 7)||(seed == 8)) {
                Instantiate(Obstacle, transform.position + new Vector3(x,y1,z3), Quaternion.identity, transform);
            }
            if ((seed == 2) ||(seed == 6)){
                Instantiate(Obstacle, transform.position + new Vector3(x,y2,z1), Quaternion.identity, transform);
            }
            if ((seed == 3) ||(seed == 7)){
                Instantiate(Obstacle, transform.position + new Vector3(x,y2,z3), Quaternion.identity, transform);
            }
            if ((seed == 4)||(seed == 5)) {
                Instantiate(Obstacle, transform.position + new Vector3(x,y1,z2), Quaternion.identity, transform);
            }
            if ((seed == 5)||(seed == 8)) {
                Instantiate(Obstacle, transform.position + new Vector3(x,y2,z2), Quaternion.identity, transform);
            }
        }

    void Construir()
    {
        int vers;
        foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

        RandomizePositions();
        for (int i = 0; i < 25; i++)
            {
                ConstruirSeed(i,Seed[i]);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
