using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private ListPlatforms listPlatforms;

    [SerializeField] private GameObject ColliederUR;
    [SerializeField] private GameObject ColliederUL;

    private float TimeStartFall;
    private float Position;

    private bool SwitchFall;

    private void Awake()
    {
        listPlatforms = GameObject.FindGameObjectWithTag("SpawnPlatform").GetComponent<ListPlatforms>();
    }

    private void Start()
    {
        listPlatforms.AddInList(gameObject);
        Position = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (SwitchFall == true)
        {
            TimeStartFall += Time.deltaTime * 6f;
            if (TimeStartFall > 5 && TimeStartFall < 14)
            {
                Position -= Time.deltaTime * 6f;
                transform.position = new Vector2(transform.position.x, Position);
            }
            if (TimeStartFall > 15) Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) SwitchFall = true;
    }

    public void RemoveExcessCollider(string side)
    {
        if (side == "UR" && ColliederUR) Destroy(ColliederUR);
        if (side == "UL" && ColliederUL) Destroy(ColliederUL);
    }
}