using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDRPlayerController : MonoBehaviour
{
    public int playerNumber;
    public int pointCount;
    public MiniGameManager miniGameManager;
    [SerializeField] private float speed;
    private float horizontalMovement;
    
    [SerializeField] private PlayerInput input;
    [SerializeField] private float fireRate;
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
        _canFire = false;
        StartCoroutine(ReloadRoutine());
    }

    public void Kill()
    {
        
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }
}
