using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour
{
    public Material offMaterial;
    public Material onMaterial;
    public Light controledLight;
    public bool flashing = false;
    public float minFlashTime = 1.0f;
    public float maxFlashTime = 1.5f;
    public bool state = false;
    public float flashAnimationTime = 0.2f;

    private float _currentFlashTime = 0;
    private AudioSource _audioSource;
    private int _animationState = 0;
    private MeshRenderer _lamp;

	void Start ()
    {
        _audioSource = GetComponent<AudioSource>();

        _lamp = GetComponentInChildren<MeshRenderer>();
    }
	
	void Update ()
    {
        _currentFlashTime -= Time.deltaTime;
        if (_animationState % 2 == 0 && state != controledLight.enabled)
            set(state);

        if(_currentFlashTime <= 0)
        {
            if (!state || !flashing)
                return;
            
            if(_animationState>3 || Random.value > 0.8f)
            {
                _animationState = 0;
                setOn();
                _currentFlashTime = Random.value * (maxFlashTime - minFlashTime) + minFlashTime;
            }
            else
            {
                _animationState++;
                _currentFlashTime = flashAnimationTime;

                if (_animationState % 2 == 1)
                    setOff();
            }
        }
	}

    void set(bool value)
    {
        if (value)
            setOn();
        else setOff();
    }

    void setOn()
    {
        controledLight.enabled = true;
        _lamp.material = onMaterial;
    }

    void setOff()
    {
        controledLight.enabled = false;
        _lamp.material = offMaterial;
    }
}
