namespace StreamCompanionTypes.DataTypes
{
    /// <summary>
    /// configuration entry with can store any primitive type(int, string, double...), for arrays of any sort serialize data to string beforehand(json recommended)
    /// </summary>
    public class ConfigEntry
    {
        public ConfigEntry(string name, object value)
        {
            Name = name;
            DefaultValue = value;
        }
        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public T Default<T>()
        {
            return (T)DefaultValue;
        }
    }
}