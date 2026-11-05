using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
    [SerializeField] List<GameObject> Workers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      for(int i = 0; i < 8; i++)
      {
        GameObject newWorker = WorkerUtility.CreateRandomWorker();
        //print(newWorker);
        Workers.Add(newWorker);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
