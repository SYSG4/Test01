using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeHandler : MonoBehaviour
{
    DateTime now;
    string Week;
    [SerializeField] Text DayText,MonthText,WeekText;
    // Start is called before the first frame update
    void Start()
    {
        now = DateTime.Now;
        Week = now.DayOfWeek.ToString();

        switch(Week)
        {
            case "Sunday":
                Week = "日";
                break;
            case "Monday":
                Week = "月";
                break;
            case "Tuesday":
                Week = "火";
                break;
            case "Wednesday":
                Week = "水";
                break;
            case "Thursday":
                Week = "木";
                break;
            case "Friday":
                Week = "金";
                break;
            case "Saturday":
                Week = "土";
                break;
        }
    WeekText.text = Week.ToString();
    MonthText.text = now.Month.ToString();
    DayText.text = now.Day.ToString();
    }

}


