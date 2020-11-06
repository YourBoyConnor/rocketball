using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    const int GROUND_INCREMENT = 50;

    GameObject player;
    public GameObject[] grounds;
    GameObject groundPrefab;
    bool newGroundGen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        groundPrefab = (GameObject)Resources.Load("Models/Ground");
    }
    void Update()
    {
        //ground pooling
        if (Mathf.RoundToInt(player.transform.position.x % GROUND_INCREMENT) < 25 && newGroundGen == true)
        {
            GameObject[] newGrounds = new GameObject[2];
            GameObject.Destroy(grounds[0]);
            newGrounds[0] = grounds[1];
            newGrounds[1] = Instantiate(groundPrefab, newGrounds[0].transform.position + new Vector3(GROUND_INCREMENT, 0, 0), Quaternion.identity);
            grounds = newGrounds;
            newGroundGen = false;
        }
        else if (Mathf.RoundToInt(player.transform.position.x % GROUND_INCREMENT) >= 25)
            newGroundGen = true;
    }
}
