using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        /// <summary>
        /// פעולה המוחקת את החוליה העוקבת
        /// </summary>
        /// <param name="node"></param>
        /// <returns>מחזירה את החוליה שנמחקה</returns>
        public static Node<T> DeleteAfterNode<T>(Node<T> node )
        {
            Node<T> del = node.GetNext();//החוליה למחיקה
            //נבדוק שזו לא החוליה האחרונה
            if (del != null)
            {
                node.SetNext(del.GetNext());
                del.SetNext(null);
            }
            //  אחרת 
            //זו עכשיו החוליה האחרונה
            else
                node.SetNext(null);

            return del;
        }

        public static void AddAfterNode<T>(Node<T> node,T val)
        {
            node.SetNext(new Node<T>(val, node.GetNext()));
        }


        public static Node<char> Reverse(Node<char> text)
        {
            Node<char> tail = text;//החוליה הראשונה תהפוך בסוף התהליך לזנב
            Node<char> head = text;//בשלב ההתחלתי הראש הוא החוליה הראשונה
            Node<char> next=tail.GetNext();
            while (tail.HasNext())
            {
                tail.SetNext(next.GetNext());
                next.SetNext(head);
                head = next;
                next = tail.GetNext();

            }

            return head;
        }

        public static Node<char> ReverseWithDummy(Node<char>text)
        {
            Node<char> tail = text;//החוליה הראשונה תהפוך בסוף התהליך לזנב
            Node<char> dummy = new Node<char>(' ', text);//ניצור חוליה ראשונה פיקטיבית
            Node<char> next = tail.GetNext();
            while(tail.HasNext())
            {
                tail.SetNext(next.GetNext());
                next.SetNext(dummy.GetNext());
                dummy.SetNext(next);
                
            }
            return dummy.GetNext();
        }
       
        public static Node<char>ReverseVer03(Node<char>text)
        {
            Node<char> current = text;
            Node<char> tail = text;//וכרגע היא גם הזנב...

            //נגיע לחוליה האחרונה
            while (current.HasNext())
            {
                current = current.GetNext();
            }
            Node<char> head = current;//החוליה האחרונה תהפוך לראשונה
            current = tail;
            while(current==head)
            {
              //השלמה של הקוד   
            }
            return head;

        }

        public static void AddAfterNode1<T>(Node<T> node,T value)
        {
            node.SetNext(new Node<T>(value, node.GetNext()));
        }
        public static Node<int> WithoutDuplicates(Node<int> list)
        {
            Node<int> head = new Node<int>(list.GetValue());
            Node<int> tail = head;
            list = list.GetNext(); //כבר הכנסתי את הערך אפשר להקדם
            //כל עוד לא הגעתי לסוף של הרשימה המקורית
            while (list != null)
            {
                if(!IsExists(head,list.GetValue()))
                {
                    //tail.SetNext(new Node<int>(list.GetValue()));
                    //tail = tail.GetNext();
                    AddAfterNode1(tail,list.GetValue());
                    tail = tail.GetNext();
                }
                list = list.GetNext();
            }
            return head;

        }

        public static bool IsExists<T>(Node<T> list, T value)
        {
            while(list!=null)
            {
                if (list.GetValue().Equals(value))
                    return true;
                list = list.GetNext();
            }
            return false;   

        }
       


    }
}
