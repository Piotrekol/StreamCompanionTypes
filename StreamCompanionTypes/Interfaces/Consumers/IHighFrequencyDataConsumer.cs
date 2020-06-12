namespace StreamCompanionTypes.Interfaces.Consumers
{
    public interface IHighFrequencyDataConsumer
    {
        void Handle(string content);
        void Handle(string name, string content);
    }
}