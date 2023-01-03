using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeClass
{
    internal class NodeHelper
    {

 
        public static Node<double> CreateDoubleList()
        {
            Node<double> head = null;
            const int END = -1;

            Console.WriteLine("Please enter first value or -1 to END");
            double value = double.Parse(Console.ReadLine());
            while (value != END)
            {
                //IntNode n = new IntNode(value, head);
                //head = n;
                head = new Node<double>(value, head);
                Console.WriteLine("enter next Value or -1 to END");
                value = double.Parse(Console.ReadLine());
            }
            return head;
        }
        public static Node<int> CreateIntList()
        {
            Node<int> head = null;
            const int END = -1;

            Console.WriteLine("Please enter first value or -1 to END");
            int value = int.Parse(Console.ReadLine());
            while (value != END)
            {
                //IntNode n = new IntNode(value, head);
                //head = n;
                head = new Node<int>(value, head);
                Console.WriteLine("enter next Value or -1 to END");
                value = int.Parse(Console.ReadLine());
            }
            return head;
        }
        public static int CountList<T>(Node<T> head)
        {
            int counter = 0;
            while (head != null)
            {
                counter++;
                head = head.GetNext();//i++
            }
            return counter;
        }

        public static Node<int> CreateRecursiveList(Node<int> ls)
        {
            Console.WriteLine("Enter num or -1 to End");
            int num = int.Parse(Console.ReadLine());
            if (num == -1)
                return ls;
            if (ls != null)
            {
                ls.SetNext(new Node<int>(num));
                Node<int> b = CreateRecursiveList(ls.GetNext());
                return ls;
            }
            else
                ls = new Node<int>(num);
            return CreateRecursiveList(ls);



        }

        public static bool IsSorted(Node<int> ls)
        {
            //כל עוד יש שתי חוליות בשרשרת
            while (ls != null && ls.HasNext())
            {
                //אם לא ממוין

                #region אופציה נוספת
                //Node<int> next=ls.GetNext();
                //if(ls.GetValue()>next.GetValue())
                //return false;
                #endregion
                if (ls.GetValue() > ls.GetNext().GetValue())
                    return false;
                //נתקדם הלאה (כמו לקדם אינדקס במערך
                ls = ls.GetNext();
            }
            return true;
        }
        public static bool IsEqual<X>(Node<X> ls1, Node<X>ls2)
        {
            while(ls1!=null&&ls2!=null)
            {
                if (!ls1.GetValue().Equals(ls2.GetValue))
                    return false;

                ls1 = ls1.GetNext();
                ls2.GetNext();


            }
            if (ls1 != null || ls2 != null)
                return false;
            return true;

                

        }
        public static void AddToEnd<T>(Node<T> lst,T value)
        {
            Node<T> tail = lst;
            while(tail.HasNext())
            {
                tail = tail.GetNext();
            }
            tail.SetNext(new Node<T>(value));
            tail = tail.GetNext();
        }

        public static void AddAfterValue<T>(Node<T> lst,T after,T value)
        {
            Node<T> current = lst;
            while(current!=null&&current.GetValue().Equals(after))
            {
                current=current.GetNext();
                
            }
            if(current!=null)
            {
                Node<T> node = new Node<T>(value, current.GetNext());
                current.SetNext(node);
            }    
        }

        //
        public static Node<T> AddBeforeValue<T>(Node<T> list,T before,T value)
        {
            //נבדוק האם הרשימה ריקה או שהערך לפני הוא החוליה הראשונה
            if(list==null || list.GetValue().Equals(before))
            {
                return new Node<T>(value, list);
            }
            //אחרת צריכים למצוא את המקום שלפני הערך שנרצה אותו
            Node<T> current = list;
            Node<T> next = current.GetNext();
            while(current.HasNext()&&!next.GetValue().Equals(before))
            {
                current = current.GetNext();
                next=current.GetNext();
            }

            //נצא כשהגענו לערך לפני before
            AddAfterValue(current, current.GetValue(), value);
            return list;
            
        }
        public static Node<T> AddBeforeValueWithDummy<T>(Node<T> list, T before, T value)
        {
            Node<T> dummy = new Node<T>(default, list);
            Node<T> current = list;
            Node<T> next = current.GetNext();
            while (current.HasNext() && !next.GetValue().Equals(before))
            {
                current = current.GetNext();
                next = current.GetNext();
            }

            //נצא כשהגענו לערך לפני before
            AddAfterValue(current, current.GetValue(), value);
            return dummy.GetNext();

        }

        public static Node<T> DeleteValue(Node<T> value)
        {

        }

    }
}
