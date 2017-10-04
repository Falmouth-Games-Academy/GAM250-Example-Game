
public class EventData
{
    public EventData()
    {

    }
}

public interface Observer
{
    void OnNotify(EventData data);
}
