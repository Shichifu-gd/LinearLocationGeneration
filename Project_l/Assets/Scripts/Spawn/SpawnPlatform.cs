using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    private ListPlatforms listPlatforms;

    [SerializeField] private GameObject PlatformUR;
    [SerializeField] private GameObject PlatformUL;

    private Vector2 SpawnDirections;

    private string SideSpawn;

    private int CountPlatform;

    private bool Expectation;

    private void Awake()
    {
        listPlatforms = GetComponent<ListPlatforms>();
    }

    private void FixedUpdate()
    {
        if (Expectation == true)
        {
            CountPlatform = listPlatforms.CountPlatform();
            listPlatforms.ClearVoidList();
            if (CountPlatform < 45)
            {
                Expectation = false;
                Spawn();
            }
        }
    }

    /* Until the number of platforms reaches the limit, platforms will continue to appear.
     * if the number of platforms reaches the limit, then the revival point goes 
     * into a waiting state until space is available. Then she goes into a state of work. */
    public void LaunchSpawn(Vector2 positionSpawn, string side)
    {
        SideSpawn = side;
        CountPlatform = listPlatforms.CountPlatform();
        SpawnDirections = positionSpawn;
        if (CountPlatform < 20) Spawn();
        else Expectation = true;
    }

    private void Spawn()
    {
        if (SideSpawn == "UR") Instantiate(PlatformUR, SpawnDirections, Quaternion.identity);
        if (SideSpawn == "UL") Instantiate(PlatformUL, SpawnDirections, Quaternion.identity);
    }
}