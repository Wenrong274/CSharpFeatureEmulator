using System.Collections;

public class Node<T> : IEnumerable<T>
{
    private T value;
    private Node<T> next;

    public int Length
    {
        get
        {
            int result = 1;
            Node<T> current = this;
            while ((current = current.next) != null)
            {
                result++;
            }
            return result;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index > 0 && next != null)
            {
                return next[index - 1];
            }
            return value;
        }
        set
        {
            this.value = value;
        }
    }

    public Node(T value)
    {
        this.value = value;
    }

    public void Add(Node<T> item)
    {
        Node<T> curr = this;
        while (curr.next != null)
        {
            curr = curr.next;
        }
        curr.next = item;
    }

    public bool Contains(Node<T> item)
    {
        Node<T> curr = this;
        while (curr != null)
        {
            if (curr.Equals(item))
            {
                return true;
            }
            curr = curr.next;
        }
        return false;
    }

    public void Remove(Node<T> item)
    {
        Node<T> curr = this;
        while (curr != null)
        {
            if (curr.Equals(item))
            {
                curr.next = curr.next.next;
                return;
            }
            curr = curr.next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var temp = this;
        while (temp != null)
        {
            yield return temp.value;
            temp = temp.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
