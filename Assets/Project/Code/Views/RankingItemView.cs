using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingItemView : ViewBase
{
   [SerializeField] private TMP_Text Position;
   [SerializeField] private TMP_Text Username;
   [SerializeField] private TMP_Text Score;
   [SerializeField] private TMP_Text Time;

   public void SetData(RankingData data)
   {
      Position.text = data.Position.ToString();
      Username.text = data.Username;
      Score.text = data.Score.ToString();
      Time.text = data.Time;
   }
}
