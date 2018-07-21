using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl : MonoBehaviour {
    public GameObject walker;
    public Vector2 roomSize;
    public Vector2 steps;

    // Use this for initialization
    void Start()
    {
        GameObject map = new GameObject("Map");

        GenerateMap(map);

        StartWalker();
    }

    // 
    void StartWalker()
    {
        GameObject w = Instantiate(walker);
        w.transform.position = new Vector3((int)Random.Range(-roomSize.x/2, roomSize.x / 2),0, (int)Random.Range(-roomSize.y / 2, roomSize.y / 2));

        StartCoroutine(theWalk(w));
    }

    // 
    IEnumerator theWalk(GameObject walk)
    {
        steps.x++;

        bool aX = false, aZ = false;
        float dice = Random.value, dice2 = Random.value;
        int dir = Random.value >= .5f ? 1 : -1;
        
        // 
        if (dice2 < .2f)
        {
            dir = dir * -1;
        }

        // 
        if (dice > .5f)
        {
            // 
            if (walk.transform.position.x != ((roomSize.x / 2) - 3) * dir) //((roomSize.x/2)-1)
            {
                aX = true;
            }
            else
            {
                dir = dir * -1;
            }
        }
        else
        {
            // 
            if (walk.transform.position.z != ((roomSize.x / 2) - 3) * dir) //((roomSize.x/2)-1)
            {
                aZ = true;
            }
            else
            {
                dir = dir * -1;
            }
        }

        // move the walker
        Vector3 plusPos = new Vector3((aX ? 1*dir : 0), 0, (aZ ? 1*dir : 0));
        walk.transform.position += plusPos;

        yield return new WaitForSeconds(.001f);

        // 
        if (steps.x < steps.y)
        {
            StartCoroutine(theWalk(walk));
        }
    }

    // 
    void GenerateMap(GameObject map)
    {
        for (int i = 0; i < roomSize.x; i++)
        {
            for (int j = 0; j < roomSize.y; j++)
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(i - (roomSize.x / 2), 0, j - (roomSize.y / 2));

                obj.transform.SetParent(map.transform);
            }
        }
    }
}
