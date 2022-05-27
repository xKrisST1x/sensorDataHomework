using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string filename = "";

    [System.Serializable]
    public class Gyro
    {
        public Vector3 rotationRate;
        public Vector4 attitude;
    }

    [System.Serializable]
    public class GyroList
    {
        public Gyro[] gyro;
    }

    public GyroList myGyroList = new GyroList();

    void Start()
    {
        filename = Application.dataPath + "/test.csv";
    }

    public void WriteCSV()
    {
        if(myGyroList.gyro.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Gyro Rotation Rate, Gyro Attitude");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myGyroList.gyro.Length; i++)
            {
                tw.WriteLine(myGyroList.gyro[i].rotationRate + "," + myGyroList.gyro[i].attitude);
            }
            tw.Close();
        }
    }
}