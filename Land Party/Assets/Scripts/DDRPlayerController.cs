using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDRPlayerController : MonoBehaviour
{
    public int playerNumber;
    public int pointCount;
    public MiniGameManager miniGameManager;
    [SerializeField] private float speed;
    [SerializeField] private Object cannonBallPrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private PlayerInput input;
    
    private float horizontalMovement;
    private bool _canFire = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 curr = input.actions["DDR"].ReadValue<Vector2>();
        if (curr is { x: 1, y: 0 } && _canFire)
        {
            Shoot();
        }
        
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
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }
}
