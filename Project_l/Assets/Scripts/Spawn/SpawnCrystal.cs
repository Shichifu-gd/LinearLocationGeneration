using UnityEngine;

public class SpawnCrystal : MonoBehaviour
{
    public GameObject Crystal;

    private void Start()
    {
        SelectionCrystal();
    }

    private void SelectionCrystal()
    {
        int random = Random.Range(0, 21);
        if (random == 1 || random == 2) SpawnObjectCrystal();
        Destroy(gameObject);
    }

    private void SpawnObjectCrystal()
    {
        Instantiate(Crystal, gameObject.transform.parent);
    }
}