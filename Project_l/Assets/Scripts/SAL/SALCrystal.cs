using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SALCrystal : MonoBehaviour
{
    public static void SaveScoreCrystal(GameScore gameScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/SSC.dat", FileMode.Create);
        DataOpenRoom data = new DataOpenRoom(gameScore);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadScoreCrystal()
    {
        if (File.Exists(Application.dataPath + "/data/SSC.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/SSC.dat", FileMode.Open);
            DataOpenRoom data = bf.Deserialize(stream) as DataOpenRoom;
            stream.Close();
            return data.dataScore;
        }
        else return new int[0];
    }
}

[Serializable]
public class DataOpenRoom
{
    public int[] dataScore;
    public DataOpenRoom(GameScore gameScore)
    {
        dataScore = new int[1];
        dataScore[0] = gameScore.ScoreCrystal;
    }
}