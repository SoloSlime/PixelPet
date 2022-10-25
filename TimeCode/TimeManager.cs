using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Slimecode.Time
{
    public class TimeManager : MonoBehaviour
    {
        static public string Date;
        static public string Time;
        static public string Day;
        // Start is called before the first frame update
        void Start()
        {
            print(Date);
            print(Day);
            print(Time);
        }

        private void Awake()
        {
            Date = System.DateTime.UtcNow.ToLocalTime().ToString("dd/MM/yyyyy");
            Time = System.DateTime.UtcNow.ToLocalTime().ToString("mm:HH");
            Day = System.DateTime.UtcNow.ToLocalTime().ToString("dddd");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            Time = System.DateTime.UtcNow.ToLocalTime().ToString("mm:HH");
        }

        static public void CheckDay()
        {
            Day = System.DateTime.UtcNow.ToLocalTime().ToString("dddd");
            Date = System.DateTime.UtcNow.ToLocalTime().ToString("dd/MM/yyyyy");
            return;
        }

    }
}