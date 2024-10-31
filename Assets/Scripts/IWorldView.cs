using System;

public interface IWorldView<in T> : IDisposable
{
    void SetController(T presenter);
}