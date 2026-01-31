using UnityEngine;

public class WiggleSubject : MonoBehaviour
{
    [SerializeField]
    private float _wiggleSpeed = 2f;
    [SerializeField]
    private float _wiggleAngle = 10f;
    [SerializeField]
    private bool _wiggleEnabled = false;

    void Update()
    {
        if (_wiggleEnabled)
        {
            float wiggleX = (Mathf.PerlinNoise(Time.time * _wiggleSpeed, 0f) - 0.5f) * 2f * _wiggleAngle;
            float wiggleY = (Mathf.PerlinNoise(Time.time * _wiggleSpeed, 1f) - 0.5f) * 2f * _wiggleAngle;
            float wiggleZ = (Mathf.PerlinNoise(Time.time * _wiggleSpeed, 2f) - 0.5f) * 2f * _wiggleAngle;
            transform.rotation = Quaternion.Euler(wiggleX, wiggleY, wiggleZ);
        }
    }

    public void SetWiggle(bool value)
    {
        _wiggleEnabled = value;
    }
}
