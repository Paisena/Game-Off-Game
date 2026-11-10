using TMPro;
using UnityEngine;

public class ShiftUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI HourTxt;
  [SerializeField] private TextMeshProUGUI StatusTxt;
  [SerializeField] private Shift shift;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

    UpdateUI();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void UpdateUI()
  {
    HourTxt.text = shift.Time.ToString();
    StatusTxt.text = shift.ShiftStatus.ToString();
  }

  public void SetShift(Shift newShift)
  {
    shift = newShift;
    UpdateUI();
  }
}
