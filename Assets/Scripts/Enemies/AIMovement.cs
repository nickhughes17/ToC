using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AIMovement : MonoBehaviour
{


    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemyStealthUI stealthUi;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    public float speed = 1f;
    private float waitTime;
    public float startWaitTime = 3f;
    private float surpriseTime;
    public float startSurpriseTime = 3f;
    public float viewDistance;
    public float startViewDistance = 10f;
    private float chaseTime;
    public float startChaseTime = 3f;
    private bool playerCaught = false;
    private float step;

    public Vector3 targetPosition;
    public Vector3 idleDirection;
    private Vector3 tempPosition;
    private Vector3 currentDirection;
    protected Vector3 target;
    public Animator animator;
    public Rigidbody2D rb;
    [SerializeField] private SqueakController squeakController;

    //set the waitTime (idle time) to the startWaitTime variable.
    //generate a new target to start walking.
    void Start()
    {
        viewDistance = startViewDistance;
        waitTime = startWaitTime;
        surpriseTime = startSurpriseTime;
        chaseTime = startChaseTime + startSurpriseTime;
        targetPosition = GetRandomTarget();

    }

    //generate a new target position to move to, within the minX,maxX,minY,maxY range.
    private Vector3 GetRandomTarget()
    {
        target = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
        return target;
    }

    //called once per frame
    void Update()
    {
        //if game started
        //if(howToPlay.gameStarted){
        step = speed * Time.deltaTime;
        currentDirection = (targetPosition - transform.position).normalized;
        //set fov variables
        idleDirection = new Vector3(currentDirection.x, currentDirection.y - 100, currentDirection.z);
        fieldOfView.SetOrigin(transform.position);

        if (fieldOfView.playerSeen)
        {
            //chasetime = 0, get random target, isChasing = false.
            if (chaseTime <= 0)
            {
                //player escaped for long enough
                PlayerEscaped();
                Wandering();
                //chasetime not zero, chase 
            }
            else
            {
                //if player is seen, targetposition is player position, aim direction is player position
                fieldOfView.SetAimDirection(player.currentPosition - transform.position);
                //if the player's boxcollider collides with the enemy's boxcollider
                if (playerCaught)
                {
                    PlayerHasBeenCaught();
                }
                else
                {
                    Chasing(player.currentPosition);
                }
                chaseTime -= Time.deltaTime;
            }
        }
        else
        {
            //player isnt seen, wander
            stealthUi.isChasing = false;
            Wandering();
        }
        player.tag = "Player";
    }

    //if colliding with a 'trigger' collider, get a new target
    //for avoiding being stuck with an unreachable target
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CollisionTag")
        {
            targetPosition = GetRandomTarget();
        }
        else if (collision.tag == "Player")
        {
            playerCaught = true;
        }
    }

    //player caught, turn off chasing animation, idle, become searchimmune
    private void PlayerHasBeenCaught()
    {
        Debug.Log("PLAYER CAUGHT");
        animator.SetBool("isChasing", false);
        fieldOfView.SetAimDirection(idleDirection);
        speed = 0;
        fieldOfView.searchImmune = true;
        fieldOfView.playerSeen = false;
        playerCaught = false;
        player.isCaught = true;
        stealthUi.isChasing = false;
    }

    //if surprise time is over, change animations and transform towards player current position at a faster speed.
    private void Chasing(Vector3 playerPosition)
    {
        if (surpriseTime <= 0)
        {
            animator.SetBool("isSurprised", false);
            animator.SetBool("isChasing", true);
            animator.SetFloat("Horizontal", (transform.position.x - playerPosition.x));
            animator.SetFloat("Vertical", (transform.position.y - playerPosition.y) * -1);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 0.003f + 0.002f * squeakController.currentSqueak);
            Debug.Log( 0.003f + 0.001f * squeakController.currentSqueak);
            stealthUi.SetChaseProgress(Mathf.RoundToInt(chaseTime / startChaseTime * 100));
            stealthUi.isChasing = true;
        }
        else
        {
            //if surprise time isnt over, stay in surprised animation and wait.
            animator.SetBool("isSurprised", true);
            surpriseTime -= Time.deltaTime;
        }
    }

    //if position is the same as target position, wait idle for waitTime seconds, then find a new target.
    private void Wandering()
    {
        if ((Vector3)transform.position == targetPosition)
        {
            if (waitTime <= 0)
            {
                //if wait time is over, set speed parameter to speed, get a random new target, 
                //then set waittime to startwait time and set aim direction to current direction
                animator.SetFloat("Speed", speed);
                targetPosition = GetRandomTarget();
                waitTime = startWaitTime;
                fieldOfView.SetAimDirection(currentDirection);
            }
            else
            {
                Idle();
                waitTime -= Time.deltaTime;
            }
        }
        //if position isnt the same as target position, transform the enemy's position towards the target position.
        else
        {
            fieldOfView.SetAimDirection(currentDirection);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            //animate the direction
            animator.SetFloat("Speed", speed);
            animator.SetFloat("Horizontal", (transform.position.x - targetPosition.x) * -1);
            animator.SetFloat("Vertical", (transform.position.y - targetPosition.y) * -1);
        }
    }

    //chase is over, resume wandering
    private void PlayerEscaped()
    {
        chaseTime = startChaseTime + startSurpriseTime;
        targetPosition = GetRandomTarget();
        fieldOfView.playerSeen = false;
        animator.SetBool("isChasing", false);
        surpriseTime = startSurpriseTime;
        stealthUi.isChasing = false;
        squeakController.currentSqueak += 2;
    }

    //idle in position
    private void Idle()
    {
        targetPosition = transform.position;
        animator.SetFloat("Speed", 0);
        currentDirection = idleDirection;
        fieldOfView.SetAimDirection(idleDirection);
    }

}