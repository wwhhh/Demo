using UnityEngine;
using UnityEngine.UI;
using Game;

public class InputTest : MonoBehaviour
{
    public Button yawAdd;
    public Button yawMinus;
    public Button pitchAdd;
    public Button pitchMinus;

    void Start()
    {

        yawAdd.onClick.AddListener(() =>
        {
            KInput.instance.Yaw += 30;
        });

        yawMinus.onClick.AddListener(() =>
        {
            KInput.instance.Yaw -= 30;
        });

        pitchAdd.onClick.AddListener(() =>
        {
            KInput.instance.Pitch += 30;
        });

        pitchMinus.onClick.AddListener(() =>
        {
            KInput.instance.Pitch -= 30;
        });
    }

}
