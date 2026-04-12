using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _flyKey = KeyCode.Space;
    [SerializeField] private KeyCode _attackKey = KeyCode.F;

    private bool _isFly;
    private bool _isAttack;

    private void Update()
    {
        if (Input.GetKeyDown(_flyKey))
            _isFly = true;

        if (Input.GetKeyDown(_attackKey))
            _isAttack = true;
    }

    public bool GetIsFly() =>
        GetBoolAsTrigger(ref _isFly);

    public bool GetIsAttack() =>
        GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}