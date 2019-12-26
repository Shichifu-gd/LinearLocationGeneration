using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private PlatformController platformController;
    private SpawnPlatform spawnPlatform;

    [SerializeField] private GameObject SpawnPointUR;
    [SerializeField] private GameObject SpawnPointUL;

    public string Option { get; set; } = "Standart";

    private void Awake()
    {
        spawnPlatform = GameObject.FindGameObjectWithTag("SpawnPlatform").GetComponent<SpawnPlatform>();
    }

    private void Start()
    {
        StartCoroutine(Expect());
    }

    public IEnumerator Expect()
    {
        yield return new WaitForSeconds(.001f);
        DirectionSelection();
    }

    private void DirectionSelection()
    {
        if (Option == "Standart")
        {
            int randomSelection = Random.Range(0, 2);
            if (randomSelection == 0 && SpawnPointUR) Broadcast("UR");
            else if (randomSelection == 1 && SpawnPointUL) Broadcast("UL");
            else Broadcast("UR");
        }
        else
        {
            if (Option == "InRestrictedArea R") Broadcast("UL");
            else if (Option == "InRestrictedArea L") Broadcast("UR");
        }
        OnDestroyPoint();
    }

    private void Broadcast(string side)
    {
        if (side == "UR") spawnPlatform.LaunchSpawn(SpawnPointUR.transform.position, side);
        if (side == "UL") spawnPlatform.LaunchSpawn(SpawnPointUL.transform.position, side);
        platformController.RemoveExcessCollider(side);
    }

    private void OnDestroyPoint()
    {
        Destroy(SpawnPointUR);
        Destroy(SpawnPointUL);
        Destroy(gameObject);
    }
}