using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Sensor : MonoBehaviour
{
    string filename = "";

    [System.Serializable]
    public class Gyro
    {
        public int rotationRate;
        public int attitude;
    }

    [System.Serializable]
    public class GyroList
    {
    public Gyro[] gyro;
    }
    public GyroList myGyroList = new GyroList();
    Gyroscope m_Gyro;
    bool ifButtonPressed = false;
    void Start()
    {
        filename = Application.dataPath + "/test.csv";
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    public void WriteCSV(){
        
         TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Gyro Rotation Rate, Gyro Attitude");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(float i = 0; i < myGyroList.gyro.Length; i++)
            {
                tw.WriteLine(m_Gyro.rotationRate + "," + 
                m_Gyro.attitude + ",");
            }
            tw.Close();
    }
    private void Update() 
    {
        //Checks if the gyroscope is recording data. when button is pressed it is set to true
        if(ifButtonPressed){
        Debug.Log(m_Gyro.attitude);
        WriteCSV();
        }
    }
    public void setButtonPressed(){
        ifButtonPressed = !ifButtonPressed;
    }
void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
    }
}
 