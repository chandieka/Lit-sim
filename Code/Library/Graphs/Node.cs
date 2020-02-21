using System.Collections.Generic;

namespace Library.Graphs
{
    /// <summary>
    /// A node of a graph.
    /// </summary>
    public class Node<T>
    {
        private List<Edge<T>> connections;

        /// <summary>
        /// The object this node references.
        /// </summary>
        public T Value { get; protected set; }
        /// <summary>
        /// The edges this node connects to.
        /// </summary>
        /// <remarks>
        /// This does not contain the edge leading to this node, since the eges are one-directional
        /// </remarks>
        public Edge<T>[] Connections { get => this.connections.ToArray(); }

        /// <summary>
        /// Create a new node object.
        /// </summary>
        /// <param name="value">The object this node should reference.</param>
        public Node(T value)
        {
            this.Value = value;
            this.connections = new List<Edge<T>>();
        }

        /// <summary>
        /// Add a connection to this node.
        /// </summary>
        /// <param name="connection">The connection to be added</param>
        public void AddConnection(Edge<T> connection)
        {
            this.connections.Add(connection);
        }
        /// <summary>
        /// Add a connection to this node.
        /// </summary>
        /// <param name="node">The node the added connection will lead to.</param>
        /// <param name="weight">The weight of the added connection.</param>
        public void AddConnection(Node<T> node, double weight)
        {
            this.AddConnection(
                new Edge<T>(node, weight)
            );
        }

        /// <summary>
        /// Check if the edges of this node directly connect to the supplied node.
        /// </summary>
        /// <param name="node">The node that you want to check if it is directly connected.</param>
        /// <returns>A boolean indicating if it is directly connected.</returns>
        protected bool DirectlyConnectsTo(Node<T> node)
        {
            foreach (Edge<T> edge in this.Connections)
            {
                if (edge.EndNode == node) return true;
            }

            return false;
        }
        /// <summary>
        /// Check if this node connects to the supplied node.
        /// </summary>
        /// <param name="node">The node that you want to check if it is connected.</param>
        /// <returns>A boolean indicating if it is directly connected.</returns>
        public bool ConnectsTo(Node<T> node)
        {
            if (this.DirectlyConnectsTo(node)) return true;
            else
            {
                foreach (Edge<T> edge in this.Connections)
                {
                    if (edge.EndNode.ConnectsTo(node)) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The weight of all the connected edges combined.
        /// </summary>
        /// <returns>A double indicating the total weight.</returns>
        public double Length()
        {
            // TODO

            return 0d;
        }
        /// <summary>
        /// The number of edges in a longest possible path.
        /// </summary>
        /// <returns>An integer indicating the number of edges.</returns>
        public int Height()
        {
            // TODO

            return 0;
        }
    }
}
