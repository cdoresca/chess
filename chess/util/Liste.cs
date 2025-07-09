using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace chess.util
{
    internal class Node<T>
    {
        T Value;
        Node<T> next;
        Node<T> prev;
     
        public Node(T type, Node<T> next,Node<T> prev)
        {
            Value = type;
            this.next = next;
            this.prev = prev;
        
        }
        public Node<T> getNext() {  return next; }
        public T getValue() { return Value; }
        public void setNext(Node<T>other) { next = other; }

        public Node<T> getPrev() { return prev; }

        public void setPrev(Node<T> other) { prev = other; }
  
    }
    internal class Liste<T>
    {
        Node<T> root;

        Node<T> end;
        public Liste() {}

        public Node<T> begin() {  return root; }
        public Node<T> End(){  return end; }
        public bool isEmpty() {  return root == null; }
        public int lentgh() {
            if (isEmpty()) {  return 0; }
            int cpt = 0;
            Node<T> tmp = root;
            cpt++;
            while (tmp.getNext() != null)
            {
                tmp = tmp.getNext();
                cpt++;
            }
            return cpt;
        }
        public bool Search(T value) {

            Node<T> tmp = root;
            while (tmp.getNext() != null)
            {
                if (tmp.getValue().Equals(value))
                { return true; }
                
                
                    tmp = tmp.getNext();
                
            }
            return false;
        }

        public Node<T> SearchAt(int index)
        {
            int cpt = 0;
            Node<T> tmp = root;
            cpt++;
            while (tmp.getNext() != null)
            {
                if (index == cpt) {  return tmp; }
                tmp = tmp.getNext();
                cpt++;
            }
            return null;
        }

        public Node<T> SearchAt(T value)
        {

            Node<T> tmp = root;
            while (tmp.getNext() != null)
            {
                if (tmp.getValue().Equals(value))
                { return tmp; }


                tmp = tmp.getNext();

            }
            return null;
        }
        public void Add(T value)
        {
            if (isEmpty()) { 
                root = new Node<T>(value, null,null); 
                end = root; 
            }
            else {
                end.setNext(new Node<T>(value,null,end)); 
                end=end.getNext();
                root.setPrev(end);
            }
        }
        public void addFirst(T value) {
            if (isEmpty()) { Add(value); }
            Node<T> tmp = root;
            root=new Node<T>(value,tmp,end);
            tmp.setPrev(root);
            end.setNext(root);
        }
        public void addLast(T value) { Add(value); }
        public void Add(int index,T value)
        {
            Node<T> tmp=SearchAt(index);
            Node<T> node = new Node<T> ( value, tmp.getNext(),tmp);
            tmp.getPrev().setNext(node);
            tmp.setNext(node);
        }
        public T removeFirst()
        {
            if (isEmpty()) { return default(T); }
            root=root.getNext();
            root.setPrev(end);
            end.setNext(root);
            return root.getValue();
        }
        public T removeLast() {
            if (isEmpty()) { return default(T); }
            Node<T> tmp = end;
            end=end.getPrev();
            end.setNext(root);
            root.setPrev(end);
            return tmp.getValue();

        }
        public T remove(int index) {
            if (isEmpty()||index>=lentgh()) { return default(T); }
            SearchAt(index-1).setNext(SearchAt(index).getNext());
            return root.getValue();
        }
    }
}
