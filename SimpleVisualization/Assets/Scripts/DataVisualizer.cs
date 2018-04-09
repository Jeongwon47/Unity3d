using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataVisualizer : MonoBehaviour {
    public Material PointMaterial;
    public Gradient Colors;
    public GameObject Earth;
    public GameObject PointPrefab;
    public float ValueScaleMultiplier = 1;
    
    public void CreateMeshes(PopulationData[] populations)
    {

        GameObject p = Instantiate<GameObject>(PointPrefab);
        Vector3[] verts = p.GetComponent<MeshFilter>().mesh.vertices;
        int[] indices = p.GetComponent<MeshFilter>().mesh.triangles;

        List<Vector3> meshVertices = new List<Vector3>(65000);
        List<int> meshIndices = new List<int>(117000);
        List<Color> meshColors = new List<Color>(65000);


        for (int i = 0; i < populations.Length; i++) {

            float lat = populations[i].lat;
            float lng = populations[i].lng;
            float value = populations[i].pop / 10000000;

            AppendPointVertices(p, verts, indices, lng, lat, value, meshVertices, meshIndices, meshColors);
            if (meshVertices.Count + verts.Length > 65000)
            {
                CreateObject(meshVertices, meshIndices, meshColors);
                meshVertices.Clear();
                meshIndices.Clear();
                meshColors.Clear();
            }
         }   

        Destroy(p);
    }
    private void AppendPointVertices(
        GameObject p, 
        Vector3[] verts, 
        int[] indices, 
        float lng,
        float lat,
        float value, 
        List<Vector3> meshVertices,
        List<int> meshIndices,
        List<Color> meshColors)
    {
        Color valueColor = Colors.Evaluate(value * ValueScaleMultiplier);
        Vector3 pos;
        pos.x = 0.5f * Mathf.Cos((lng) * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad);
        pos.y = 0.5f * Mathf.Sin(lat * Mathf.Deg2Rad);
        pos.z = 0.5f * Mathf.Sin((lng) * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad);
            
            p.transform.parent = Earth.transform;
        p.transform.position = pos;
        p.transform.localScale = new Vector3(1, 1, Mathf.Max(0.001f, value * ValueScaleMultiplier));
        p.transform.LookAt(pos * 2);

        int prevVertCount = meshVertices.Count;

        for (int k = 0; k < verts.Length; k++)
        {
            meshVertices.Add(p.transform.TransformPoint(verts[k]));
            meshColors.Add(valueColor);
        }
        for (int k = 0; k < indices.Length; k++)
        {
            meshIndices.Add(prevVertCount + indices[k]);
        }
    }
    private void CreateObject(List<Vector3> meshertices, List<int> meshindecies, List<Color> meshColors)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = meshertices.ToArray();
        mesh.triangles = meshindecies.ToArray();
        mesh.colors = meshColors.ToArray();
        GameObject obj = new GameObject();
        obj.transform.parent = Earth.transform;
        obj.AddComponent<MeshFilter>().mesh = mesh;
        obj.AddComponent<MeshRenderer>().material = PointMaterial;
    }
}