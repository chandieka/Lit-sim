using System.Collections.Generic;

namespace Library.Graphs
{
    /// <summary>
    /// A graph containing nodes and edges.
    /// </summary>
    public class Graph<T>
    {
        private List<Node<T>> roots;

        /// <summary>
        /// The starting points of the graph.
        /// </summary>
        /// <remarks>
        /// These starting points may in some way be connected later on.
        /// </remarks>
        public Node<T>[] Roots { get => this.roots.ToArray(); }

        /// <summary>
        /// Create a new graph object.
        /// </summary>
        public Graph()
        {
            this.roots = new List<Node<T>>();
        }

        /// <summary>
        /// Add a new root to the graph.
        /// </summary>
        /// <param name="node">The node that will be the root.</param>
        public void AddNode(Node<T> node)
        {
            this.roots.Add(node);
        }

        /// <summary>
        /// Check if any of the roots in this graph connect to the given node.
        /// </summary>
        /// <param name="node">The node to check for.</param>
        /// <returns>A boolean value indicating if it is contained within the graph.</returns>
        public bool Contains(Node<T> node)
        {
            foreach (Node<T> root in this.Roots)
            {
                if (root == node) return true;
                if (root.ConnectsTo(node)) return true;
            }

            return false;
        }

        /// <summary>
        /// Check the depth of the given node if it is connected to any of the roots.
        /// </summary>
        /// <param name="node">The node to check for.</param>
        /// <returns>An integer value that represents the level of the node.</returns>
        /// <remarks>
        /// Might return -1 if the node is not part of this graph.
        /// </remarks>
        public int Depth(Node<T> node)
        {
            // TODO

            return 0;
        }
    }

    /// <summary>
    /// A few example graphs for testing purposes.
    /// </summary>
    public class ExampleGraphs
    {
        public static Graph<string> Dictionary
        {
            get
            {
                var gr = new Graph<string>();

                var hello = new Node<string>("Hello ");
                hello.AddConnection(new Edge<string>(new Node<string>("world!"), 0d));
                hello.AddConnection(new Edge<string>(new Node<string>("there!"), 1d));
                hello.AddConnection(new Edge<string>(new Node<string>(", is it me you're looking for?"), 2d));

                var good = new Node<string>("Good ");
                good.AddConnection(new Edge<string>(new Node<string>("day!"), 0d));
                good.AddConnection(new Edge<string>(new Node<string>("morning!"), 1d));
                good.AddConnection(new Edge<string>(new Node<string>("afternoon"), 2d));

                gr.AddNode(hello);
                gr.AddNode(good);
                return gr;
            }
        }
    }
}
