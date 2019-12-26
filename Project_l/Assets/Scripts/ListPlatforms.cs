using System.Collections.Generic;
using UnityEngine;

public class ListPlatforms : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Platforms;

    public void AddInList(GameObject platform)
    {
        Platforms.Add(platform);
    }

    public void ClearVoidList()
    {
        Platforms.RemoveAll(x => x == null);
    }

    public int CountPlatform()
    {
        int count = Platforms.Count;
        return count;
    }
}