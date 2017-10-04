using UnityEngine;
using System.Collections.Generic;

public class Subject:MonoBehaviour{
    public List<Observer> observers = new List<Observer>();

    public void Notify(EventData data)
    {
        foreach(Observer o in observers)
        {
            o.OnNotify(data);
        }
    }

    public void AddObserver(Observer o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(Observer o)
    {
        observers.Remove(o);
    }
}
