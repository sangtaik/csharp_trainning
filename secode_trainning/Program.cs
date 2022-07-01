// 그런데 목록을 순회하기 위해 자원을 할당해야 하고 순회가 끝나면 해제하고 싶을때가 있죠?
// 또는 목록을 순회하는 동안 락을 걸어 thread-safe하게 코드를 만들고 싶을 수도 있습니다. 그러려면 순회를 시작하는 시점에서 lock을 하고 끝나는 시점에서 lock을 해제해야 하는데요, 이럴 때 IEnumerator 구현체에 IDisposable 인터페이스를 구현하면 됩니다.

using System.Collections;

var de = new DisposableEnumerable();

foreach (var value in de)
{
    Console.WriteLine(value);
}

public class DisposableEnumerable : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new DisposableEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}




public class DisposableEnumerator : IEnumerator<int>, IDisposable
{
    private int _value;

    public int Current => _value;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        Console.WriteLine("Call Dispose!");
    }

    public bool MoveNext()
    {
        _value++;
        if (_value is 10)
            return false;

        return true;
    }

    public void Reset()
    {
        _value = 0;
    }
}