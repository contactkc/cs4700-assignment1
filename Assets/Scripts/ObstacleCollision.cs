using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public bool guiOn;
    public string text = "Lost!";
    public Rect boxSize = new Rect(0, 0, 200, 150);
    private GUIStyle textStyle;
    private GUIStyle buttonStyle;

    void Start()
    {
        textStyle = new GUIStyle();
        textStyle.fontSize = 60;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.red;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 20;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            guiOn = true;
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null) {
                player.StopMovement();
            }
        }
    }

    void OnGUI()
    {
        if (guiOn)
        {
            Rect centered = new Rect((Screen.width - boxSize.width) / 2,
                (Screen.height - boxSize.height) / 2,
                boxSize.width, boxSize.height);

            GUI.Box(centered, "");
            GUI.Label(new Rect(centered.x, centered.y, centered.width, 100), text, textStyle);
            
            if (GUI.Button(new Rect(centered.x + 50, centered.y + 100, 100, 30), "Restart", buttonStyle))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
