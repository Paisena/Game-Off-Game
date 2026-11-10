using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
  public List<Shift> ShiftList;
  public List<GameObject> ShiftUIList;
  public TimerManager timerManager;
  [SerializeField] GameObject ShiftUIPrefab;
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
    for(int i = 1; i < timerManager.GetTotalTime() + 1; i++)
    {
      Shift newShift = CreateShift((float)i);
      ShiftList.Add(newShift);
    }
  }

  private Shift CreateShift()
  {

    Shift shift = new Shift(timerManager.IsOpen() ? Shift.Status.Open : Shift.Status.Closed, timerManager.GetCurrentDayTime(), new List<Worker>());

    GameObject ShiftUI = CreateShiftUI(shift);

    return shift;
  }

  private Shift CreateShift(float time)
  {
    Shift shift = new(timerManager.IsOpen(time) ? Shift.Status.Open : Shift.Status.Closed, time, new List<Worker>());

    GameObject ShiftUI = CreateShiftUI(shift);
    return shift;
  }

  private GameObject CreateShiftUI(Shift shift)
  {
    GameObject ShiftUI = Instantiate(ShiftUIPrefab);
    ShiftUI.GetComponentInChildren<ShiftUI>().SetShift(shift);
    ShiftUIList.Add(ShiftUI);

    ShiftUI.name = $"Hour: {shift.Time}";
    ShiftUI.transform.parent = this.transform;

    return ShiftUI;
  }
}
