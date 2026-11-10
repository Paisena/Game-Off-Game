using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
  [SerializeField] List<GameObject> Workers;
  [SerializeField] int HowManyWorkers;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    CreateWorkerList(HowManyWorkers);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void CreateWorkerList(int amount)
  {
    for(int i = 0; i < amount; i++)
    {
      GameObject newWorker = WorkerUtility.CreateRandomWorker();
      newWorker.name = newWorker.GetComponent<Worker>().Name;
      print(newWorker.GetComponent<Worker>().Name);
      newWorker.transform.parent = this.transform;
      Workers.Add(newWorker);
    }
  }

  private void CreateWorkerList()
  {
    for(int i = 0; i < 8; i++)
    {
      GameObject newWorker = WorkerUtility.CreateRandomWorker();
      newWorker.name = newWorker.GetComponent<Worker>().Name;
      print(newWorker.GetComponent<Worker>().Name);
      newWorker.transform.parent = this.transform;
      Workers.Add(newWorker);
    }
  }
}
