using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Player1 UI")]
    public PlayerController1 player1;
    public Text p1_accText;
    public Text p1_maxJumpText;
    public Text p1_massText;

    [Header("Player2 UI")]
    public PlayerController1 player2;
    public Text p2_accText;
    public Text p2_maxJumpText;
    public Text p2_massText;

    public PlayerController1 p1;
    public Sword sword_Acc;
    public PlayerController1 p2;
    public Hamer hamer_Acc;

    Rigidbody rb_P1;
    Rigidbody rb_P2;

    private void Start()
    {
        GameObject p1 = GameObject.Find("Player1");
        rb_P1 = p1.GetComponent<Rigidbody>();

        GameObject p2 = GameObject.Find("Player2");
        rb_P2 = p2.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (player1 != null)
        {
            p1_accText.text = " Acc\n" + sword_Acc.acc;
            p1_maxJumpText.text = "Air Jump " + p1.maxJumps;
            p1_massText.text = "Mass\n " + rb_P1.mass;
        }
        if (player2 != null)
        {
            p2_accText.text = " Acc\n" + hamer_Acc.acc;
            p2_maxJumpText.text = "Air Jump " + p2.maxJumps;
            p2_massText.text = "Mass\n " + rb_P2.mass;
        }
    }
}
