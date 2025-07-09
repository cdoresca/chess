using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.util
{
    internal class Vertex<T> {

        HashSet<Vertex<T>> neighbors;

        T Value;
        public Vertex(T key) 
        { 
            Value = key;
            neighbors = new HashSet<Vertex<T>>();
        }

        public T getValue() { return Value; }

        public void addNeighbors(Vertex<T> v) { neighbors.Add(v); }

        public HashSet<Vertex<T>> getNeighbors() { return neighbors; }

        public bool vertexIn(Vertex<T> v) {  return neighbors.Contains(v); }
    }

 
    internal class Graph<T>
    {
        
        Dictionary<T,Vertex<T>> vertice;

        int[,] matrix;

        public Graph() { vertice = new Dictionary<T,Vertex<T>>(); }

        public void addVertex(T value) { vertice.Add(value,new Vertex<T>(value)); }

        public void removeVertex(T value) { vertice.Remove(value);} 

        public void addEdge(T fromVertex,T toVertex) 
        {
            if (!vertice.ContainsKey(fromVertex))
            {
                addVertex(fromVertex);
            }
            if (!vertice.ContainsKey(toVertex))
            {
                addVertex(toVertex);
            }

            vertice[fromVertex].addNeighbors(vertice[toVertex]);
            vertice[toVertex].addNeighbors(vertice[fromVertex]);
        }

        public int[,] matrixAdjacent()
        {
            int x = 0; int y=0;
            int size=vertice.Count;
            matrix = new int[size, size];
            foreach (var i in vertice)
            {

                foreach (var j in vertice)
                {
                    if (i.Value.vertexIn(j.Value)) { matrix[x, y] = 1; }
                    else { matrix[x, y]= 0; }
                    y++;
                }
                y = 0;
                x++;
            }
            return matrix;

        }
    }
}
