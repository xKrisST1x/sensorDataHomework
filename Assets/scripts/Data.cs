using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Data : MonoBehaviour
{
    string filename = "";
    public bool playing;
    [System.Serializable]

    public class Gyro
    {
        public int attitude;
    }

    [System.Serializable]
    public class GyroList
    {
    public Gyro[] gyro;
    }
    public GyroList myGyroList = new GyroList();
    Gyroscope m_Gyro;
    public class Player
    {
        public float x;

        public float y;

        public float z;

    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    private void Start()
    {
        filename = Application.dataPath + "/test.csv";


        TextWriter tw = new StreamWriter(filename, false);

        tw.WriteLine("Attitude");

        tw.Close();

    }


    private void Update()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        if (playing == true)
        {
            WriteCSV();
        }
    }

    public void StartStop()
    {

        if(playing == true)
        {
            playing = false;
         }

        else if(playing == false)
        {
            playing = true;
        }


    }


    public void WriteCSV()
    {
        
        
            TextWriter tw = new StreamWriter(filename, true);



            tw.Close();

            tw = new StreamWriter(filename,true);

            for(float i = 0; i < myGyroList.gyro.Length; i++)
            {
                //myPlayerList.player[i].x = Input.acceleration.x;
                //myPlayerList.player[i].y = Input.acceleration.y;
                //myPlayerList.player[i].z = Input.acceleration.z;
                tw.WriteLine( m_Gyro.attitude + ",");
            }
            tw.Close();

            Debug.Log("works?");
        

    }


}