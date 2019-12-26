using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public SpawnPoint spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RestrictedArea"))
        {
            int num = gameObject.name.Length - 1;
            spawnPoint.Option = $"InRestrictedArea {gameObject.name.Substring(num)}";
        }
    }
}