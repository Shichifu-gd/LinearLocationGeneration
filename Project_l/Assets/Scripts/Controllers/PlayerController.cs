using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameScore gameScore;
    private Rigidbody2D rigidbody;

    private Vector2 CurrentDirection = new Vector2(0, 0);
    private Vector2 DirectionUR = new Vector2(4, 2.5f);
    private Vector2 DirectionUL = new Vector2(-4, 2.5f);

    private string FallSide;

    // QPForSpeed - quantity platform for speed
    private float QPForSpeed = 50;
    private float SpeedMove = 0.07f;

    private bool DSwitch;
    private bool SwitchFR;
    private bool SwitchSpeedIncrease = true;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) DirectionSwitch();
    }

    private void FixedUpdate()
    {
        if (SwitchFR == false) transform.Translate(CurrentDirection.normalized * SpeedMove);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform")) InteractionWithPlatform();
        if (other.CompareTag("Respawn") && SwitchFR == false)
        {
            FallSide = other.gameObject.name;
            StartDefeatScenario();
        }
        if (other.CompareTag("Crystal"))
        {
            InteractionWithCrystal();
            Destroy(other.gameObject);
        }
    }

    private void DirectionSwitch()
    {
        DSwitch = !DSwitch;
        if (DSwitch == false) CurrentDirection = DirectionUR;
        if (DSwitch == true) CurrentDirection = DirectionUL;
    }

    private void InteractionWithCrystal()
    {
        gameScore.ChangeScoreCrystal("addition");
    }

    private void InteractionWithPlatform()
    {
        gameScore.ChangeScorePlatform("addition");
        SpeedIncrease();
    }

    // If enough platforms are passed then the speed of the ball will increase:
    // While SwitchSpeedIncrease should be able to true .
    private void SpeedIncrease()
    {
        if (gameScore.ScorePlatform == QPForSpeed && SwitchSpeedIncrease == true)
        {
            SpeedMove += 0.01f;
            QPForSpeed += QPForSpeed / 3;
        }
    }

    #region if a player loses

    private void StartDefeatScenario()
    {
        SwitchFR = true;
        Fall();
        gameScore.SaveScore();
        StartCoroutine(Restart());
    }
    private void Fall()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>().Follow = null;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        BounceForce();
    }

    private void BounceForce()
    {
        float randomX = 5;
        float randomY = Random.Range(1, 6);
        if (FallSide == "Left collider") randomX = Random.Range(-5, -9);
        else if (FallSide == "Right collider") randomX = Random.Range(5, 9);
        Vector2 fall = new Vector2(randomX, randomY);
        rigidbody.AddForce(fall, ForceMode2D.Impulse);
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}