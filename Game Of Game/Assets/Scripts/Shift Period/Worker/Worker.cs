using System.Threading;
using UnityEngine;

[System.Serializable]
public class Worker : MonoBehaviour
{

  private void OnEnable()
  {
    TimerManager.OnOpenHour += PeriodUpdateOpen;
    TimerManager.OnClosedHour += PeriodUpdateClosed;
  }

  private void OnDisable()
  {
    TimerManager.OnOpenHour -= PeriodUpdateOpen;
    TimerManager.OnClosedHour -= PeriodUpdateClosed;
  }
  public string Name;
  public bool isWorking;
  public enum Quality
  {
    D,
    C,
    B,
    A,
    S
  }
  public Quality WorkerQuality;
  public enum Personality
  {
    Cool,
    HotHeaded,
    Smart,
    Dumb,
    Energetic,
    Lazy
  }
  public Personality WorkerPersonality;
  public enum Mood
  {
    Happy,
    Sad,
    Angry,
  }
  public Mood WorkerMood;

  public float PlayerAffinity; // how much the worker likes or dislikes player
  public enum Skills
  {
    Cooking,
    Cleaning,
    CustomerService
  }
  public int CookingSkill; // all three skills out of ten
  public int CleaningSkill;
  public int CustomerServiceSkill;
  public float EnergyModifier = 0.1f;
  public float Energy;

  public void initialize(string name, Quality quality, Mood workerMood, Personality personality, float affinity, int cookingSkill, int cleaningSkill, int CSSKill)
  {
    Name = name;
    WorkerQuality = quality;
    WorkerMood = workerMood;
    WorkerPersonality = personality;
    PlayerAffinity = affinity;
    CookingSkill = cookingSkill;
    CleaningSkill = cleaningSkill;
    CustomerServiceSkill = CSSKill;
  }

  public void initialize()
  {
    Name = "missingName";
    WorkerMood = Mood.Happy;
    PlayerAffinity = 0;
    CookingSkill = 0;
    CleaningSkill = 0;
    CustomerServiceSkill = 0;
  }

  public void PeriodUpdateOpen()
  {

  }

  public void PeriodUpdateClosed()
  {

  }

}
