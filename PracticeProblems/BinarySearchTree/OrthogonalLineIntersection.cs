using System;
using System.Collections.Generic;

namespace PracticeProblems.BinarySearchTree
{
    /// <summary>
    /// given set of lines with x1 y1 and x2 y2 as start and end cordinates
    /// find all intersections.
    /// Lines are orthogonal and no two lines have same cordinates
    /// 
    /// Sweep vertical line from left to right.
    /// x-coordinates define events.
    // h-segment(left endpoint) : insert y-coordinate into BST.
    // h-segment(right endpoint) : remove y-coordinate from BST.
    // v-segment: range search for interval of y-endpoints
    /// </summary>
    public class OrthogonalLineIntersection
    {
        BST tree;
        List<Event> events;
        public OrthogonalLineIntersection(List<Line> lines)
        {
            events = (List<Event>)CreateEvents(lines);
            events.Sort(new LineCmp());  
            tree = new BST();

        }

        public IEnumerable<Tuple<int,int>> Get(List<Event> events)
        {
            List<Tuple<int, int>> intersections = new List<Tuple<int, int>>();
            foreach (Event e in events)
            {
                if(e.Segment == 'H') // h segment
                {
                    if(e.Start) // insert y cordinate in the start
                    {
                        tree.Put(e.y1);
                    }
                    else
                    {
                        tree.Delete(e.y1);
                    }

                }
                else // vertical segemt , so search for the intersection
                {
                    var intersec = (List<int>)tree.Select(e.y2, e.y1); // y2 > y1

                    if(intersec.Count > 0)
                    {
                        foreach(int p in intersec)
                        {
                            intersections.Add(new Tuple<int, int>(e.x, p));
                        }
                    }
                }
            }

            return intersections;
        }

        /// <summary>
        /// create event for each cordinates of the line
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private IEnumerable<Event> CreateEvents(List<Line> lines)
        {
            List<Event> events = new List<Event>();

            foreach(Line l in lines)
            {
                
                if(l.x1 == l.x2) // perpendicular
                {
                    Event e = new Event();
                    e.Segment = 'V';
                    e.x = l.x1;
                    e.Start = true;
                    e.End = true;

                    events.Add(e);
                }
                else
                {
                    events.Add(new Event()
                    {
                        x = l.x1,
                        Start = true,
                        End = false,
                        y1 = l.y1,
                        Segment = 'H'
                    });

                    events.Add(new Event()
                    {
                        x = l.x2,
                        Start = false,
                        End = true,
                        y2 = l.y2,
                        Segment = 'H'
                    });
                }

                
            }

            return events;
        }
    }

    public class LineCmp : IComparer<Event>
    {
        public int Compare(Event e1, Event e2)
        {
            return e1.x - e2.x;
        }
    }
    public class Event
    {
        public bool Start { get; set; }
        public bool End { get; set; }
        public int x { get; set; }
        public int y2 { get; set; }
        public int y1 { get; set; }
        public char Segment { get; set; }
    }

    public class Line
    {
        public Line(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
    }

    class BST
    {
        Node root;
        public void Put(int y)
        {
            root = Put(root, y);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="current"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node Put(Node current, int y)
        {
            if (current == null) return new Node(y);
            int cmp = y.CompareTo(current.Y);

            if(cmp < 0)
            {
                current.Left = Put(current.Left, y);
            }
            else if(cmp > 0)
            {
                current.Right = Put(current.Right, y);
            }
            else
            {
                current.Y = y;
            }
            return current;
        }

        public IEnumerable<int> Select(int y1, int y2)
        {
            Queue<int> q = new Queue<int>();

            Select(y1, y2, root, q);
            return q;
        }

        private void Select(int lo, int hi, Node x, Queue<int> q)
        {
            if (x == null) return;

            int cmpLo = lo.CompareTo(x.Y);
            int cmpHi = hi.CompareTo(x.Y);

            if(cmpLo > 0)
            {
                Select(lo, hi, x.Left, q);
            }

            if(x.Y >= lo && x.Y <= hi)
            {
                q.Enqueue(x.Y);
            }

            if(cmpHi < 0)
            {
                Select(lo, hi, x.Right, q);
            }

        }


        public void Delete(int y)
        {

            Delete(root, y);
        }

        private Node Delete(Node x, int y)
        {
            if (x == null) return null;

            int cmp = y.CompareTo(x.Y);
            if (cmp < 0) x.Left = Delete(x.Left, y);
            else if (cmp > 0) x.Right = Delete(x.Right, y);
            else
            {
                if (x.Left == null) return x.Right;
                if (x.Right == null) return x.Left;
               
                    Node temp = x;
                    x = GetMin(temp.Right);
                    x.Right = DeleteMin(temp.Right);
                    x.Left = temp.Left;              
            }

            return x;
        }
        private Node GetMin(Node x)
        {
            if (x.Left == null) return x;

            return GetMin(x.Left);
        }
        private Node DeleteMin(Node x)
        {
            if (x.Left == null) return x.Right;

            x.Left = DeleteMin(x.Left);
            return x;
        }


    }

    class Node
    {
        public int Y { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int key)
        {
            Y = key;
        }
    }
}
