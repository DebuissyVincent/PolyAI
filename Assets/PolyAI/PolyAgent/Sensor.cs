using UnityEngine;

public delegate void SenseBroacast(SensorType _sense);

public enum SensorType
{
    Sight,
    Hearing,
    Touch,
    Smell,
    MAX
}

[System.Serializable]
public class Sensor : MonoBehaviour
{
    [SerializeField]
    private SensorType type;
    [SerializeField] [Range(0, 1)]
    private float sensibility = 1.0f;
    [SerializeField]
    private float range;
    [SerializeField] [Range(0, 360)]
    private float angleX = 90.0f;
    [SerializeField] [Range(0, 360)]
    private float angleY = 90.0f;
    [SerializeField]
    private Vector3 direction = Vector3.forward;
    [SerializeField]
    private float refreshRate = 0.5f;
    private float timer = 0.0f;

    void Trigger()
    {
        // Récupérer tous les agents dans la zone de repérage et s'inscrire sur leur delegate.
    }

    private void Start()
    {
        transform.parent.GetComponent<PolyAgentBase>();
    }

    private void Update()
    {
        if (timer < refreshRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            Trigger();
        }
    }
}
