using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform initPos;
    public Transform parentPoints;
    private Transform[] points;
    public float timeLerp = 0.5f;
    public MoveType currMove;
    public float yPosElevatePlayer;

    private int currPoint = 0;
    private Animator animator;
    private string currentMove;

    private static Player _instance = null;
    public static Player Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    void Start ()
    {
        MainBeat.OnBeatAction += movePlayer;

        points = new Transform[parentPoints.childCount];
        int i = 0;
        foreach (Transform child in parentPoints)
        {
            points[i] = child;
            i += 1;
        }

        Init();

        animator = GetComponent<Animator>();
    }

    void OnDestroy()
    {
        MainBeat.OnBeatAction -= movePlayer;
    }

    void Update ()
    {
 
        if (Input.GetKeyDown(KeyCode.A))
        {
            setMove(MoveType.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setMove(MoveType.Right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setMove(MoveType.Down);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setMove(MoveType.Up);
        }
    }

    public void movePlayer(MoveType move)
    {

        animator.SetTrigger(currentMove);

        currMove = (move == MoveType.None) ? currMove : move;

        // Se compara el movimiento actual con el movimiento de elemento anterior (nextMove).
        Cell currCell = points[((currPoint - 1) >= 0) ? currPoint - 1 : 0].GetComponent<Cell>();
        if (currCell.nextMove != currMove)
        {
            //GAME OVER
            GameManager.Instance.EndGame(true);
            AudioManager.Instance.PlaySound(SoundType.WrongMove);
            return;
        }

        //Debug.Log("move: " + currMove.ToString() + " -- curr Point: " + currPoint);
        //AudioManager.Instance.PlaySound(SoundType.MovePlayer);
        points[currPoint].GetComponent<Cell>().PlaySoundCell();
        //Elevar en el Eje Y
        Vector3 posCurrPoint = new Vector3(points[currPoint].position.x, points[currPoint].position.y + yPosElevatePlayer, points[currPoint].position.z);
        LeanTween.move(gameObject, posCurrPoint, timeLerp).setEase(LeanTweenType.easeOutQuad);

        //currMove = currCell.nextMove;
        currPoint += 1;
        if (currPoint >= points.Length)
        {
            //LEVEL COMPLETE           
            GameManager.Instance.EndGame(false);
            AudioManager.Instance.PlaySound(SoundType.Success);
            currPoint = 0;
        }
        
    }

    public void setMove(MoveType move)
    {
        currMove = move;
        currentMove = move.ToString().ToLower();
    }

    public void Init()
    {
        transform.position = initPos.position;
        setMove(points[0].GetComponent<Cell>().nextMove);
        currPoint = 0;
    }
}
