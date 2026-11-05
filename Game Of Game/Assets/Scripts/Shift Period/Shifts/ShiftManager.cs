using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
  public List<Shift> ShiftList;
  public TimerManager timerManager;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    CreateShiftList();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void CreateShiftList()
  {
    for(int i = 0; i < timerManager.GetTotalTime(); i++)
    {
      print("creating");
      Shift newShift = CreateShift();
      ShiftList.Append(newShift);
    }
    print($"{ShiftList[10]}");
  }

  private Shift CreateShift()
  {

    Shift shift = new Shift(timerManager.IsOpen() ? Shift.Status.Open : Shift.Status.Closed, timerManager.GetCurrentDayTime(), new List<Worker>());
    return shift;
  }
}
