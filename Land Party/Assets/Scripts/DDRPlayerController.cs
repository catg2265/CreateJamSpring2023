using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDRPlayerController : MonoBehaviour
{
    public int playerNumber;
    public int pointCount;
    [SerializeField] private GameManager gm;
    public MiniGameManager miniGameManager;
    [SerializeField] private float speed;
    [SerializeField] private Object cannonBallPrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private PlayerInput input;
    public int playerID = 0;
    
    private float horizontalMovement;
    private bool _canFire = true;
    private Rigidbody2D rb;

    private float score = 0;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
        playerID = goArr.Length-1;
        
        input.ActivateInput();
    }

    void Update()
    {
        score += Mathf.Lerp(0, 10, Time.deltaTime);
        Vector2 curr = input.actions["DDR"].ReadValue<Vector2>();
        if (curr is { x: 1, y: 0 } && _canFire)
        {
            Shoot();
        }

        Debug.Log(input.GetDevice<InputDevice>().deviceId.ToString());
        horizontalMovement = input.actions["Move"].ReadValue<Vector2>().x;
        rb.velocity = new Vector2(horizontalMovement * speed, 0);
    }

    public void Shoot()
    {
        Debug.Log("Fire in the hole!");
        var position = transform.position;
        Object newTrashBall = Instantiate(cannonBallPrefab, transform, true);
        newTrashBall.GameObject().transform.position = position;
        newTrashBall.GameObject().GetComponent<TrashBallScript>().speed = 3f;
        
        _canFire = false;
        StartCoroutine(ReloadRoutine());
    }

    public void Kill()
    {
       // This code is run when the player is hit by a player head (and dies). 
       gm.totalPeople--;
       gm.playersPartialScore[playerID] = score;
       enabled = false;
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }
}
