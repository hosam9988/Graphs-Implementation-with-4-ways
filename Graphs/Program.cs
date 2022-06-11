using System;
using System.Collections.Generic;

namespace Graphs
{
    class Edge_
    {
        public string StartVertex;
        public string EndVertex;
        public int weight;
    }
    class Edge
    {
        public string vertex;
        public int weight;
    }
    class Program
    {
        // This is the Graph iam gonna practice my examples on ! xD
        // its an undirected weighted Graph !
        //          10
        //      (Cairo) __ (Alex)
        //   20 |
        //      (Giza)
        //   30 |
        //      (Sa7el)
        static void Main(string[] args)
        {
            //1st way ( Edge List )
            //Space Complexity = O(V+E) O(V) for VertexList and O(E) for EdgeList
            //Time Complexity for finding Adjacent Edges of a specific Edge we choose = O(E)
            //Where V = Vertices , E = Edges
            List<string> VertexList = new List<string> { "Cairo","Alex","Giza","Sa7el" };
            List<string> SortedVertexList = new List<string>(VertexList);
            SortedVertexList.Sort();
            string Vertex_Cairo = SortedVertexList[SortedVertexList.BinarySearch("Cairo")];
            string Vertex_Alex = SortedVertexList[SortedVertexList.BinarySearch("Alex")];
            string Vertex_Giza = SortedVertexList[SortedVertexList.BinarySearch("Giza")];
            string Vertex_Sa7el = SortedVertexList[SortedVertexList.BinarySearch("Sa7el")];

            List<Edge_> EdgeList = new List<Edge_>
            {   new Edge_() { StartVertex = Vertex_Cairo, EndVertex = Vertex_Alex, weight = 10 },
                new Edge_() { StartVertex = Vertex_Cairo, EndVertex = Vertex_Giza, weight = 20 },
                new Edge_() { StartVertex = Vertex_Giza, EndVertex = Vertex_Sa7el, weight = 30 }
            };

            Console.WriteLine("Edges List :D \n");
            Console.WriteLine("[Vertex]" + "[Vertex]" + "[Weight]" +"\n");

            for (int i = 0; i < EdgeList.Count; i++)
            {
                Console.WriteLine(EdgeList[i].StartVertex +"\t"+ EdgeList[i].EndVertex +"\t"+ EdgeList[i].weight);
            }
            Console.WriteLine("\n********************************************** \n");

            /************************************************************************************************************/

            //2nd way ( Adjacency Matrix )
            //Space Complexity = O(V^2)
            //Time Complexity for finding Adjacent Edges of a specific Edge we choose = O(V)

            int[,] AdjacencyMatrix = new int[VertexList.Count , VertexList.Count];

            //1st Row
            AdjacencyMatrix[0, 0] = 0; 
            AdjacencyMatrix[0, 1] = 10; //  here Vertex Cairo is connected with Vertex Alex
            AdjacencyMatrix[0, 2] = 20; //  here Vertex Cairo is connected with Vertex Giza
            AdjacencyMatrix[0, 3] = 0; //   here Vertex Cairo isnt connected with Vertex Sa7el

            //2nd Row
            AdjacencyMatrix[1, 0] = 10; // here Vertex Alex is connected with Vertex Cairo
            AdjacencyMatrix[1, 1] = 0; 
            AdjacencyMatrix[1, 2] = 0; //  here Vertex Alex isnt connected with Vertex Giza
            AdjacencyMatrix[1, 3] = 0; //  here Vertex Alex isnt connected with Vertex Sa7el

            //3rd Row
            AdjacencyMatrix[2, 0] = 20; // here Vertex Giza is connected with Vertex Cairo
            AdjacencyMatrix[2, 1] = 0; //  here Vertex Giza isnt connected with Vertex Alex
            AdjacencyMatrix[2, 2] = 0; 
            AdjacencyMatrix[2, 3] = 30; // here Vertex Giza is connected with Vertex Sa7el

            //4th Row
            AdjacencyMatrix[3, 0] = 0; //  here Vertex Sa7el isnt connected with Vertex Cairo
            AdjacencyMatrix[3, 1] = 0; //  here Vertex Sa7el isnt connected with Vertex Alex
            AdjacencyMatrix[3, 2] = 30; // here Vertex Sa7el is connected with Vertex Giza
            AdjacencyMatrix[3, 3] = 0; 

            Console.WriteLine("Adjacency Matrix :D \n");
            Console.WriteLine("\t" + "[0]" + "\t" + "[1]" + "\t" + "[2]" + "\t" + "[3]"+ "\n");

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                Console.Write("["+i+"]" + "\t");
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(AdjacencyMatrix[i, j] +"\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n********************************************** \n");

            /************************************************************************************************************/

            //3nd way ( Adjacency List )
            //1st >> using Dynamic sized Array(List) of Dynamic sized Arrays(Lists)
            //Space Complexity = O(E)
            //Time Complexity for finding Adjacent Edges of a specific Edge we choose = O(V)
            List<List<Edge>> AdjacencyList = new List<List<Edge>>();

            AdjacencyList.Add(new List<Edge> { new Edge { vertex = Vertex_Alex, weight = 10 } , new Edge { vertex = Vertex_Giza, weight = 20 } });      //Cairo
            AdjacencyList.Add(new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 10 } });                                                      //Alex
            AdjacencyList.Add(new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 20 } , new Edge { vertex = Vertex_Sa7el, weight = 30 } });    //Giza
            AdjacencyList.Add(new List<Edge> { new Edge { vertex = Vertex_Giza, weight = 30 } });                                                       //Sa7el

            Console.WriteLine("Adjacency List using Arrays :D \n");
            
            for (int i = 0; i < AdjacencyList.Count; i++)
            {
                Console.Write("["+ VertexList[i] +"]" + "\t");
                for (int j = 0; j < AdjacencyList[i].Count; j++)
                {
                    Console.Write(AdjacencyList[i][j].vertex + "(" + AdjacencyList[i][j].weight + ")" + "\t");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n********************************************** \n");

            //2nd >> using Dynamic Sized Array(List) of Linked Lists
            List<LinkedList<Edge>> AdjacencyList2 = new List<LinkedList<Edge>>();

            AdjacencyList2.Add(new LinkedList<Edge>());                                       //Cairo
            AdjacencyList2[0].AddLast(new Edge { vertex = Vertex_Alex , weight = 10 });
            AdjacencyList2[0].AddLast(new Edge { vertex = Vertex_Giza , weight = 20 });

            AdjacencyList2.Add(new LinkedList<Edge>());                                      //Alex
            AdjacencyList2[1].AddLast(new Edge { vertex = Vertex_Cairo , weight = 10 });

            AdjacencyList2.Add(new LinkedList<Edge>());                                      //Giza
            AdjacencyList2[2].AddLast(new Edge { vertex = Vertex_Cairo , weight = 20 });
            AdjacencyList2[2].AddLast(new Edge { vertex = Vertex_Sa7el , weight = 30 });

            AdjacencyList2.Add(new LinkedList<Edge>());                                      //Sa7el
            AdjacencyList2[3].AddLast(new Edge { vertex = Vertex_Giza , weight=30 });

            Console.WriteLine("Adjacency List using LinkedLists :D \n");

            for (int i = 0; i < AdjacencyList2.Count; i++)
            {
                Console.Write("[" + VertexList[i] + "]" + "\t");
                foreach (Edge item in AdjacencyList2[i])
                {
                    Console.Write(item.vertex +"("+ item.weight +")"+ "\t");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n********************************************** \n");

            //We Can Implement this Adjacency List using Binary Trees instead of Linked Lists in this Adjajency List
            //and it will be better because Binary Tree has the same Time complexity value as linked List in terms of inserting new Edges O( n )
            // and is better than Linked list in Time Complexity value in terms of Searching O( Log n )
            // and that is built in Binary Tree class provided by C# which i can use instead of implementing the Binary Tree Myself :D
            //SortedSet<Edge> BinaryTree = new SortedSet<Edge>();

    /**************************************************************************************************************************************************************************/

            //4th Way ( Hash Table )
            //using Dynamic sized Array(List) of Dynamic sized Arrays(Lists)

            Dictionary<string, List<Edge>> Cities = new Dictionary<string, List<Edge>>();
            Cities[Vertex_Cairo] = new List<Edge> { new Edge { vertex = Vertex_Alex, weight = 10 }, new Edge { vertex = Vertex_Giza, weight = 20 } };
            Cities[Vertex_Alex]  = new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 10 } };
            Cities[Vertex_Giza]  = new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 20 } , new Edge { vertex = Vertex_Sa7el, weight = 30 } };
            Cities[Vertex_Sa7el] = new List<Edge> { new Edge { vertex = Vertex_Giza, weight = 30 } };

            //Now we Will search if their is a city called Sa7el in Cairo's Road Network
            //we will use Breadth first search Algorithm
            //Breadth First Search's Time Complexity = O( V + E )

            //now we add Neighbor Cities of Cairo to the Queue 
            //Dequeue first enqueued element ( nearest city to Cairo ) which is Alex or Giza ( Giza for example) and check if its (First letter) is ( S )
            //if its the one we are searching for then we have got it and knew it exists in our road network
            //if not then we will enqueue Giza's Neighbors and search in them after search other nearest cities to Cairo and SO ON untill we reach it or just dont find it
            // With this Algorithm we will find the Nearest City to Cairo which its name begins with the letter (S) ! :D :D :D
            Queue<Edge> SearchingQueue = new Queue<Edge>(Cities[Vertex_Cairo]);
            List<string> searchedVertexes = new List<string>();

            while (SearchingQueue.Count >0)
            {
                Edge edge = SearchingQueue.Dequeue();

                if (!searchedVertexes.Contains(edge.vertex))
                {
                    if (edge.vertex[0] == 'S')
                    {
                        Console.WriteLine($"{edge.vertex} Begins with the letter S ! :D");
                        break;
                    }
                    else
                    {
                        Cities[edge.vertex].ForEach(Edge => SearchingQueue.Enqueue(Edge));
                        searchedVertexes.Add(edge.vertex);
                    }
                }               
            }

        }
    }
}
