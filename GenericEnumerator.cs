using System.Collections;

namespace HomeWork_4;
internal class GenericEnumerator<T> : IEnumerable<T>
{
    private T[] _data = [];
    private int _count = 0;

    public int Capacity { get { return _data.Length; } set { Array.Resize(ref _data, value); } }
    /// <summary>
    /// Индексатор
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T this[int i]
    {
        get
        {
            if (i >= 0 && i < _count)
                return _data[i];
            else
                throw new ArgumentException($"Індекс {i} неприпустимий. У колекції всього {_count} елементів");
        }
        set { _data[i] = value; }
    }

    public delegate void MethodOnExpanded(GenericEnumerator<T> sender, int newSize);
    public event MethodOnExpanded? OnExpanded;

    /// <summary>
    /// Добавляет элемент в коллекцию, возвращает индекс добавленного элемента.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public int Add(T element)
    {
        var new_index = _count;
        _count++;

        if (Capacity == 0)
        {
            OnExpanded?.Invoke(this, 4);
            Capacity = 4;
        }
        else
        if (Capacity <= _count)
        {
            OnExpanded?.Invoke(this, Capacity * 2);
            Capacity *= 2;
        }
        _data[new_index] = element;
        return new_index;
    }
    /// <summary>
    /// Реализация методов  IEnumerable<T>
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
