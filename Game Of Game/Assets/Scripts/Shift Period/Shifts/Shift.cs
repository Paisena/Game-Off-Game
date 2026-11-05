using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Shift
{
  public enum Status
  {
    Closed,
    Open
  }
  public Status ShiftStatus;
  public float Time;
  public List<Worker> Workers;

  public Shift(Status status, float time, List<Worker> workers)
  {
    ShiftStatus = status;
    Time = time;
    Workers = workers;
  }

  public Shift(Status status, float time)
  {
    ShiftStatus = status;
    Time = time;
    Workers = new List<Worker>();
  }

  public Shift(float time)
  {
    ShiftStatus = Status.Open;
    Time = time;
    Workers = new List<Worker>();
  }

  public void AddWorker(Worker worker)
  {
    
  }

}
