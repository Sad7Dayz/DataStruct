/*
 * 단일 연결 리스트
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }
        public SinglyLinkedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;

        /*
         * add 메서드 : 리스트가 비어 있으면 Head에 새 노드를 할당하고 비어 있지 않으면 마지막 노드를 찾아 이동한 후
         * 마지막 노드 다음에 새 노드를 추가한다
         */
        public void Add(SinglyLinkedListNode<T> newNode)
        {
            //리트스가 비어 있으면
            if (head == null)
            {
                head = newNode;
            }
            else //비어 있지 않으면
            {
                var current = head;
                //마지막 노드로 이동하여 추가
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        /*
         * AddAfter 메서드 : 새노드의 Next에 현재 노드의 Next를 먼저 할당하고, 현재 노드의 Next에 새 노드를 할당한다
         */
        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }
        /*
         * Remove 매서드 : 삭제 할 노드가 첫 노드이면, Head의 다음노드 즉 두번째 노드를 Head에 할당하고, 첫 노드가 아니면
         * 해당 노드를 검색하여 삭제한다. 해당 노드를 검색할 때, 단일 연결 리스트는  단방향으로 연결되어 있으므로
         * 삭제할 노드를 바로 이전 노드를 찾아서 삭제 노드를 지워야한다.
         * 즉, 이전 노드의 Next에 삭제노드의 Next를 할당 해야 지울 수 있다.
         */
        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            //삭제할 노드가 첫 노드이면
            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else //첫 노드가 아니면, 해당 노드를 검색하여 삭제
            {
                var current = head;

                //단방향이므로 삭제할 노드의 바로이전 노드를 검색해야
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    //이전 노드의 Next에 삭제노드의 Next를 할당
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }
            //만약 index가 리스트 카운트보다 크면  null이 리턴됨
            return current;
        }
        /*
         * Count() 메서드 : Head부터 마지막 노드까지 이동하면서 카운트를 증가 시킨다.
         */
        public int Count()
        {
            int cnt = 0;

            var current = head;
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }
            return cnt;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //정수형 단일 연결 리스트 생성
            var list = new SinglyLinkedList<int>();

            //리스트에 0~4추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }

            //Index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            //Index가 1인 요소 가져오기
            node = list.GetNode(1);

            //Index가 1인 요소 뒤에 100 삽입
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            //리스트 카운트 체크
            int count = list.Count();

            //전체 리스트출력
            //결과 0 1 100 3 4

            for(int i =0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.WriteLine(n.Data);
            }
        }
    }
}
