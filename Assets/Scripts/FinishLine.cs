using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public bool guiOn;
    public string text = "Win!";
    public Rect boxSize = new Rect(0, 0, 200, 100);
    private GUIStyle textStyle;
    private GUIStyle buttonStyle;

    private void Start() {
        textStyle = new GUIStyle();
        textStyle.fontSize = 60;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 20;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) // Check if it's the player
        {
            guiOn = true;
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StopMovement(); // Stop player movement
            }
        }
    }

    void OnGUI() {
        if (guiOn == true) {
            Rect centered = (new Rect ((Screen.width - boxSize.width) / 2, 
            (Screen.height - boxSize.height) / 2, 
            boxSize.width, boxSize.height));

            GUI.Box(centered, "");
            GUI.Label(centered, text, textStyle);

            if (GUI.Button(new Rect(centered.x + 50, centered.y + 100, 100, 30), "Restart", buttonStyle))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
