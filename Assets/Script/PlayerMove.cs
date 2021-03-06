using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    UIManager manager;

    Rigidbody2D rigid;
    Animator anim;

    Vector2 dirVec = Vector2.down;

    float h;
    float v;
    bool ishMove;
    bool isActing = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
private void Start() {
    manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
}
    private void Update()
    {
        Move();
        LookAt();
        Action();
        OpenMenu();
    }

    void Move()
    {
        if (isActing)
            return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            ishMove = true;
        else if (vDown || hUp)
            ishMove = false;
        else if (hUp || vUp)
            ishMove = h != 0;

        anim.SetFloat("vSpeed", v);
        anim.SetFloat("hSpeed", h);

        Vector2 moveVec = new Vector2(h, v);
        anim.SetBool("isMove", moveVec.sqrMagnitude > 0.01f);
        rigid.velocity = new Vector2(h, v) * speed;
    }

    void LookAt()
    {
        if (v > 0)
            dirVec = Vector2.up;
        else if (v < 0)
            dirVec = Vector2.down;
        else if (h > 0)
            dirVec = Vector2.right;
        else if (h < 0)
            dirVec = Vector2.left;

        anim.SetFloat("dirH", dirVec.x);
        anim.SetFloat("dirV", dirVec.y);
    }

    void Action()
    {
        Debug.DrawRay(transform.position, dirVec * 1.3f, new Color(0, 1, 0));
        if (Input.GetButtonDown("Action"))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 1.3f, LayerMask.GetMask("Object", "NPC"));
            if (null != rayHit.collider)
            {
                IInterAction target = rayHit.collider.GetComponent<IInterAction>();
                if (null != target)
                {
                    isActing = target.ReAction();
                    return;
                }
            }
        }
    }
    void OpenMenu()
    {
        if(Input.GetButtonDown("Menu"))
            manager.SetActiveDialog(!manager.GetActiveDialog());
        
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = ishMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
    }
}
