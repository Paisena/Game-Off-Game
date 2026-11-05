using UnityEngine;

public class WorkerUtility : MonoBehaviour
{
  public static GameObject CreateWorker(string name, Worker.Quality quality, Worker.Mood workerMood, Worker.Personality personality, float affinity, int cookingSkill, int cleaningSkill, int CSSKill)
  {
    GameObject WorkerGo = new GameObject();
    Worker worker = WorkerGo.AddComponent<Worker>();
    worker.initialize(name, quality, workerMood, personality, affinity, cookingSkill, cleaningSkill, CSSKill);

    return WorkerGo;
  }

  // public static Worker CreateRandomCompletelyWorker()
  // {
  //   // completely random worker, mainly for testing
  // }

  public static GameObject CreateRandomWorker()
  {
    print("Adding worker");
    // roll for quality of worker
    // NOTE: will have to make weighted later
    Worker.Quality quality = (Worker.Quality)Random.Range(0,4);
    // randomly choose which skill to be stronger
    Worker.Skills whichSkill = (Worker.Skills)Random.Range(0,3);

    // generate skill values
    int strongSkillVal = Random.Range((int)quality+3, (int)quality+4);
    int skillVal1 = Random.Range((int)quality, (int)quality+2);
    int SkillVal2 = Random.Range((int)quality, (int)quality+2);

    // generate mood
    Worker.Mood mood = (Worker.Mood)Random.Range(0, System.Enum.GetNames(typeof(Worker.Mood)).Length);
    // generate affinity
    float affinity = Random.Range(0, 101);
    // generate personality
    Worker.Personality personality = (Worker.Personality)Random.Range(0, System.Enum.GetNames(typeof(Worker.Personality)).Length);
    // generate name
    string name = "BOb";
    GameObject WorkerGo = new GameObject();
    Worker worker = WorkerGo.AddComponent<Worker>();
    if(whichSkill == Worker.Skills.Cooking)
    {
       worker.initialize(name, quality, mood, personality, affinity, strongSkillVal, skillVal1, SkillVal2);
    }
    else if (whichSkill == Worker.Skills.Cleaning)
    {
      worker.initialize(name, quality, mood, personality, affinity, skillVal1, strongSkillVal, SkillVal2);
    }
    else
    {
      worker.initialize(name, quality, mood, personality, affinity, skillVal1, SkillVal2, strongSkillVal);
    }
    return WorkerGo;

  }

  public static GameObject CreateRandomWorker(Worker.Skills mainSkill)
  {
    // creates worker with a focus on one skill
    // roll for quality of worker
    // NOTE: will have to make weighted later
    Worker.Quality quality = (Worker.Quality)Random.Range(0,4);

    // generate skill values
    int strongSkillVal = Random.Range((int)quality+2, (int)quality+4);
    int skillVal1 = Random.Range((int)quality, (int)quality+2);
    int SkillVal2 = Random.Range((int)quality, (int)quality+2);

    // generate mood
    Worker.Mood mood = (Worker.Mood)Random.Range(0, System.Enum.GetNames(typeof(Worker.Mood)).Length);
    // generate affinity
    float affinity = Random.Range(0, 101);
    // generate personality
    Worker.Personality personality = (Worker.Personality)Random.Range(0, System.Enum.GetNames(typeof(Worker.Personality)).Length);
    // generate name
    string name = "BOb";
    GameObject WorkerGo = new GameObject();
    Worker worker = WorkerGo.AddComponent<Worker>();
    if(mainSkill == Worker.Skills.Cooking)
    {
       worker.initialize(name, quality, mood, personality, affinity, strongSkillVal, skillVal1, SkillVal2);
    }
    else if (mainSkill == Worker.Skills.Cleaning)
    {
      worker.initialize(name, quality, mood, personality, affinity, skillVal1, strongSkillVal, SkillVal2);
    }
    else
    {
      worker.initialize(name, quality, mood, personality, affinity, skillVal1, SkillVal2, strongSkillVal);
    }
    return WorkerGo;
  }
  #region ModifyWorker Overloads
  public static Worker ModifyWorker(Worker worker, string name)
  {
    worker.Name = name;
    return worker;
  }

  public static Worker ModifyWorker(Worker worker, Worker.Mood mood)
  {
    worker.WorkerMood = mood;
    return worker;
  }

  public static Worker ModifyWorker(Worker worker, Worker.Personality personality)
  {
    worker.WorkerPersonality = personality;
    return worker;
  }

  public static Worker ModifyWorker(Worker worker, float affinity)
  {
    worker.PlayerAffinity = affinity;
    return worker;
  }

  public static Worker ModifyWorker(Worker worker, int skillValue, Worker.Skills skill)
  {
    if (skill == Worker.Skills.Cooking)
    {
      worker.CookingSkill = skillValue;
    }
    else if (skill == Worker.Skills.Cleaning)
    {
      worker.CleaningSkill = skillValue;
    }
    else
    {
      worker.CustomerServiceSkill = skillValue;
    }
    return worker;
  }
  #endregion


}
