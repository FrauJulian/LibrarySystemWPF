namespace Models;

public class ParamValue<T> : IParamValue
{
    public T Value { get; set; }
    public string Name { get; set; }

    object IParamValue.Value
    {
        get => Value;
        set => Value = (T)value;
    }
}