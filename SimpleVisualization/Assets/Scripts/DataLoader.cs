using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {
    public DataVisualizer Visualizer;
	void Start () {
        TextAsset popData = Resources.Load("popdata") as TextAsset;
        string jsonString = popData.ToString();
    
        PopulationData[] populations =  JsonHelper.getJsonArray<PopulationData> (jsonString);
        Visualizer.CreateMeshes(populations);
    }
}
public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
        return wrapper.array;
    }
 
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

[System.Serializable]
public class PopulationData
{
    public string city;
    public string city_ascii;
    public float lat;
    public float lng;
    public float pop;

    public string country;
    public string iso2;
    public string iso3;
    public string province;
}
