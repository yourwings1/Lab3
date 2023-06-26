using System;
using System.Diagnostics;
using System.Text;

class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class CyclicLinkedList
{
    private Node start;

    public void PushFront(int data)
    {
        Node newNode = new Node(data);
        if (start == null)
        {
            newNode.Next = newNode;
            start = newNode;
        }
        else
        {
            newNode.Next = start.Next;
            start.Next = newNode;
        }
    }

    public void GoByS(int s, int k, int l)
    {
        Node temp = start;
        do
        {
            temp = temp.Next;
        } while (temp.Next != start);
        int t = 0;
        while (t < Size() - k - l)
        {
            for (int i = 0; i < s - 1; i++)
            {
                do
                {
                    temp = temp.Next;
                } while (temp.Data != 1);
            }
            temp.Next.Data = 2;
            t++;
        }
    }

    public void AddColors(int gr_al, int wh_al, int gr_dead, int wh_dead)
    {
        Node temp = start;
        for (int i = 0; i < Size(); i++)
        {
            // 1 - alive, 2 - dead
            // 3 - grey, 4 = white
            if (temp.Data == 1)
            {
                if (wh_al > 0)
                {
                    temp.Data = 4;
                    wh_al--;
                }
                else
                {
                    temp.Data = 3;
                }
            }
            else
            {
                if (wh_dead > 0)
                {
                    temp.Data = 4;
                    wh_dead--;
                }
                else
                {
                    temp.Data = 3;
                }
            }
            temp = temp.Next;
        }
    }

    public void Show()
    {
        Node temp = start;
        do
        {
            Console.Write(temp.Data == 3 ? "G " : "W ");
            temp = temp.Next;
        } while (temp != start);
        Console.WriteLine();
    }

    public int Size()
    {
        int count = 0;
        Node temp = start;
        do
        {
            count++;
            temp = temp.Next;
        } while (temp != start);
        return count;
    }

    public void ShowColors()
    {
        Console.WriteLine("\nПорядок:");
        Node temp = start;
        do
        {
            Console.Write(temp.Data == 3 ? "G " : "W ");
            temp = temp.Next;
        } while (temp != start);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Кольцова Екатерина Владимировна\n090301-ПОВа-з21");
        Console.Write("\nВведите N (число серых): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("M(число белых): ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("S: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("K(кол - во оставшихся серых): ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("L(кол - во оставшихся белых): ");
        int l = int.Parse(Console.ReadLine());

        CyclicLinkedList miceList = new CyclicLinkedList();
        for (int i = 0; i < n + m; i++)
        {
            miceList.PushFront(1);
        }

        miceList.GoByS(s, k, l);
        miceList.AddColors(k, l, n - k, m - l);

        miceList.ShowColors();
    }
}
