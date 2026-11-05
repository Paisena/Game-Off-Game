using UnityEngine;
using System;
using System.Collections;

// TODO: convert the time value to the regular 24 hours time period
public class TimerManager : MonoBehaviour
{

  public static event Action OnDayOver;
  public static event Action OnWeekOver;
  // Event periods events
  [Header("Event Period Variables")]
  [SerializeField] private int workOverChance = 6; // range of chance
  [SerializeField] private int workSoonChance = 6;
  [SerializeField] private int middleWorkChance = 10;
  public enum EventTimes
  {
    WorkOver,
    WorkSoon,
    WorkStart,
    MiddleWork
  }
  public static event Action OnWorkOver;
  public static event Action OnWorkSoon;
  public static event Action OnWorkStart;
  public static event Action OnMiddleWork;
  public static event Action OnOpenHour;
  public static event Action OnClosedHour;

  // Time variables
  [Header("Time Variables")]
  [SerializeField] private bool timerRunning = false;
  [SerializeField] private float currentTotalTime = 168;
  [SerializeField] private float currentDayTime = 0;
  [SerializeField] private float timeModifier = 1; // the amount to change time by
  [SerializeField] private float timeUnitLength = 20; // how many seconds is one hour
  [SerializeField] private float totalTime = 168; // total hours in a 7 day week
  [SerializeField] private float dayTimePeriod; // how long is one day
  [SerializeField] private float workStartTime = 9; // when work starts
  [SerializeField] private float workEndTime = 22; // when work ends
  private (float startingTime, float endingTime) workPeriod;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    SetDayTimePeriod();
    workPeriod = SetWorkPeriod();
    StartTimer();
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void StartTimer()
  {
    timerRunning = true;
    StartCoroutine(RunTimer());
  }
  private void StopTimer()
  {
    timerRunning = false;
  }

  IEnumerator RunTimer()
  {
    while (timerRunning)
    {
      currentTotalTime -= timeModifier;
      currentDayTime += timeModifier;

      EventOpenOrClosed();
      EventTimeCheck();

      if (currentDayTime >= dayTimePeriod)
      {
        NextDay();
      }

      if (currentTotalTime <= 0)
      {
        WeekOver();
      }
      yield return new WaitForSeconds(timeUnitLength);
    }
  }

  private (float, float) SetWorkPeriod()
  {
    float startingTime = workStartTime / 24 * dayTimePeriod;
    float endingTime = workEndTime / 24 * dayTimePeriod;
    return(startingTime, endingTime);
  }

  private void SetDayTimePeriod()
  {
    dayTimePeriod = totalTime / 7 - timeModifier; // the - timeModifer is a quick fix for the start function, fix later
  }

  private EventTimes? EventTimeCheck()
  {
    // roll chance for event work over
    if (currentDayTime >= workPeriod.endingTime)
    {
      int roll = UnityEngine.Random.Range(1, workOverChance + 1);
      if (roll == workOverChance)
      {
        //print("work over event");
        OnWorkOver?.Invoke();
        return EventTimes.WorkOver;
      }
      else
      {
        //print($"work over failed: {roll}");
      }
    }

    // roll chance for event before work start
    if (currentDayTime <= workPeriod.startingTime - timeModifier)
    {
      int roll = UnityEngine.Random.Range(1, workSoonChance + 1);
      if (roll == workSoonChance)
      {
        //print("work soon event");
        OnWorkSoon?.Invoke();
        return EventTimes.WorkSoon;
      }
      else
      {
        //print($"work soon failed: {roll}");
      }
    }

    // roll chance for event middle work
    if (currentDayTime > workPeriod.startingTime && currentDayTime < workPeriod.endingTime)
    {
      int roll = UnityEngine.Random.Range(1, middleWorkChance + 1);
      if (roll == middleWorkChance)
      {
        //print("middle work event");
        OnMiddleWork?.Invoke();
        return EventTimes.MiddleWork;
      }
      else
      {
        //print($"middle day roll failed: {roll}");
      }
    }
    return null;
  }

  private void EventOpenOrClosed()
  {
    if (IsOpen())
    {
      OnOpenHour?.Invoke();
    }
    else
    {
      OnClosedHour?.Invoke();
    }
  }

  private void NextDay()
  {
    // invokes day over
    OnDayOver?.Invoke();

    currentDayTime = 0;
  }

  private void WeekOver()
  {
    OnWeekOver?.Invoke();
  }

  public float GetTotalTime()
  {
    return totalTime;
  }

  public float GetCurrentDayTime()
  {
    return currentDayTime;
  }

  public bool IsOpen()
  {
    if (currentDayTime >= workStartTime && currentDayTime <= workEndTime)
    {
      return true;
    }
    return false;
  }

}
